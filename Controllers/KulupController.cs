using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KulupController : Controller
    {
        MvcOkulEntities db = new MvcOkulEntities();
        public ActionResult Index()
        {
            var kulup = db.TblKulup.ToList();
            return View(kulup);
        }


        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TblKulup kulup)
        {
            db.TblKulup.Add(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TblKulup.Find(id);
            db.TblKulup.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TblKulup.Find(id);
            return View("KulupGetir",kulup);
        }

        public ActionResult Guncelle(TblKulup kulup)
        {
            var klp = db.TblKulup.Find(kulup.Id);
            klp.Ad = kulup.Ad;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulup");
        }
    }
}