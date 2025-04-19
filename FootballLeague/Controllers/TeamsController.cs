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
    public class TeamsController : Controller
    {
        private FootballLeagueContext db = new FootballLeagueContext();

        // GET: Teams
        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams
                  .Include(t => t.Players)
                  .Include(t => t.Coaches)
                  .FirstOrDefault(t => t.Id == id);

            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeagueId = db.Leagues.FirstOrDefault()?.Id;
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,State,FoundationYear,Stadium,CapacityStadium,MainColors,SecondaryColors,LeagueId")] Team team)
        {
            if (ModelState.IsValid)
            {

                var liga = db.Leagues.FirstOrDefault();
                if (liga != null)
                {
                    if (liga.Times.Count < 20)
                    {
                        team.LeagueId = liga.Id;
                        db.Teams.Add(team);
                        db.SaveChanges();

                        var service = new LeagueService(db);
                        service.VerificarLigasCompletasEGerarRodadas();
                    }
                    else
                    {
                        ModelState.AddModelError("", "A liga já está com o número máximo de times.");
                        ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", team.LeagueId);
                        return View(team);
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", team.LeagueId);
            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,State,FoundationYear,Stadium,CapacityStadium,MainColors,SecondaryColors,LeagueId")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();

                var service = new LeagueService(db);
                service.VerificarLigasCompletasEGerarRodadas();

                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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
