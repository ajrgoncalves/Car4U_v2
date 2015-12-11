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
    public class ExtrasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Extras
        public ActionResult Index()
        {
            return View(db.Extras.ToList());
        }

        // GET: Extras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraItem extra = db.Extras.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // GET: Extras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] ExtraItem extra)
        {
            if (ModelState.IsValid)
            {
                db.Extras.Add(extra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extra);
        }

        // GET: Extras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraItem extra = db.Extras.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // POST: Extras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] ExtraItem extra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extra);
        }

        // GET: Extras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraItem extra = db.Extras.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ExtraItem extra = db.Extras.Find(id);
            db.Extras.Remove(extra);
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
