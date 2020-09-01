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
    public class EducationsController : Controller
    {
        private PersonalWebsiteContext db = new PersonalWebsiteContext();

        // GET: Educations
        public ActionResult Index()
        {
            return View(db.Educations.ToList());
        }

        // GET: Educations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Educations educations = db.Educations.Find(id);
            if (educations == null)
            {
                return HttpNotFound();
            }
            return View(educations);
        }

        // GET: Educations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Education,School,Duration,Avarage,Description")] Educations educations)
        {
            if (ModelState.IsValid)
            {
                db.Educations.Add(educations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educations);
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Educations educations = db.Educations.Find(id);
            if (educations == null)
            {
                return HttpNotFound();
            }
            return View(educations);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Education,School,Duration,Avarage,Description")] Educations educations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educations);
        }

        // GET: Educations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Educations educations = db.Educations.Find(id);
            if (educations == null)
            {
                return HttpNotFound();
            }
            return View(educations);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Educations educations = db.Educations.Find(id);
            db.Educations.Remove(educations);
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
