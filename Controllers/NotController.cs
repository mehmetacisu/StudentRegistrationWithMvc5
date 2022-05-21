using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;
namespace OgrenciNotMvc.Controllers
{
    public class NotController : Controller
    {
        MvcOkulEntities db = new MvcOkulEntities();
        public ActionResult Index()
        {
            var not = db.TblNot.ToList();
            return View(not);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(TblNot not)
        {
            db.TblNot.Add(not);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var not = db.TblNot.Find(id);
            return View("NotGetir",not);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model,TblNot not,int vize=0,int final=0,int but=0,int proje=0)
        {
            if (model.islem == "Hesapla")
            {
                int ortalama = (vize + final + but + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem =="NotGuncelle")
            {
                var snv = db.TblNot.Find(not.Id);
                snv.Vize = not.Vize;
                snv.Final = not.Final;
                snv.But = not.But;
                snv.Proje = not.Proje;
                snv.Ortalama = not.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index","Not");
            }
            return View();
        }
    }
}