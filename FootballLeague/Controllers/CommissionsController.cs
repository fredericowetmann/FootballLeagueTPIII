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
    public class CommissionsController : Controller
    {
        private FootballLeagueContext db = new FootballLeagueContext();

        // GET: Commissions
        public async Task<ActionResult> Index(string searchName, Function? function)
        {
            var commissionsQuery = db.Commissions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                commissionsQuery = commissionsQuery.Where(c => c.Name.Contains(searchName));
            }

            if (function.HasValue)
            {
                commissionsQuery = commissionsQuery.Where(c => c.Function == function);
            }

            ViewBag.SearchName = searchName;
            ViewBag.SelectedFunction = function;
            ViewBag.LeagueId = db.Leagues.FirstOrDefault()?.Id;

            var commissions = await commissionsQuery.ToListAsync();
            return View(commissions);
        }


        // GET: Commissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commission commission = db.Commissions.Find(id);
            if (commission == null)
            {
                return HttpNotFound();
            }
            return View(commission);
        }

        // GET: Commissions/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Commissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Function,BirthDate,TeamId")] Commission commission)
        {
            if (commission.TeamId.HasValue && commission.Function.HasValue)
            {
                bool funcaoJaExiste = db.Commissions.Any(c =>
                    c.TeamId == commission.TeamId &&
                    c.Function == commission.Function);

                if (funcaoJaExiste)
                {
                    ModelState.AddModelError("", "Este time já possui um membro da comissão com essa função.");
                }
            }

            if (ModelState.IsValid)
            {
                db.Commissions.Add(commission);
                db.SaveChanges();

                var service = new LeagueService(db);
                service.VerificarLigasCompletasEGerarRodadas();

                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", commission.TeamId);
            return View(commission);
        }

        // GET: Commissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commission commission = db.Commissions.Find(id);
            if (commission == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", commission.TeamId);
            return View(commission);
        }

        // POST: Commissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Function,BirthDate,TeamId")] Commission commission)
        {
            if (commission.TeamId.HasValue && commission.Function.HasValue)
            {
                bool funcaoJaExiste = db.Commissions.Any(c =>
                    c.TeamId == commission.TeamId &&
                    c.Function == commission.Function &&
                    c.Id != commission.Id); // exclui o atual da verificação

                if (funcaoJaExiste)
                {
                    ModelState.AddModelError("", "Este time já possui um membro da comissão com essa função.");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(commission).State = EntityState.Modified;
                db.SaveChanges();

                var service = new LeagueService(db);
                service.VerificarLigasCompletasEGerarRodadas();

                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", commission.TeamId);
            return View(commission);
        }

        // GET: Commissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commission commission = db.Commissions.Find(id);
            if (commission == null)
            {
                return HttpNotFound();
            }
            return View(commission);
        }

        // POST: Commissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commission commission = db.Commissions.Find(id);

            db.Commissions.Remove(commission);
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
