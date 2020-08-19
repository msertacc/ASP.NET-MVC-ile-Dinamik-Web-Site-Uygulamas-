using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models.EntityFramework;

namespace WebProje.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        VeritabanıEntities2 db = new VeritabanıEntities2();
        public ActionResult Index()
        {
            var veri = db.KATEGORILER.ToList();
            return View(veri);
            
        }

        public ActionResult Sil(int id)
        {
            var silKategori = db.KATEGORILER.Find(id);
            db.KATEGORILER.Remove(silKategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(KATEGORILER k)
        {
            db.KATEGORILER.Add(k);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.KATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(KATEGORILER p)
        {
            var ktg = db.KATEGORILER.Find(p.KATEGORIID);
            ktg.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriFilmGetir(int id)
        {
            var degerler = db.FILMLER.Where(x => x.KATEGORIID == id).ToList();
            return View(degerler);
        }
    }
}