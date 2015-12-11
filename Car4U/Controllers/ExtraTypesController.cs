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
    public class ExtraTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExtraTypes
        public ActionResult Index()
        {
            return View(db.ExtraTypes.ToList());
        }

        // GET: ExtraTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraModelType extraType = db.ExtraTypes.Find(id);
            if (extraType == null)
            {
                return HttpNotFound();
            }
            return View(extraType);
        }

        // GET: ExtraTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtraTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] ExtraModelType extraType)
        {
            if (ModelState.IsValid)
            {
                db.ExtraTypes.Add(extraType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extraType);
        }

        // GET: ExtraTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraModelType extraType = db.ExtraTypes.Find(id);
            if (extraType == null)
            {
                return HttpNotFound();
            }
            return View(extraType);
        }

        // POST: ExtraTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] ExtraModelType extraType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extraType);
        }

        // GET: ExtraTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraModelType extraType = db.ExtraTypes.Find(id);
            if (extraType == null)
            {
                return HttpNotFound();
            }
            return View(extraType);
        }

        // POST: ExtraTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ExtraModelType extraType = db.ExtraTypes.Find(id);
            db.ExtraTypes.Remove(extraType);
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
