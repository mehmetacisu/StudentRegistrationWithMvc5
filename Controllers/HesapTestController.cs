using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class HesapTestController : Controller
    {
        public ActionResult Index(double sayi1 = 0,double sayi2 = 0)
        {
            double toplam = sayi1 + sayi2;
            double cikarma = sayi1 - sayi2;
            double bolme = sayi1 / sayi2;
            double carpma = sayi1 * sayi2;
            ViewBag.toplam = toplam;
            ViewBag.cikarma = cikarma;
            ViewBag.bolme = bolme;
            ViewBag.carpma = carpma;
            return View();
        }
    }
}