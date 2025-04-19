using FootballLeague.Data;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballLeague.Services
{
    public class ServiceLeague
    {
        public class LeagueService
        {
            private FootballLeagueContext db;

            public LeagueService(FootballLeagueContext context)
            {
                db = context;
            }

            public void SimularRodada(int numeroRodada, int leagueId)
            {
                var rodada = db.Rounds
                    .Include("Matches.HomeTeam")
                    .Include("Matches.AwayTeam")
                    .FirstOrDefault(r => r.Number == numeroRodada && r.LeagueId == leagueId);


                if (rodada == null) return;

                Random rng = new Random();

                foreach (var match in rodada.Matches)
                {
                    if (match.HomeGoals != null && match.AwayGoals != null)
                        continue; // já foi simulado

                    match.HomeGoals = rng.Next(0, 5);
                    match.AwayGoals = rng.Next(0, 5);

                    var homeStanding = db.LeagueStandings.FirstOrDefault(s => s.LeagueId == leagueId && s.TimeId == match.HomeTeamId);
                    var awayStanding = db.LeagueStandings.FirstOrDefault(s => s.LeagueId == leagueId && s.TimeId == match.AwayTeamId);

                    if (homeStanding == null || awayStanding == null)
                        continue;

                    homeStanding.GolsFor += match.HomeGoals.Value;
                    homeStanding.GolsAgainst += match.AwayGoals.Value;

                    awayStanding.GolsFor += match.AwayGoals.Value;
                    awayStanding.GolsAgainst += match.HomeGoals.Value;

                    if (match.HomeGoals > match.AwayGoals)
                    {
                        homeStanding.Points += 3;
                        homeStanding.Victories++;
                        awayStanding.Defeats++;
                    }
                    else if (match.HomeGoals < match.AwayGoals)
                    {
                        awayStanding.Points += 3;
                        awayStanding.Victories++;
                        homeStanding.Defeats++;
                    }
                    else
                    {
                        homeStanding.Points += 1;
                        awayStanding.Points += 1;
                        homeStanding.Draw++;
                        awayStanding.Draw++;
                    }
                }

                db.SaveChanges();
            }

            public void GerarRodadas(int leagueId)
            {
                var league = db.Leagues
                    .Include("Times")
                    .FirstOrDefault(l => l.Id == leagueId);

                if (league == null)
                    return;

                if (league.Times == null || league.Times.Count(t => t.Status) != 20)
                    return;

                var teams = league.Times.Where(t => t.Status).ToList();

                int totalTimes = teams.Count;
                int totalRodadas = (totalTimes - 1) * 2;

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

                        if (rodada >= (totalRodadas / 2))
                        {
                            var temp = home;
                            home = away;
                            away = temp;
                        }

                        novaRodada.Matches.Add(new Match
                        {
                            HomeTeamId = home.Id,
                            AwayTeamId = away.Id,
                            Stadium = home.Stadium,
                            MatchDate = DateTime.Now.AddDays(rodada * 7)
                        });
                    }

                    rodadas.Add(novaRodada);
                }

                db.Rounds.AddRange(rodadas);
                db.SaveChanges();
            }

            public void VerificarLigasCompletasEGerarRodadas()
            {
                var ligas = db.Leagues.Include("Times.Players").Include("Times.Coaches").ToList();

                foreach (var liga in ligas)
                {
                    // Usa o Status já definido
                    if (liga.Status)
                    {
                        bool rodadasJaGeradas = db.Rounds.Any(r => r.LeagueId == liga.Id);
                        if (!rodadasJaGeradas)
                        {
                            GerarRodadas(liga.Id);
                        }
                    }
                }
            }

            public void InicializarClassificacao(int leagueId)
            {
                var league = db.Leagues.Include("Times").FirstOrDefault(l => l.Id == leagueId);

                if (league == null || league.Times == null)
                    return;

                if (league.Times == null || league.Times.Count(t => t.Status) != 20)
                    return;

                foreach (var time in league.Times)
                {
                    var standing = new LeagueStanding
                    {
                        LeagueId = leagueId,
                        TimeId = time.Id,
                        Points = 0,
                        Victories = 0,
                        Draw = 0,
                        Defeats = 0,
                        GolsFor = 0,
                        GolsAgainst = 0
                    };

                    db.LeagueStandings.Add(standing);
                }

                db.SaveChanges();
            }

        }
    }
}