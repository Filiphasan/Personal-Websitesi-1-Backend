using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class ContactInfoController : Controller
    {
        // GET: ContactInfo
        PersonalWebsiteContext context = new PersonalWebsiteContext();
        public ActionResult Index()
        {
            List<ContactInfo> ınfo = context.ContactInfo.ToList();
            return View(ınfo);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var d = context.ContactInfo.Find(id);
            if (d ==null)
            {
                return HttpNotFound();
            }
            return View(d);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ContactInfo info = context.ContactInfo.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactInfo info)
        {
            if (ModelState.IsValid)
            {
                ContactInfo c = context.ContactInfo.Find(info.Id);
                c.PhoneNumber = info.PhoneNumber;
                c.Mail = info.Mail;
                c.LongAdress = info.LongAdress;
                c.ShortAdress = info.ShortAdress;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(info.Id);
        }
    }
}