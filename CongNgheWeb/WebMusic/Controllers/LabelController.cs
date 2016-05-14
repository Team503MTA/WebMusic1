using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class LabelController : Controller
    {
        MusicEntities db = new MusicEntities();

        // GET: Label
        public ActionResult Index(string name)
        {
            return View(db.LABELs.Where(p => p.NAME == name).Select(p => p.ID).FirstOrDefault());
        }

        public PartialViewResult Detail(Int16 id)
        {

            LABEL lb = db.LABELs.FirstOrDefault(p => p.ID == id);

            ViewBag.InfoLabel = db.GENRE_LABEL.Where(p => p.ID_LABEL == id).OrderByDescending(p => p.POINT).Select(p => p.NAME_GENRE).Take(3).ToList();

            return PartialView(lb);
        }

        public PartialViewResult Artist_Label(Int16 id)
        {

            return PartialView(
                db.ARTISTs.Where(p=>p.ID_LABEL==id).OrderByDescending(p=>p.POINT_ALL).ToList()
            );
        }

        public PartialViewResult Track_Label(Int16 id)
        {
            string temp = db.LABELs.Where(p => p.ID == id).Select(p => p.NAME).FirstOrDefault();
            List<int> tempInt = db.TRACK_ARTIST.Where(p => p.NAME_LABEL == temp).OrderByDescending(p => p.POINT_ALL).Select(p=>p.ID_TRACK).Take(10).ToList();
            tempInt = tempInt.Distinct().ToList();

            List<TRACK> tracks = new List<TRACK>();
            List<List<List<string>>> Info = new List<List<List<string>>>();

            foreach (int item in tempInt)
            {
                tracks.Add(db.TRACKs.Where(p=>p.ID==item).FirstOrDefault());
                Info.Add(new List<List<string>>() {db.TRACK_ARTIST.Where(p=>p.ID_TRACK==item).Select(p=>p.NAME_ARTIST).ToList() , db.TRACK_ARTIST.Where(p => p.ID_TRACK == item).Select(p => p.NAME_LABEL).ToList() });
            }

            ViewBag.Info = Info;

            return PartialView(tracks);
        }
    }
}