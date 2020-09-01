using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        PersonalWebsiteContext context = new PersonalWebsiteContext();
        public ActionResult Index()
        {
            return View(context.About.ToList());
        }

        public ActionResult Edit(int? id)
        {
            About about = context.About.Find(id);
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(About about, HttpPostedFileBase resimUrl, HttpPostedFileBase cvFile)
        {
            if (ModelState.IsValid)
            {
                var a = context.About.Find(about.Id);
                if (resimUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(a.ResimUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(a.ResimUrl));
                    }
                    WebImage img = new WebImage(resimUrl.InputStream);
                    FileInfo imgInfo = new FileInfo(resimUrl.FileName);
                    string resimYolu = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Resize(500, 500, false, false);
                    img.Save("~/Content/MyWebSite/img/" + resimYolu);
                    about.ResimUrl = "/Content/MyWebSite/img/" + resimYolu;
                    a.ResimUrl = about.ResimUrl;
                }
                if (cvFile != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(a.MyCV)))
                    {
                        System.IO.File.Delete(Server.MapPath(a.MyCV));
                    }
                    FileInfo cvFileInfo = new FileInfo(cvFile.FileName);
                    string cvFileYolu = Guid.NewGuid().ToString() + cvFileInfo.Extension;
                    cvFile.SaveAs(Server.MapPath("~/Content/MyWebSite/myResume/" + cvFileYolu));
                    about.MyCV = "/Content/MyWebSite/myResume/" + cvFileYolu;
                    a.MyCV = about.MyCV;
                }
                a.Name = about.Name;
                a.Surname = about.Surname;
                a.MyJob = about.MyJob;
                a.BirthDate = about.BirthDate;
                a.MyJobFA = about.MyJobFA;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(about);
            }
        }

        public ActionResult Details(int id)
        {
            About about = context.About.Find(id);
            return View(about);
        }
    }
}