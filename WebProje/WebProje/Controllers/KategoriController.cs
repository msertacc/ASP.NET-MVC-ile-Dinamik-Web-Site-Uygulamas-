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
        VeritabanıEntitiess db = new VeritabanıEntitiess();
        public ActionResult Index()
        {
            var veri = db.KATEGORILER.ToList();
            return View(veri);
            
        }

        [Authorize(Roles="True")]
        public ActionResult Sil(int id)
        {
            var silKategori = db.KATEGORILER.Find(id);
            db.KATEGORILER.Remove(silKategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "True")]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "True")]
        public ActionResult Ekle(KATEGORILER k)
        {
            db.KATEGORILER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index","Kategori");
        }

        [Authorize(Roles = "True")]
        public ActionResult Guncelle(KATEGORILER p)
        {
            var ktg = db.KATEGORILER.Find(p.KATEGORIID);
            ktg.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.KATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }
        

        public ActionResult KategoriFilmGetir(int id)
        {
            var degerler = db.FILMLER.Where(x => x.KATEGORIID == id).ToList();
            return View(degerler);
        }

        public ActionResult YorumlaraGit(int id)
        {
            var degerler = db.YORUMLAR.Where(x => x.YORUMFILMID == id).ToList();
            return View(degerler);
        }
        [Authorize(Roles = "True")]

        public ActionResult YorumSil(int id)
        {
            var silYorum = db.YORUMLAR.Find(id);
            db.YORUMLAR.Remove(silYorum);
            db.SaveChanges();
            return RedirectToAction("Kategoriler", "Home"); 
        }
    }
}