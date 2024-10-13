using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult Inbox()
        {
            var values = context.Message.ToList();
            return View(values);
        }
        public ActionResult MessageDetails(int id)
        {
            var value = context.Message.Where(x => x.msgID == id).FirstOrDefault();
            value.isRead = true;
            context.SaveChanges();
            return View(value);
        }
        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value= context.Message.Where(x => x.msgID ==id).FirstOrDefault();
            value.isRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Message.Where(x => x.msgID == id).FirstOrDefault();
            value.isRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = context.Message.Find(id);
            context.Message.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}