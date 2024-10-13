using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P1_Portfolio.Models;

namespace P1_Portfolio.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult EducationList()
        {
            var values = context.Education.ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = context.Education.Find(id);
            context.Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = context.Education.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var value = context.Education.Find(education.educationID);
            value.title = education.title;
            value.educationDate = education.educationDate;
            value.subtitle = education.subtitle;
            value.description = education.description;
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}