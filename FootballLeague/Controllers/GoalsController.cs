﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class GoalsController : Controller
    {
        // GET: Goals
        public ActionResult Index()
        {
            return View();
        }

        // GET: Goals/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Goals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goals/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goals/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goals/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goals/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Goals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
