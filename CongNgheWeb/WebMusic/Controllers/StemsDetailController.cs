using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace MusicWeb.Controllers
{
    public class StemsDetailController : Controller
    {
        //
        // GET: /StemsDetail/
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

        public PartialViewResult StemsDetailPartial(int id)
        {
            var st = _db.STEMs.Where(p => p.STEMS_ID == id).Select(p => p.ID).ToList();
            List<string> art = new List<string>();
            List<string> lbl = new List<string>();
            foreach (var item in st)
            {
                var a = _db.STEM_ARTIST.Where(p => p.STEM_ID == item).Select(p => p.ARTIST_NAME).FirstOrDefault();
                if (Check(art, a) == true)
                    art.Add(a);
                var l = _db.STEM_ARTIST.Where(p => p.STEM_ID == item).Select(p => p.NAME_LABEL).FirstOrDefault();
                if (Check(lbl, l) == true)
                    lbl.Add(l);
            }
            ViewBag.lbl = lbl;
            ViewBag.art = art;
            return PartialView(_db.STEMS1.SingleOrDefault(p => p.STEMS_ID == id));
        }

        public PartialViewResult StemDetailPartial(int id)
        {
            List<STEM> tem = new List<STEM>();
            List<string> art = new List<string>();
            List<string> lbl = new List<string>();
            tem = _db.STEMs.Where(p => p.STEMS_ID == id).ToList();
            foreach (var item in tem)
            {
                var a = _db.STEM_ARTIST.Where(p => p.STEM_ID == item.ID).Select(p => p.ARTIST_NAME).FirstOrDefault();
                var l = _db.STEM_ARTIST.Where(p => p.STEM_ID == item.ID).Select(p => p.NAME_LABEL).FirstOrDefault();
                if (Check(art, a))
                    art.Add(a);
                if (Check(lbl, l))
                    lbl.Add(l);
            }
            ViewBag.quantum = tem.Count;
            ViewBag.art = art;
            ViewBag.lbl = lbl;
            return PartialView(tem);
        }
    }
}
