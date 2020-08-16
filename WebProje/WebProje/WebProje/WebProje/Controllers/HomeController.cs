using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebProje.Models.EntityFramework;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        VeritabanıEntities1 db = new VeritabanıEntities1();
       
        public ActionResult Index()
        {
            return View();
        }
        [Route("Editor")]
        public ActionResult Editor()
        {
            return View();
        }
        [Route("Kategoriler")]
        public ActionResult Kategoriler()
        {
            var veriler = db.FILMLER.ToList();

            return View(veriler);
        }
        [Route("Giris")]
        public ActionResult Giris()
        {
            return View();
        }
    }
}