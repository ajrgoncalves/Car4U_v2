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
    public class UnavailabilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Unavailabilities
        public ActionResult Index()
        {
            return View(db.Unavailabilities.ToList());
        }

        // GET: Unavailabilities/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status unavailability = db.Unavailabilities.Find(id);
            if (unavailability == null)
            {
                return HttpNotFound();
            }
            return View(unavailability);
        }

        // GET: Unavailabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unavailabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Observation,BeginDate,FinishDate")] Status unavailability)
        {
            if (ModelState.IsValid)
            {
                db.Unavailabilities.Add(unavailability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unavailability);
        }

        // GET: Unavailabilities/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status unavailability = db.Unavailabilities.Find(id);
            if (unavailability == null)
            {
                return HttpNotFound();
            }
            return View(unavailability);
        }

        // POST: Unavailabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Observation,BeginDate,FinishDate")] Status unavailability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unavailability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unavailability);
        }

        // GET: Unavailabilities/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status unavailability = db.Unavailabilities.Find(id);
            if (unavailability == null)
            {
                return HttpNotFound();
            }
            return View(unavailability);
        }

        // POST: Unavailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Status unavailability = db.Unavailabilities.Find(id);
            db.Unavailabilities.Remove(unavailability);
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
