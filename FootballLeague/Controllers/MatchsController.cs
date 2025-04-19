using FootballLeague.Data;
using FootballLeague.Models;
using FootballLeague.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class MatchsController : Controller
    {
        private FootballLeagueContext db = new FootballLeagueContext();

        public ActionResult Index(int? numeroRodada, int? timeId, string estadio, bool limpar = false)
        {
            var league = db.Leagues.FirstOrDefault();
            if (league == null)
                return View("Error");

            ViewBag.Times = new SelectList(db.Teams.ToList(), "Id", "Name");
            ViewBag.Estadios = new SelectList(db.Teams.Select(t => t.Stadium).Distinct().ToList());

            // Se clicou em "Limpar Filtros"
            if (limpar)
            {
                return RedirectToAction("Index", new { numeroRodada = 1 });
            }

            // Se tiver filtros aplicados, mostrar todos os jogos da liga filtrados
            if (timeId.HasValue || !string.IsNullOrEmpty(estadio))
            {
                var jogosFiltrados = db.Matchs
                    .Include("HomeTeam")
                    .Include("AwayTeam")
                    .Where(m =>
                        (!timeId.HasValue || m.HomeTeamId == timeId || m.AwayTeamId == timeId) &&
                        (string.IsNullOrEmpty(estadio) || m.Stadium == estadio))
                    .OrderBy(m => m.MatchDate)
                    .ToList();

                ViewBag.Filtrando = true;
                return View("IndexTodos", jogosFiltrados); // nova view para todos os jogos
            }

            // Caso contrário: visualização paginada por rodada
            int rodadaAtualNumero = numeroRodada ?? 1;

            var rodada = db.Rounds
                .Include("Matches.HomeTeam")
                .Include("Matches.AwayTeam")
                .FirstOrDefault(r => r.LeagueId == league.Id && r.Number == rodadaAtualNumero);

            if (rodada == null)
                return HttpNotFound();

            ViewBag.RodadaNumero = rodadaAtualNumero;
            ViewBag.TotalRodadas = db.Rounds.Count(r => r.LeagueId == league.Id);
            ViewBag.Filtrando = false;
            ViewBag.LeagueId = league.Id;

            return View(rodada);
        }

        public ActionResult Filtrar(int? timeId, string estadio)
        {
            var matches = db.Matchs
                .Include("HomeTeam")
                .Include("AwayTeam")
                .AsQueryable();

            if (timeId.HasValue)
            {
                matches = matches.Where(m => m.HomeTeamId == timeId || m.AwayTeamId == timeId);
            }

            if (!string.IsNullOrEmpty(estadio))
            {
                matches = matches.Where(m => m.Stadium == estadio);
            }

            ViewBag.Times = new SelectList(db.Teams.ToList(), "Id", "Name", timeId);
            ViewBag.Estadios = new SelectList(
                db.Matchs
                    .Where(m => m.Stadium != null)
                    .Select(m => m.Stadium)
                    .Distinct()
                    .ToList(),
                estadio
            );

            return View(matches.ToList());
        }

        [HttpPost]
        public ActionResult SimularRodada(int numeroRodada, int leagueId)
        {
            var service = new ServiceLeague.LeagueService(db);
            service.SimularRodada(numeroRodada, leagueId);

            return RedirectToAction("Index", new { numeroRodada = numeroRodada, leagueId = leagueId });
        }

    }
}
