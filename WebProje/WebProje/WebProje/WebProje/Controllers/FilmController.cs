using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models.EntityFramework;

namespace WebProje.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        VeritabanıEntities1 db = new VeritabanıEntities1();
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
            db.FILMLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Kategoriler","Home");
        }
    }
}