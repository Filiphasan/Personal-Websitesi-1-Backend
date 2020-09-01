using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Helpers;
using System.IO;

namespace MyWebsite.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        PersonalWebsiteContext context = new PersonalWebsiteContext();
        public ActionResult Index(int sayfa = 1)
        {
            context.Configuration.LazyLoadingEnabled = false;
            var blog = context.Blogs.Include(x => x.Categories).Where(x => x.State == true).OrderBy(x => x.Id).ToPagedList(sayfa, 4);
            return View(blog);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            context.Configuration.LazyLoadingEnabled = false;
            Blogs blogs = context.Blogs.Include(x => x.Categories).Where(x => x.Id == id).FirstOrDefault();
            if (blogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.blogTitle = context.Blogs.Where(x => x.Id == id).Select(x => x.Title).FirstOrDefault();
            return View(blogs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.Where(x => x.State == false), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Blogs blogs, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                blogs.State = true;
                context.Blogs.Add(blogs);
                context.SaveChanges();
                if (image != null)
                {
                    WebImage img = new WebImage(image.InputStream);
                    FileInfo imgInfo = new FileInfo(image.FileName);
                    string imgPath = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Resize(1200, 675, false, false);
                    img.Save(Server.MapPath("~/Content/MyWebSite/img/BlogImages/" + imgPath));
                    BlogImages blogImages = new BlogImages();
                    var lastBlog = context.Blogs.OrderByDescending(x => x.Id).FirstOrDefault();
                    blogImages.BlogId = lastBlog.Id;
                    blogImages.State = true;
                    blogImages.ImagePath = "/Content/MyWebSite/img/BlogImages/" + imgPath;
                    context.BlogImages.Add(blogImages);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Blogs blogs = context.Blogs.Find(id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(context.Categories.Where(x => x.State == false), "Id", "CategoryName");
            return View(blogs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                Blogs b = context.Blogs.Find(blogs.Id);
                b.Description = blogs.Description;
                b.CategoryId = blogs.CategoryId;
                b.Title = blogs.Title;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditImage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var list = context.BlogImages.Where(x => x.BlogId == id).ToList();
            if (list == null)
            {
                return HttpNotFound();
            }
            ViewBag.blogTitle = context.Blogs.Where(x => x.Id == id).Select(x => x.Title).FirstOrDefault();
            return View(list);
        }

        public ActionResult DeleteImage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var values = context.BlogImages.Find(id);
            if (values == null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(values.ImagePath)))
            {
                System.IO.File.Delete(Server.MapPath(values.ImagePath));
            }
            context.BlogImages.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddImage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.blogTitle = context.Blogs.Where(x => x.Id == id).Select(x => x.Title).FirstOrDefault();
            var blogInfo = context.Blogs.Find(id);
            return View(blogInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(Blogs blogs, HttpPostedFileBase image)
        {
            if (image != null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo imgInfo = new FileInfo(image.FileName);
                string imgPath = Guid.NewGuid().ToString() + imgInfo.Extension;
                img.Resize(1200, 675, false, false);
                img.Save(Server.MapPath("~/Content/MyWebSite/img/BlogImages/" + imgPath));
                BlogImages blogImages = new BlogImages();
                blogImages.BlogId = blogs.Id;
                blogImages.ImagePath = "/Content/MyWebSite/img/BlogImages/" + imgPath;
                blogImages.State = true;
                context.BlogImages.Add(blogImages);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            context.Configuration.LazyLoadingEnabled = false;
            Blogs blogs = context.Blogs.Include(x => x.Categories).Where(x => x.Id == id).FirstOrDefault();
            if (blogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.blogTitle = context.Blogs.Where(x => x.Id == id).Select(x => x.Title).FirstOrDefault();
            return View(blogs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            List<BlogImages> blogImages = context.BlogImages.Where(x => x.BlogId == id).ToList();
            if (blogImages != null)
            {
                foreach (var item in blogImages)
                {
                    if (System.IO.File.Exists(Server.MapPath(item.ImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath(item.ImagePath));
                    }
                    context.BlogImages.Remove(item);
                    context.SaveChanges();
                }
            }
            Blogs blogs = context.Blogs.Find(id);
            blogs.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}