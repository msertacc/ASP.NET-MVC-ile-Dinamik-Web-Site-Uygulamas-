using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models.EntityFramework;

namespace WebProje.Controllers
{
    public class FilmController : Controller
    {
        VeritabanıEntitiess db = new VeritabanıEntitiess();

        public ActionResult Index()
        {
            var veriler = db.FILMLER.ToList();

            return View(veriler);
        }

        [HttpGet]
        [Authorize(Roles = "True")]
        public ActionResult Yeni()
        {
            List<SelectListItem> veriler = (from i in db.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.veri = veriler;
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "True")]
        public ActionResult Yeni(FILMLER p1)
        {       
            var yeni = db.KATEGORILER.Where(m => m.KATEGORIID == p1.KATEGORILER.KATEGORIID).FirstOrDefault();
            p1.KATEGORILER = yeni;
            db.FILMLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Kategoriler","Home");
        }
        

        
    }
}