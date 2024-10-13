using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult CategoryList()
        {
            var values=context.Category.ToList();
            return View(values);
        }
        public ActionResult CreateCategory() 
        { 
            return View();
        }
        public ActionResult UpdateCategory()
        {
            return View();
        }
        public ActionResult CategoryStatusChangeToTrue(int id)
        {
            var value = context.Category.Where(x => x.categoryID == id).FirstOrDefault();
            value.categoryStatus = true;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult CategoryStatusChangeToFalse(int id)
        {
            var value = context.Category.Where(x => x.categoryID == id).FirstOrDefault();
            value.categoryStatus = false;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Category.Find(id);
            context.Category.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}