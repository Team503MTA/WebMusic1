using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace MusicWeb.Controllers
{
    public class SoundsController : Controller
    {
        //
        // GET: /Sounds/
        MusicEntities _db = new MusicEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult FeaturedPacksPartial()
        {
            var fp = _db.SOUNDS.Take(32).OrderByDescending(p => p.POINT_MONTH).ToList();
            List<string> lbl = new List<string>();
            foreach (var item in fp)
            {
                var label = _db.LABELs.Where(p => p.ID == item.LABEL_ID).Select(p => p.NAME).SingleOrDefault();
                lbl.Add(label);
            }
            ViewBag.lbl = lbl;
            return PartialView(fp);
        }

    }
}
