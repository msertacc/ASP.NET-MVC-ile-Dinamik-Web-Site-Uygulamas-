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


        VeritabanıEntities2 db = new VeritabanıEntities2();

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
            p1.KULLANICITIP = false;
            db.KULLANICILAR.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Login", "Security");
        }
    }
}