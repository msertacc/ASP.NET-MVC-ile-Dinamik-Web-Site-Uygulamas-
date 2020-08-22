using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebProje.Models.EntityFramework;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {

        VeritabanıEntitiess db = new VeritabanıEntitiess();

        public ActionResult Index()
        {
            var veriler = db.FILMLER.OrderByDescending(x=>x.FILMPUAN).ToList();
            veriler.RemoveRange(3, veriler.Count - 3);
            return View(veriler);
        }

        public ActionResult Sirala()
        {
            var veriler = db.FILMLER.OrderByDescending(x => x.FILMPUAN).ToList();
            return View(veriler);
        }
        
        public ActionResult Kategoriler()
        {
            var veriler = db.FILMLER.ToList();
            return View(veriler);
        }



        public ActionResult FilmGetir(int id)
        {
            var film = db.FILMLER.Find(id);

            List<SelectListItem> veriler = (from i in db.KATEGORILER.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.KATEGORIAD,
                                                Value = i.KATEGORIID.ToString()
                                            }).ToList();
            ViewBag.veri = veriler;



            return View("FilmGetir", film);
        }

        [Authorize(Roles = "True")]
        public ActionResult FilmSil(int id)
        {
            var filmSil = db.FILMLER.Find(id);
            db.FILMLER.Remove(filmSil);
            db.SaveChanges();
            return RedirectToAction("Kategoriler", "Home");
        }

        [Authorize(Roles = "True")]
        public ActionResult FilmGuncelle(FILMLER p)
        {
            var film = db.FILMLER.Find(p.FILMID);
            film.FILMAD = p.FILMAD;
            film.FILMPUAN = p.FILMPUAN;
            film.FILMYIL = p.FILMYIL;
            film.FILMFOTO = p.FILMFOTO;
            var yeni = db.KATEGORILER.Where(m => m.KATEGORIID == p.KATEGORILER.KATEGORIID).FirstOrDefault();
            film.KATEGORIID = yeni.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult YorumYap()
        {
            return View();
        }

        [Authorize(Roles = "True,False")]
        [HttpPost]
        public ActionResult YorumYap(YORUMLAR p1)
        {
            db.YORUMLAR.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Kategoriler","Home");
        }
    }
}