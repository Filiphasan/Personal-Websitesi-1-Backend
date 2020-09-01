using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        PersonalWebsiteContext context = new PersonalWebsiteContext();
        public ActionResult Index()
        {
            List<Categories> categories = context.Categories.Where(x => x.State == false).ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                categories.State = false;
                context.Categories.Add(categories);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Categories categories = context.Categories.Find(id);
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                Categories c = context.Categories.Find(categories.Id);
                if (c != null)
                {
                    c.CategoryName = categories.CategoryName;
                    c.CategoryFA = categories.CategoryFA;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(categories);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Categories categories = context.Categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            categories.State = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}