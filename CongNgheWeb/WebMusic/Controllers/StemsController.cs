using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace MusicWeb.Controllers
{
    public class StemsController : Controller
    {
        //
        // GET: /Stems/
        MusicEntities _db = new MusicEntities();

        public ActionResult Index()
        {
            return View();
        }

        public bool Check(List<string> lst, string str)
        {
            foreach (string t in lst)
            {
                if (t == str)
                    return false;
            }
            return true;
        }

        public PartialViewResult NewStemsPartial()
        {
            var sts = _db.STEMS1.Select(p => p.STEMS_ID).ToList();
            List<List<string>> lstart = new List<List<string>>();
            List<string> lbl = new List<string>();
            foreach (var item in sts)
            {
                List<string> art = new List<string>();
                var st = _db.STEMs.Where(p => p.STEMS_ID == item).Select(p => p.ID).ToList();
                foreach (var it in st)
                {
                    var a = _db.STEM_ARTIST.Where(p => p.STEM_ID == it).Select(p => p.ARTIST_NAME).FirstOrDefault();
                    var b = _db.STEM_ARTIST.Where(p => p.STEM_ID == it).Select(p => p.NAME_LABEL).FirstOrDefault();
                    if (Check(art, a) == true)
                        art.Add(a);
                    if (Check(lbl, b) == true)
                        lbl.Add(b);
                }
                lstart.Add(art);
            }
            ViewBag.art = lstart;
            ViewBag.lbl = lbl;
            return PartialView(_db.STEMS1.ToList());
        }

        public PartialViewResult SliderStemsPartial()
        {
            return PartialView(_db.GENREs.ToList());
        }

    }
}
