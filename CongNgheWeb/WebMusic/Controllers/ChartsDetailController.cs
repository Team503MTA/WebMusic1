using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using WebMusic.Models;

namespace MusicWeb.Controllers
{
    public class ChartsDetailController : Controller
    {
        //
        // GET: /ChartsDetail/
        MusicEntities db = new MusicEntities();

        [HttpGet]
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

        public PartialViewResult ChartsDetailPartial(int id)
        {
            string g = db.CHARTs.Where(p => p.ID == id).Select(p => p.NAME_GENRE).SingleOrDefault();
            var i = db.TRACKs.Where(p => p.GENRE == g).OrderByDescending(p => p.POINT_MONTH).Select(p => p.LINK_IMG).FirstOrDefault();
            if (i == null)
            {
                i = "blank_artist.png";
            }
            ViewBag.img = i;
            return PartialView(db.CHARTs.Where(p=>p.ID==id).SingleOrDefault());
        }

        public PartialViewResult TracksDetailPartial(int id)
        {
            List<List<string>> lstart = new List<List<string>>();
            List<List<string>> lstlbl = new List<List<string>>();
            string g = db.CHARTs.Where(p => p.ID == id).Select(p => p.NAME_GENRE).FirstOrDefault();
            var t = db.TRACKs.Where(p => p.GENRE == g).Take(3).OrderByDescending(p => p.POINT_MONTH).ToList();
            ViewBag.quantum = t.Count;
            foreach (var i in t)
            {
                if (i.LINK_IMG == null)
                {
                    i.LINK_IMG = "blank_artist.png";
                }
                var tem = db.TRACK_ARTIST.Where(p => p.ID_TRACK == i.ID).Select(p => p.NAME_ARTIST).ToList();
                var temp = db.TRACK_ARTIST.Where(p => p.ID_TRACK == i.ID).Select(p => p.NAME_LABEL).ToList();
                lstart.Add(tem);
                lstlbl.Add(temp);
            }
            ViewBag.lbl = lstlbl;
            ViewBag.art = lstart;
            return PartialView(t);
        }
    }
}
