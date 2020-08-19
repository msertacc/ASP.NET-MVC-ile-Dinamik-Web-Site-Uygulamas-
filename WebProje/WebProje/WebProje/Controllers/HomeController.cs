using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebProje.Models.EntityFramework;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        VeritabanıEntities2 db = new VeritabanıEntities2();

        
        public ActionResult Index()
        {
            var veriler = db.FILMLER.OrderByDescending(x=>x.FILMPUAN).ToList();

            veriler.RemoveRange(3, veriler.Count - 3);
            
            return View(veriler);
        }
        [Route("Editor")]
        public ActionResult Sirala()
        {
            var veriler = db.FILMLER.OrderByDescending(x => x.FILMPUAN).ToList();
            return View(veriler);
        }
        [Route("Kategoriler")]
        public ActionResult Kategoriler()
        {
            var veriler = db.FILMLER.ToList();

            return View(veriler);
        }

        public ActionResult FilmSil(int id)
        {
            var filmSil = db.FILMLER.Find(id);
            db.FILMLER.Remove(filmSil);
            db.SaveChanges();
            return RedirectToAction("Index");
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

        //public ActionResult FilmYorumla()
        //{

        //}

        [HttpGet]
        public ActionResult YorumYap()
        {
            return View();
        }



        [HttpPost]
        public ActionResult YorumYap(YORUMLAR p1)
        {
            db.YORUMLAR.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}