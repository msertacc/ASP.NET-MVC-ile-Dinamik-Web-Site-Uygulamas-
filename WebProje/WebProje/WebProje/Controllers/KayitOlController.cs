using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models.EntityFramework;

namespace WebProje.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl


        VeritabanıEntitiess db = new VeritabanıEntitiess();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Kayit()
        {
            return View("Kayit",new KULLANICILAR());

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Kayit(KULLANICILAR p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            var kontrol = db.KULLANICILAR.Where(x => x.KULLANICIEMAIL == p1.KULLANICIEMAIL).Count();
            if(kontrol == 0)
            {
                p1.KULLANICITIP = false;
                db.KULLANICILAR.Add(p1);
                db.SaveChanges();
                TempData["Success"] = "Uye Olma Islemi Basarılı!";
                return RedirectToAction("Login", "Security");

            }
            else
            {
                TempData["Crash"] = "Uye Olma Islemi Basarısız! Bu e-maile ait kullanici bulunuyor. ";
                return View("Kayit");
            }
            
        }
    }
}