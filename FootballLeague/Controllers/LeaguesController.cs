using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballLeague.Data;
using FootballLeague.Models;
using static FootballLeague.Services.ServiceLeague;

namespace FootballLeague.Controllers
{
    public class LeaguesController : Controller
    {
        private FootballLeagueContext db = new FootballLeagueContext();

        // GET: Leagues
        public ActionResult Index()
        {
            ViewBag.LeagueId = db.Leagues.FirstOrDefault()?.Id;
            return View(db.Leagues.ToList());
        }

        // GET: Leagues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        // GET: Leagues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // Exemplo dentro de LeagueController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] League league)
        {
            if (ModelState.IsValid)
            {
                db.Leagues.Add(league);
                db.SaveChanges();

                // Cria classificações iniciais
                var times = db.Teams.ToList();
                foreach (var time in times)
                {
                    db.LeagueStandings.Add(new LeagueStanding
                    {
                        TimeId = time.Id,
                        LeagueId = league.Id,
                        Points = 0,
                        Victories = 0,
                        Draw = 0,
                        Defeats = 0,
                        GolsFor = 0,
                        GolsAgainst = 0
                    });
                }

                return RedirectToAction("Index");
            }

            return View(league);
        }


        // GET: Leagues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] League league)
        {
            if (ModelState.IsValid)
            {
                db.Entry(league).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(league);
        }

        // GET: Leagues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            League league = db.Leagues.Find(id);
            db.Leagues.Remove(league);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Tabela(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var league = db.Leagues.Find(id);
            if (league == null)
                return HttpNotFound();

            ViewBag.NomeLiga = league.Name;

            // Buscando a classificação REAL da liga
            var standings = db.LeagueStandings
                    .Include(ls => ls.Time)
                    .Where(ls => ls.LeagueId == id)
                    .ToList() // <-- executa no banco primeiro
                    .OrderByDescending(ls => ls.Points)
                    .ThenByDescending(ls => ls.GolsDifference) // agora pode usar
                    .ThenByDescending(ls => ls.GolsFor)
                    .ToList();


            return View(standings);
        }

        public void AtualizarStatusLiga(League liga)
        {
            var times = db.Teams.Where(t => t.LeagueId == liga.Id).ToList();

            bool ligaValida = times.Count == 20 && times.All(t => t.Status == true);

            db.Entry(liga).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void GerarRodadas(int leagueId)
        {
            var league = db.Leagues
                .Include(l => l.Times)
                .FirstOrDefault(l => l.Id == leagueId);

            if (league == null || league.Times.Count(t => t.Status) != 20)
                return;

            var teams = league.Times.Where(t => t.Status).ToList();

            int totalTimes = teams.Count;
            int totalRodadas = (totalTimes - 1) * 2; // ida e volta

            List<Round> rodadas = new List<Round>();

            for (int rodada = 0; rodada < totalRodadas; rodada++)
            {
                Round novaRodada = new Round
                {
                    Number = rodada + 1,
                    LeagueId = leagueId,
                    Matches = new List<Match>()
                };

                for (int i = 0; i < totalTimes / 2; i++)
                {
                    int homeIndex = (rodada + i) % (totalTimes - 1);
                    int awayIndex = (totalTimes - 1 - i + rodada) % (totalTimes - 1);

                    if (i == 0)
                        awayIndex = totalTimes - 1;

                    var home = teams[homeIndex];
                    var away = teams[awayIndex];

                    if (rodada >= (totalRodadas / 2)) // volta, inverte mandante
                    {
                        var temp = home;
                        home = away;
                        away = temp;
                    }

                    novaRodada.Matches.Add(new Match
                    {
                        HomeTeamId = home.Id,
                        AwayTeamId = away.Id,
                        MatchDate = DateTime.Now.AddDays(rodada) // ou defina depois
                    });
                }

                rodadas.Add(novaRodada);
            }

            db.Rounds.AddRange(rodadas);
            db.SaveChanges();
        }

        public ActionResult Simular(int numeroRodada, int leagueId)
        {
            var service = new LeagueService(new FootballLeagueContext());
            service.SimularRodada(numeroRodada, leagueId);

            return RedirectToAction("Tabela", "Leagues", new { id = leagueId });
        }

    }
}
