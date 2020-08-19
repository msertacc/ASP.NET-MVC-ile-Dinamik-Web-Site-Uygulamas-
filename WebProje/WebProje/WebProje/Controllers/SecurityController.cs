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
        VeritabanıEntities2 db = new VeritabanıEntities2();
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
                Session["user"] = kullanici.KULLANICIID;
                Session["uyetip"] = kullanici.KULLANICITIP == true ? "Admin " : "Üye";
                Session["uyead"] = kullanici.KULLANICIAD;
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.mesaj = "Geçersiz kullanıcı adı veya şifre girildi.";
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