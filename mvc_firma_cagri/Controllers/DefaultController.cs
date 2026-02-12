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
        DbİsTakipEntities2 db= new DbİsTakipEntities2();
        public ActionResult AktifCagrilar()
        {
            var degerler = db.TblCagrilar
                             .Where(x => x.Durum.HasValue && x.Durum.Value)
                             .ToList();

            return View(degerler);
        }
    }
}