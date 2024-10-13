using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult Index()
        {
            return View(context.About.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var value = context.About.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Edit(About about)
        {
            var value = context.About.Find(about.aboutID);
            value.title = about.title;
            value.detail = about.detail;
            value.imageurl = about.imageurl;
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}