using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car4U.DAL;
using Car4U.Models;

namespace Car4U.Controllers
{
    public class FuelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fuels
        public ActionResult Index()
        {
            return View(db.Fuels.ToList());
        }

        // GET: Fuels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fuel = db.Fuels.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // GET: Fuels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] FuelType fuel)
        {
            if (ModelState.IsValid)
            {
                db.Fuels.Add(fuel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuel);
        }

        // GET: Fuels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fuel = db.Fuels.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] FuelType fuel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuel);
        }

        // GET: Fuels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fuel = db.Fuels.Find(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FuelType fuel = db.Fuels.Find(id);
            db.Fuels.Remove(fuel);
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
