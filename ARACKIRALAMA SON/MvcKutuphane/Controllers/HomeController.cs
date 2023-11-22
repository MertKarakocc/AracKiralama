using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Deneme()
        {
            return View();
        }
        ARACEntities db = new ARACEntities();
        [HttpGet]
        public ActionResult Test2()
        {
             
            List<SelectListItem> deger1 = (from i in db.TBLMODEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MODELMARKA,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
    }
}