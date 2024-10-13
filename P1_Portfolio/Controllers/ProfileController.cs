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
            // Veritabanındaki Profiller ve Sosyal Medya hesaplarını çekiyoruz
            var profiles = context.Profile.ToList();
            var socialMedias = context.SocialMedia.ToList();

            // ViewModel oluşturup, verileri ViewModel'e atıyoruz
            var viewModel = new ProfileSocialMediaViewModel
            {
                Profiles = profiles,
                SocialMedias = socialMedias
            };

            return View(viewModel);
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
        public ActionResult SocialMedia()
        {
            var socialMedias = context.SocialMedia.ToList();
            return View(socialMedias);
        }
        public ActionResult SMediaStatusChangeToTrue(int id) 
        {
            var value = context.SocialMedia.Where(x => x.socialMediaID == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMedia");
        }
        public ActionResult SMediaStatusChangeToFalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.socialMediaID == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMedia");

        }
        [HttpGet]
        public ActionResult EditSM(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditSM(SocialMedia sm)
        {
            var value = context.SocialMedia.Find(sm.socialMediaID);
            value.Title = sm.Title;
            value.URL = sm.URL;
            value.Icon = sm.Icon;
            context.SaveChanges();
            return RedirectToAction("SocialMedia");
        }
    }
}