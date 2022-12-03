using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKitaplığım.Models;
using Microsoft.Ajax.Utilities;

namespace BenimKitaplığım.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DbKitapEntities1 db = new DbKitapEntities1();
        
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP t) {

            
            db.TBLKITAP.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id) {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult KitapGetir(int id) {
            var ktp = db.TBLKITAP.Find(id);
            return View("KitapGetir", ktp);
                }
        public ActionResult KitapGüncelle(TBLKITAP t)
        {
            var kitap = db.TBLKITAP.Find(t.KITAPID);
            kitap.AD = t.AD;
            kitap.YAZAR = t.YAZAR;
            kitap.SAYFA = t.SAYFA;
            kitap.KATEGORI = t.KATEGORI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kategoriler()
        {
            var kitaplar = db.TBLKATEGORİ.ToList();
            return View(kitaplar);
        }
        public ActionResult Hakkımızda()
        {
            return View();
        }

    }
}