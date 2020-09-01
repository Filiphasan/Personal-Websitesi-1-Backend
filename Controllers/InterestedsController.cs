using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;

namespace MyWebsite.Controllers
{
    public class InterestedsController : Controller
    {
        private PersonalWebsiteContext db = new PersonalWebsiteContext();

        // GET: Interesteds
        public ActionResult Index()
        {
            return View(db.Interesteds.ToList());
        }

        // GET: Interesteds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interesteds interesteds = db.Interesteds.Find(id);
            if (interesteds == null)
            {
                return HttpNotFound();
            }
            return View(interesteds);
        }

        // GET: Interesteds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interesteds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Interested")] Interesteds interesteds)
        {
            if (ModelState.IsValid)
            {
                db.Interesteds.Add(interesteds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interesteds);
        }

        // GET: Interesteds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interesteds interesteds = db.Interesteds.Find(id);
            if (interesteds == null)
            {
                return HttpNotFound();
            }
            return View(interesteds);
        }

        // POST: Interesteds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Interested")] Interesteds interesteds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interesteds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interesteds);
        }

        // GET: Interesteds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interesteds interesteds = db.Interesteds.Find(id);
            if (interesteds == null)
            {
                return HttpNotFound();
            }
            return View(interesteds);
        }

        // POST: Interesteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interesteds interesteds = db.Interesteds.Find(id);
            db.Interesteds.Remove(interesteds);
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
