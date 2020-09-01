using MyWebsite.Models.Classes;
using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Web.UI.WebControls.WebParts;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private PersonalWebsiteContext context = new PersonalWebsiteContext();

        [Route("")]
        [Route("Anasayfa")]
        public ActionResult Index()
        {
            List<HomePageSlider> home = context.HomePageSlider.ToList();
            return View(home);
        }

        [Route("{SliderTitle}/dahafazlasi/id={id:int}")]
        public ActionResult DahaFazlasi(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            HomePageSlider pageSlider = context.HomePageSlider.Find(id);
            if (pageSlider == null)
            {
                return HttpNotFound();
            }
            return View(pageSlider);
        }

        public ActionResult PartialHeaderView()
        {
            List<SiteIdentity> identities = context.SiteIdentity.ToList();
            return PartialView(identities);
        }

        public ActionResult PartialFooterView()
        {
            List<SocialMediaAccount> list = context.SocialMediaAccount.ToList();
            ViewBag.longAdress = context.ContactInfo.Select(x => x.LongAdress).FirstOrDefault();
            return PartialView(list);
        }

        public ActionResult PartialMetaTag()
        {
            ViewBag.metaTagInfo = context.SiteIdentity.FirstOrDefault();
            return PartialView();
        }

        [Route("Hakkimda")]
        public ActionResult Hakkimda()
        {
            ViewBag.about = context.About.FirstOrDefault();
            ViewBag.contactInfo = context.ContactInfo.FirstOrDefault();
            ViewBag.socialMediaAccounts = context.SocialMediaAccount.FirstOrDefault();
            ViewBag.summary = context.Summary.FirstOrDefault();
            ViewBag.skills = context.Skills.ToList();
            ViewBag.experiences = context.Experiences.ToList();
            ViewBag.educations = context.Educations.ToList();
            ViewBag.interested = context.Interesteds.ToList();
            return View();
        }

        [Route("iletisim")]
        public ActionResult iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult iletisim(Messages messages)
        {
            if (ModelState.IsValid)
            {
                messages.Durum = false;
                context.Messages.Add(messages);
                context.SaveChanges();
            }
            return View(messages);
        }

        public ActionResult PartialCategories()
        {
            List<Categories> ctgr = context.Categories.Where(x => x.State == false).ToList();
            return View(ctgr);
        }

        public ActionResult PartialMostReadBlogPosts()
        {
            context.Configuration.LazyLoadingEnabled = false;
            List<Blogs> blog = context.Blogs.Include("Categories").Where(x => x.State == true).OrderByDescending(x => x.ReadCount).Take(3).ToList();
            return View(blog);
        }

        public ActionResult PartialArama()
        {
            return PartialView();
        }

        [Route("BlogGonderileri")]
        public ActionResult BlogGonderileri(string arama, int sayfa = 1)
        {
            context.Configuration.LazyLoadingEnabled = false;
            var blog = context.Blogs.Include("Categories").Where(x => x.State == true).OrderByDescending(x => x.Id).ToPagedList(sayfa, 3);
            if (!string.IsNullOrEmpty(arama))
            {
                blog = context.Blogs.Include("Categories").Where(x => x.State == true && x.Title.Contains(arama)).OrderByDescending(x => x.Id).ToPagedList(sayfa, 3);
            }
            return View(blog);
        }

        [Route("BlogGonderileri/{CategoryName}/id={id:int}")]
        public ActionResult KategoriBlogGonderileri(int? id, int sayfa = 1)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var blogs = context.Blogs.Include("Categories").Where(x => x.State == true && x.CategoryId == id).OrderByDescending(x => x.Id).ToPagedList(sayfa, 3);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            return View(blogs);
        }

        [Route("BlogGonderileri/{Title}-{id:int}")]
        public ActionResult BlogGonderiDetay(int? id)
        {
            context.Configuration.LazyLoadingEnabled = false;
            if (id == null)
            {
                return HttpNotFound();
            }
            Blogs blogs = context.Blogs.Include("Categories").Where(x => x.Id == id).FirstOrDefault();
            if (blogs == null)
            {
                return HttpNotFound();
            }
            blogs.ReadCount = blogs.ReadCount + 1;
            context.SaveChanges();
            ViewBag.imageList = context.BlogImages.Where(x => x.BlogId == id).ToList();
            ViewBag.commentsList = context.Comments.Where(x => x.State == true && x.BlogId == id).ToList();
            return View(blogs);
        }


        public ActionResult YorumYap(Comments comments, int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return HttpNotFound();
                }
                comments.State = false;
                comments.BlogId = id;
                context.Comments.Add(comments);
                context.SaveChanges();
                return RedirectToAction("BlogGonderiDetay", new { id = id });
            }
            return RedirectToAction("BlogGonderiDetay", new { id = id });
        }
    }
}