using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public PartialViewResult PartialContactSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContactAddress()
        {
            ViewBag.desc = context.Profile.Select(x=>x.description).FirstOrDefault();
            ViewBag.address = context.Profile.Select(x=>x.address).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x=>x.email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x=>x.phoneNumber).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialContactLocation()
        {
            ViewBag.mapLocation = context.Profile.Select(x=> x.mapLocation).FirstOrDefault();
            return PartialView();
        }
    }
}