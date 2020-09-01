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
    public class ExperiencesController : Controller
    {
        private PersonalWebsiteContext db = new PersonalWebsiteContext();

        // GET: Experiences
        public ActionResult Index()
        {
            return View(db.Experiences.ToList());
        }

        // GET: Experiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences experiences = db.Experiences.Find(id);
            if (experiences == null)
            {
                return HttpNotFound();
            }
            return View(experiences);
        }

        // GET: Experiences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Experience,Workplace,Duration,Description")] Experiences experiences)
        {
            if (ModelState.IsValid)
            {
                db.Experiences.Add(experiences);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(experiences);
        }

        // GET: Experiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences experiences = db.Experiences.Find(id);
            if (experiences == null)
            {
                return HttpNotFound();
            }
            return View(experiences);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Experience,Workplace,Duration,Description")] Experiences experiences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experiences);
        }

        // GET: Experiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences experiences = db.Experiences.Find(id);
            if (experiences == null)
            {
                return HttpNotFound();
            }
            return View(experiences);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experiences experiences = db.Experiences.Find(id);
            db.Experiences.Remove(experiences);
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
