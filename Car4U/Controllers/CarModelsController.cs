﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car4U.CarModels;
using Car4U.DAL;

namespace Car4U.Controllers
{
    public class CarModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarModels
        public ActionResult Index()
        {
            return View(db.CarModels.ToList());
        }

        // GET: CarModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.CarModels.Add(carModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CarModel carModel = db.CarModels.Find(id);
            db.CarModels.Remove(carModel);
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
    }
}
