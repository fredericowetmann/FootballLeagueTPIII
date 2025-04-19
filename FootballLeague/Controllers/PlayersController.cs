using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FootballLeague.Data;
using FootballLeague.Models;
using static FootballLeague.Services.ServiceLeague;

namespace FootballLeague.Controllers
{
    public class PlayersController : Controller
    {
        private FootballLeagueContext db = new FootballLeagueContext();

        // GET: Players
        public async Task<ActionResult> Index(string searchName, MainFeet? mainFeet, Position? position)
        {
            var playersQuery = db.Players.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                playersQuery = playersQuery.Where(p => p.Name.Contains(searchName));
            }

            if (mainFeet.HasValue)
            {
                playersQuery = playersQuery.Where(p => p.MainFeet == mainFeet);
            }

            if (position.HasValue)
            {
                playersQuery = playersQuery.Where(p => p.Position == position);
            }

            var players = await playersQuery.ToListAsync();

            ViewBag.SearchName = searchName;
            ViewBag.SelectedMainFeet = mainFeet;
            ViewBag.SelectedPosition = position;
            ViewBag.LeagueId = db.Leagues.FirstOrDefault()?.Id;

            return View(players);
        }


        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Nacionality,BirthDate,Position,ShirtNumber,Height,Weight,MainFeet,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();

                var service = new LeagueService(db);
                service.VerificarLigasCompletasEGerarRodadas();

                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }


        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Nacionality,BirthDate,Position,ShirtNumber,Height,Weight,MainFeet,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();

                var service = new LeagueService(db);
                service.VerificarLigasCompletasEGerarRodadas();

                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);

            db.Players.Remove(player);
            db.SaveChanges();

            var service = new LeagueService(db);
            service.VerificarLigasCompletasEGerarRodadas();

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
    }
}
