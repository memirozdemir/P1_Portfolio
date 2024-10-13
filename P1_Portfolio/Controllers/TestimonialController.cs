using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        MyPortfolioDBEntities context=new MyPortfolioDBEntities();
        public ActionResult TestimonialList()
        {
            var value = context.Testimonial.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            context.Testimonial.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonial.Find(testimonial.testimonialID);
            value.name = testimonial.name;
            value.title = testimonial.title;
            value.comment = testimonial.comment;
            value.imageUrl = testimonial.imageUrl;

            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}