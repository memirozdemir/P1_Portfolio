using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult WorkList()
        {
            var value = context.Work.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWork(Work work)
        {
            context.Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        public ActionResult DeleteWork(int id)
        {
            var value = context.Work.Find(id);
            context.Work.Remove(value);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
        [HttpGet]
        public ActionResult UpdateWork(int id)
        {
            var value = context.Work.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateWork(Work work)
        {
            var value = context.Work.Find(work.workID);
            value.title = work.title;
            value.description = work.description;
            value.imageurl = work.imageurl;
            value.githuburl = work.githuburl;

            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
    }
}