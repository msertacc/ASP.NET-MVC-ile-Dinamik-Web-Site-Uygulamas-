using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebProje.Controllers
{
    public class LanguageController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(String LanguageAbbravation)
        {
            if (LanguageAbbravation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbravation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbravation);

            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbravation;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
    }
}