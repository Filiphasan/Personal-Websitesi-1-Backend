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
    public class HomePageSliderController : Controller
    {
        private PersonalWebsiteContext db = new PersonalWebsiteContext();

        // GET: HomePageSlider
        public ActionResult Index()
        {
            return View(db.HomePageSlider.ToList());
        }

        // GET: HomePageSlider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomePageSlider homePageSlider = db.HomePageSlider.Find(id);
            if (homePageSlider == null)
            {
                return HttpNotFound();
            }
            return View(homePageSlider);
        }

        // GET: HomePageSlider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomePageSlider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SliderTitle,SliderDescription")] HomePageSlider homePageSlider)
        {
            if (ModelState.IsValid)
            {
                db.HomePageSlider.Add(homePageSlider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homePageSlider);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomePageSlider homePageSlider = db.HomePageSlider.Find(id);
            if (homePageSlider == null)
            {
                return HttpNotFound();
            }
            return View(homePageSlider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SliderTitle,SliderDescription")] HomePageSlider homePageSlider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homePageSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homePageSlider);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomePageSlider homePageSlider = db.HomePageSlider.Find(id);
            if (homePageSlider == null)
            {
                return HttpNotFound();
            }
            return View(homePageSlider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomePageSlider homePageSlider = db.HomePageSlider.Find(id);
            db.HomePageSlider.Remove(homePageSlider);
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
