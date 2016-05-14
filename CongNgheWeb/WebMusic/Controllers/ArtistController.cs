using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class ArtistController : Controller
    {
        MusicEntities db = new MusicEntities();

        // GET: Artist
        public ActionResult Index(string artistName)
        {
            return View(db.ARTISTs.Where(p=>p.NAME==artistName).Select(p=>p.ID).SingleOrDefault());
        }

        public PartialViewResult Detail_Artist(int id)
        {
            ViewBag.GenreArtist = db.GENRE_ARTIST.Where(p => p.ID_ARTIST == id).OrderByDescending(p=>p.POINT).Select(p => p.NAME_GENRE).Take(3).ToList();
            return PartialView(db.ARTISTs.Where(p => p.ID == id).SingleOrDefault());
        }

        public PartialViewResult Total_Track_Artist(int id)
        {

            List<List<List<string>>> trackTotal = new List<List<List<string>>>();


            List<int> idTrack = db.TRACK_ARTIST.Where(p => p.ID_ARTIST == id).Select(p=>p.ID_TRACK).ToList();
            List<TRACK> track = db.TRACKs.Where(p => idTrack.Contains(p.ID)).OrderByDescending(p=>p.POINT_ALL).Take(10).ToList();
            foreach (var item in track)
            {

                List<List<string>> temp = new List<List<string>>();
                temp.Add(new List<string>() { item.ID.ToString() , item.LINK , item.NAME , item.GENRE , item.TEMPO.ToString() , item.KEY_ , item.LENGTH , item.COST.ToString()});
                temp.Add(db.TRACK_ARTIST.Where(p=>p.ID_TRACK==item.ID).Select(p=>p.NAME_ARTIST).ToList());
                trackTotal.Add(temp);

            }

            ViewBag.TrackTotal = trackTotal;

            return PartialView();
        }

        public PartialViewResult Hot_Remix(int id)
        {
            List<int> idRemix = db.REMIX_ARTIST.Where(p => p.ID_ARTIST == id).Distinct().Select(p => p.ID_REMIX).ToList();
            List<REMIX> listRemix = db.REMIXes.Where(p => idRemix.Contains(p.ID)).OrderByDescending(p=>p.POINT_ALL).Take(10).ToList();
            List<List<List<string>>> Detail = new List<List<List<string>>>();

            foreach(var item in listRemix)
            {
                List<List<string>> temp = new List<List<string>>();
                temp.Add(db.REMIX_ARTIST.Where(p => p.ID_REMIX == item.ID).Select(p => p.NAME_ARTIST).ToList());
                temp.Add(db.REMIX_ARTIST.Where(p => p.ID_REMIX == item.ID).Select(p => p.NAME_LABEL).ToList());
                Detail.Add(temp);
            }

            ViewBag.Detail = Detail;
            return PartialView(listRemix);
        }

        public PartialViewResult Hot_Track_Label(int id)
        {

            string nameLabel = db.TRACK_ARTIST.Where(p => p.ID_ARTIST == id).Select(p => p.NAME_LABEL).FirstOrDefault();
            List<int> idTrack = db.TRACK_ARTIST.Where(p => p.NAME_LABEL == nameLabel).OrderByDescending(p => p.POINT_ALL).Take(15).Distinct().Select(p => p.ID_TRACK).ToList();
            List<TRACK> listTrack = db.TRACKs.Where(p => idTrack.Contains(p.ID)).ToList();
            List<List<List<string>>> Info = new List<List<List<string>>>();

            foreach(var item in listTrack)
            {
                List<List<string>> temp = new List<List<string>>();
                temp.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == item.ID).Select(p => p.NAME_ARTIST).ToList());
                temp.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == item.ID).Distinct().Select(p => p.NAME_LABEL).ToList());
                Info.Add(temp);
            }

            ViewBag.Info = Info;

            return PartialView(listTrack);
        }

    }
}