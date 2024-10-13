using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class AdminController : Controller
    {
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            var img = context.About.Select(x=>x.imageurl).FirstOrDefault();
            ViewBag.profileimg = img.ToString();
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
    }
}