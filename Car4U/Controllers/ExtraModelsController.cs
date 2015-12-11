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
    public class ExtraModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExtraModels
        public ActionResult Index()
        {
            return View(db.ExtraModels.ToList());
        }

        // GET: ExtraModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraModel extraModel = db.ExtraModels.Find(id);
            if (extraModel == null)
            {
                return HttpNotFound();
            }
            return View(extraModel);
        }

        // GET: ExtraModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtraModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Model,Price,Stock")] ExtraModel extraModel)
        {
            if (ModelState.IsValid)
            {
                db.ExtraModels.Add(extraModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extraModel);
        }

        // GET: ExtraModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraModel extraModel = db.ExtraModels.Find(id);
            if (extraModel == null)
            {
                return HttpNotFound();
            }
            return View(extraModel);
        }

        // POST: ExtraModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Model,Price,Stock")] ExtraModel extraModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extraModel);
        }

        // GET: ExtraModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraModel extraModel = db.ExtraModels.Find(id);
            if (extraModel == null)
            {
                return HttpNotFound();
            }
            return View(extraModel);
        }

        // POST: ExtraModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ExtraModel extraModel = db.ExtraModels.Find(id);
            db.ExtraModels.Remove(extraModel);
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
