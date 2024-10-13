using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult Index()
        {
            var values = context.Profile.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var value = context.Profile.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            var value = context.Profile.Find(profile.profileID);
            value.title = profile.title;
            value.description = profile.description;
            value.address = profile.address;
            value.email = profile.email;
            value.phoneNumber = profile.phoneNumber;
            value.github = profile.github;
            value.imageurl = profile.imageurl;
            value.mapLocation = profile.mapLocation;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}