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
        // GET: Film
        VeritabanıEntities2 db = new VeritabanıEntities2();
        public ActionResult Index()
        {
            var veriler = db.FILMLER.ToList();

            return View(veriler);
        }

        [HttpGet]
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