using FootballLeague.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FootballLeague.Models;


namespace FootballLeague.Controllers
{
    public class HomeController : Controller
    {
        private FootballLeagueContext db = new FootballLeagueContext();

        public ActionResult Index()
        {
            var league = db.Leagues.FirstOrDefault(); // Pega a primeira liga
            var teams = db.Teams.Include(t => t.Liga).ToList();

            ViewBag.LeagueName = league?.Name ?? "Sem liga cadastrada";
            ViewBag.LeagueStatus = league?.Status ?? false;
            ViewBag.LeagueId = db.Leagues.FirstOrDefault()?.Id;

            return View(teams);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}