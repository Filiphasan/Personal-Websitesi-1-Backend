using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        PersonalWebsiteContext context = new PersonalWebsiteContext();
        public ActionResult Index()
        {
            List<Comments> comments = context.Comments.Where(x => x.State == false).ToList();
            return View(comments);
        }

        public ActionResult Index2()
        {
            List<Comments> comments = context.Comments.Where(x => x.State == true).ToList();
            return View(comments);
        }

        public ActionResult Checked(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Comments comments = context.Comments.Find(id);
            comments.State = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveChecked(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Comments comments = context.Comments.Find(id);
            comments.State = false;
            context.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Comments comments = context.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Comments comments = context.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            bool value = comments.State;
            context.Comments.Remove(comments);
            context.SaveChanges();
            if (value == true)
            {
                return RedirectToAction("Index2");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}