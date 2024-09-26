using P1_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
        MyPortfolioDBEntities context = new MyPortfolioDBEntities();
        public ActionResult Index()
        {
            int messageCount = context.Message.Count();
            int messageCountIsReadByTrue = context.Message.Where(x=>x.isRead==true).Count();
            int messageCountIsReadByFalse = context.Message.Where(x => x.isRead == false).Count();
            int skillCount = context.Skill.Count();
            var totalSkillValue = context.Skill.Sum(x=>x.value);
            var avgSkillValue = context.Skill.Average(x=>x.value);
            var getEmailFromProfile = context.Profile.Select(x=>x.email).FirstOrDefault();
            int getLastCategoryID = context.Category.Max(x => x.categoryID);
            var getLastCategoryName = context.Category.Where(x=>x.categoryID==getLastCategoryID).Select(y=>y.categoryName).FirstOrDefault();
            
            ViewBag.messageCount = messageCount;
            ViewBag.messageCountIsReadByTrue = messageCountIsReadByTrue;
            ViewBag.messageCountIsReadByFalse = messageCountIsReadByFalse;
            ViewBag.skillCount = skillCount;
            ViewBag.totalSkillValue = totalSkillValue;
            ViewBag.avgSkillValue = avgSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategoryName = getLastCategoryName;

            return View();
        }
    }
}