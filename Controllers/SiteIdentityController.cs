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
    public class SiteIdentityController : Controller
    {
        private PersonalWebsiteContext db = new PersonalWebsiteContext();

        // GET: SiteIdentity
        public ActionResult Index()
        {
            return View(db.SiteIdentity.ToList());
        }

        // GET: SiteIdentity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteIdentity siteIdentity = db.SiteIdentity.Find(id);
            if (siteIdentity == null)
            {
                return HttpNotFound();
            }
            return View(siteIdentity);
        }

        // GET: SiteIdentity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteIdentity siteIdentity = db.SiteIdentity.Find(id);
            if (siteIdentity == null)
            {
                return HttpNotFound();
            }
            return View(siteIdentity);
        }

        // POST: SiteIdentity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,Keywords,Description,LogoFA,LogoTitle")] SiteIdentity siteIdentity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteIdentity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteIdentity);
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
