using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProje.Models.EntityFramework;

namespace WebProje.Controllers
{
 
    public class SecurityController : Controller
    {
        // GET: Security
        VeritabanıEntities1 db = new VeritabanıEntities1();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(KULLANICILAR k)
        {
            var kullanici = db.KULLANICILAR.FirstOrDefault(x=>x.KULLANICIEMAIL == k.KULLANICIEMAIL && x.KULLANICISIFRE == k.KULLANICISIFRE);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KULLANICIEMAIL, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.mesaj = "geçersiz";
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}