using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class AracController : Controller
    {
        // GET: Kitap
        ARACEntities db = new ARACEntities();
        public ActionResult Index(string p)
        {
            var araclar = from k in db.TBLARACLAR select k;
            if (!string.IsNullOrEmpty(p))
            {
                araclar = araclar.Where(m => m.PLAKA.Contains(p));
            }
            // var kitaplar = db.TBLARACLAR.ToList();
            return View(araclar.ToList());
        }
        [HttpGet]
        public ActionResult AracEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLMODEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MODELMARKA,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAKIT.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.YAKIT ,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult AracEkle(TBLARACLAR p)
        {
            var ktg = db.TBLMODEL.Where(k => k.ID == p.TBLMODEL.ID).FirstOrDefault();
            var yzr = db.TBLYAKIT.Where(y => y.ID == p.TBLYAKIT.ID).FirstOrDefault();
            p.TBLMODEL = ktg;
            p.TBLYAKIT = yzr;
            db.TBLARACLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AracSil(int id)
        {
            var arac = db.TBLARACLAR.Find(id);
            db.TBLARACLAR.Remove(arac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AracGetir(int id)
        {
            var ktp = db.TBLARACLAR.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLMODEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MODELMARKA,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAKIT.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.YAKIT,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("AracGetir", ktp);
        }
        public ActionResult AracGuncelle(TBLARACLAR p)
        {
            var Arac = db.TBLARACLAR.Find(p.ID);
            Arac.PLAKA = p.PLAKA;
            Arac.YIL = p.YIL;
            Arac.KIRAFIYATI = p.KIRAFIYATI;
            Arac.RENK = p.RENK;
            Arac.DURUM = true;
            var mdl = db.TBLMODEL.Where(k => k.ID == p.TBLMODEL.ID).FirstOrDefault();
            var ykt = db.TBLYAKIT.Where(y => y.ID == p.TBLYAKIT.ID).FirstOrDefault();
            Arac.MODELMARKA = mdl.ID;
            Arac.YAKIT = ykt.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}