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
    public class SocialMediaAccountsController : Controller
    {
        private PersonalWebsiteContext db = new PersonalWebsiteContext();

        // GET: SocialMediaAccounts
        public ActionResult Index()
        {
            return View(db.SocialMediaAccount.ToList());
        }

        // GET: SocialMediaAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaAccount socialMediaAccount = db.SocialMediaAccount.Find(id);
            if (socialMediaAccount == null)
            {
                return HttpNotFound();
            }
            return View(socialMediaAccount);
        }

        // GET: SocialMediaAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaAccount socialMediaAccount = db.SocialMediaAccount.Find(id);
            if (socialMediaAccount == null)
            {
                return HttpNotFound();
            }
            return View(socialMediaAccount);
        }

        // POST: SocialMediaAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Facebook,Twitter,Linkedin,Github,Youtube")] SocialMediaAccount socialMediaAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialMediaAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMediaAccount);
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
