using mvc_firma_cagri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_firma_cagri.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        DbİsTakipEntities2 db = new DbİsTakipEntities2();
        public ActionResult AktifCagrilar()
        {
            var degerler = db.TblCagrilar
                             .Where(x => x.Durum == true)
                             .ToList();

            return View(degerler);
        }

        public ActionResult PasifCagrilar()
        {
            var degerler = db.TblCagrilar
                             .Where(x => x.Durum == false)
                             .ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCagri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCagri(TblCagrilar p)
        {
            p.Durum = true;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CagriFirma = 1;
            db.TblCagrilar.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult CagriSil(int id)
        {
            var cagrilar = db.TblCagrilar.Find(id);
            db.TblCagrilar.Remove(cagrilar);
            db.SaveChanges();
            return RedirectToAction("AktifCagrilar");
        }

        public ActionResult CagriGetir(int id)
        {
            var cagrilar = db.TblCagrilar.Find(id);
            return View("CagriGetir", cagrilar);
        }

        public ActionResult CagriGuncelle(TblCagrilar p)
        {
            var cgr = db.TblCagrilar.Find(p.ID);
            cgr.Konu = p.Konu;
            cgr.Aciklama = p.Aciklama;
            cgr.Durum = p.Durum;
            db.SaveChanges();
            return RedirectToAction("AktifCagrilar");
        }

        public ActionResult CagriDetay(int id)
        {
            var cagrilar = db.TblCagriDetay.Where(x => x.Cagri == id).ToList();
            return View(cagrilar);
        }
    }
}