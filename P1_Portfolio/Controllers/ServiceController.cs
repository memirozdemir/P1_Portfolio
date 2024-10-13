using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult ServiceList()
        {
            var value = context.Service.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Service service)
        {
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var value = context.Service.Find(id);
            context.Service.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Service.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Service.Find(service.serviceID);
            value.title = service.title;
            value.description = service.description;
            value.icon = service.icon;
            
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}