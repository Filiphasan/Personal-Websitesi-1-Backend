using MyWebsite.Models.DataContext;
using MyWebsite.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        PersonalWebsiteContext context = new PersonalWebsiteContext();
        public ActionResult Index()
        {
            List<Messages> m = context.Messages.Where(x => x.Durum == false).ToList();
            return View(m);
        }

        public ActionResult Index2()
        {
            List<Messages> m = context.Messages.Where(x => x.Durum == true).ToList();
            return View(m);
        }

        public ActionResult SaveAsRead(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Messages messages = context.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            messages.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Messages messages = context.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            context.Messages.Remove(messages);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AskMessage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Messages messages = context.Messages.Find(id);
            return View(messages);
        }

        [HttpPost]
        public ActionResult AskMessage(int? id,string recipintMail, string subject, string message)
        {
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.EnableSsl = true;
            WebMail.UserName = "hasaerda@gmail.com";
            WebMail.Password = "yourPassword";
            WebMail.SmtpPort = 587;
            WebMail.Send(recipintMail, subject, message);
            if (id != null)
            {
                Messages messages = context.Messages.Find(id);
                messages.Durum = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}