using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        PersonalWebsiteContext context = new PersonalWebsiteContext();

        [Route("yonetim")]
        public ActionResult Index()
        {
            ViewBag.sliderCount = context.HomePageSlider.Count();
            ViewBag.skillCount = context.Skills.Count();
            ViewBag.educationCount = context.Educations.Count();
            ViewBag.experienceCount = context.Experiences.Count();
            ViewBag.interestedCount = context.Interesteds.Count();
            ViewBag.unCheckedCommentCount = context.Comments.Where(x => x.State == false).Count();
            ViewBag.checkedCommentCount = context.Comments.Where(x => x.State == true).Count();
            ViewBag.blogCount = context.Blogs.Where(x => x.State == true).Count();
            ViewBag.categoryCount = context.Categories.Where(x => x.State == false).Count();
            ViewBag.readMessageCount = context.Messages.Where(x => x.Durum == true).Count();
            ViewBag.unReadMessageCount = context.Messages.Where(x => x.Durum == false).Count();
            ViewBag.messageCount = context.Messages.Count();
            return View();
        }

        [Route("yonetim/giris")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if (admin.Eposta != null)
            {
                if (admin.Password != null)
                {
                    string paswrd = Crypto.Hash(admin.Password, "MD5");
                    Admin a = context.Admin.Where(x => x.Eposta == admin.Eposta && x.Password == paswrd).FirstOrDefault();
                    if (a != null)
                    {
                        Session["adminId"] = a.Id;
                        Session["adminEposta"] = a.Eposta;
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Contents.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult ForgotPasswordEposta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPasswordEposta(string eposta)
        {
            if (eposta != null)
            {
                Admin admin = context.Admin.Where(x => x.Eposta == eposta).FirstOrDefault();
                if (admin != null)
                {
                    return RedirectToAction("ForgotPassword", new { id = admin.Id });
                }
            }
            return View();
        }
        public ActionResult ForgotPassword(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Admin admin = context.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.sq = admin.SecurityQuestion;
            return View(admin);
        }

        [HttpPost]
        public ActionResult ForgotPassword(Admin admin)
        {
            if (admin.Id != null)
            {
                Admin a = context.Admin.Find(admin.Id);
                if (a != null)
                {
                    if (a.SQAnswer == Crypto.Hash(admin.SQAnswer.ToLower(), "MD5"))
                    {
                        Random random = new Random();
                        string newPassword = random.Next(10000, 99999).ToString();
                        a.Password = Crypto.Hash(newPassword,"MD5");
                        context.SaveChanges();
                        WebMail.SmtpServer = "smtp.gmail.com";
                        WebMail.EnableSsl = true;
                        WebMail.UserName = "hasaerda@gmail.com";
                        WebMail.Password = "yourPassword";
                        WebMail.SmtpPort = 587;
                        WebMail.Send(a.Eposta, "Şifre Hatırlatma-Yeni Şifre", newPassword);
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }

        public ActionResult AdminList()
        {
            List<Admin> admins = context.Admin.ToList();
            return View(admins);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Admin admin = context.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin a = context.Admin.Find(admin.Id);
                a.Eposta = admin.Eposta;
                if (a.Password != admin.Password)
                {
                    a.Password = Crypto.Hash(admin.Password, "MD5");
                }
                if (a.SecurityQuestion.ToLower() != admin.SecurityQuestion.ToLower())
                {
                    a.SecurityQuestion = admin.SecurityQuestion.ToLower();
                }
                if (a.SQAnswer.ToLower() != admin.SQAnswer.ToLower())
                {
                    a.SQAnswer = Crypto.Hash(admin.SQAnswer.ToLower(), "MD5");
                }
                context.SaveChanges();
                return RedirectToAction("AdminList");
            }
            return View();
        }

        public ActionResult partialMessage()
        {
            ViewBag.messagesCount = context.Messages.Where(x => x.Durum == false).Count();
            return PartialView();
        }
    }
}