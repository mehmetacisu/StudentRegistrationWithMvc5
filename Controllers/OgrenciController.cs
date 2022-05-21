using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        MvcOkulEntities db = new MvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenci = db.TblOgrenci.ToList();
            return View(ogrenci);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> kulupler = (from x in db.TblKulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Ad,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.kulup = kulupler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TblOgrenci ogrenci)
        {
            var klp = db.TblKulup.Where(x => x.Id == ogrenci.TblKulup.Id).FirstOrDefault();
            ogrenci.TblKulup = klp;
            db.TblOgrenci.Add(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogr = db.TblOgrenci.Find(id);
            db.TblOgrenci.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TblOgrenci.Find(id);
            List<SelectListItem> kulupler = (from x in db.TblKulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Ad,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.kulup = kulupler;
            return View("OgrenciGetir",ogrenci);
        }
        

        public ActionResult Guncelle(TblOgrenci ogrenci)
        {
            var ogr = db.TblOgrenci.Find(ogrenci.Id);
            ogr.Ad = ogrenci.Ad;
            ogr.Soyad = ogrenci.Soyad;
            ogr.Fotograf = ogrenci.Fotograf;
            ogr.Cinsiyet = ogrenci.Cinsiyet;
            ogr.Kulup = ogrenci.TblKulup.Id;
            db.SaveChanges();
            return RedirectToAction("Index","Ogrenci");
        }
    }
}
