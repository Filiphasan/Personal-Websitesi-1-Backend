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
    public class SummaryController : Controller
    {
        private PersonalWebsiteContext db = new PersonalWebsiteContext();

        // GET: Summary
        public ActionResult Index()
        {
            return View(db.Summary.ToList());
        }

        // GET: Summary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summary.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // GET: Summary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summary.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // POST: Summary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Description")] Summary summary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(summary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(summary);
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
