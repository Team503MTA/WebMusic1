using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {

        MusicEntities db = new MusicEntities();

        // GET: Admin/Upload
        public ActionResult Index()
        {

            Session["FileMusic"] = null;
            Session["FileImg"] = null;

            return View();
        }

        [HttpGet]
        public ActionResult UploadMusic()
        {
            ViewBag.listArtist = new SelectList(db.ARTISTs, "ID", "NAME");
            ViewBag.listArtist1 = ViewBag.listArtist;
            ViewBag.listArtist2 = ViewBag.listArtist;
            ViewBag.listArtist3 = ViewBag.listArtist;
            ViewBag.upload_genre = new SelectList(db.GENREs, "ID", "NAME");

            return View();
        }

        [HttpPost]
        public void UploadMusic_File()
        {
            var file = Request.Files[0];

            if (file == null)
            {
                return;
            }

            if (file.ContentType == "audio/mp3")
            {
                Session["FileMusic"] = file;
                var fileNameMusic = Path.GetFileName(file.FileName);
                string pathMusic = Path.Combine(Server.MapPath("~/music/"), fileNameMusic);
                file.SaveAs(pathMusic);


                
            }
            else
            {
                Session["FileImg"] = file;
                var fileNameIMG = Path.GetFileName(file.FileName);
                string pathIMG = Path.Combine(Server.MapPath("~/IMG/Track/Alesso/"), fileNameIMG);
                file.SaveAs(pathIMG);
            }
        }

        public void AddNewTrack(MusicFileUpload obj,string fileNameMusic,string fileNameIMG)
        {

            //add track
            TRACK newTrack = new TRACK();
            newTrack.NAME = obj.NAME;
            newTrack.TEMPO = byte.Parse(obj.TEMPO);
            newTrack.KEY_ = obj.KEY;
            newTrack.COST = float.Parse(obj.COST);
            newTrack.LINK = "/music/" + fileNameMusic;
            newTrack.DATE_RELEASE = DateTime.Now;
            newTrack.LINK_IMG = "/IMG/Track/Alesso/" + fileNameIMG;
            newTrack.DESCRIPT = obj.DESCRIPTION;
            newTrack.POINT_ALL = 0;
            newTrack.POINT_MONTH = 0;

            //add full name
            var artist = obj.LISTARTIST.Split('.').ToList();
            artist = artist.Distinct().ToList();
            List<string> lstArtist = new List<string>();
            foreach (var item in artist)
            {
                if (item != null && item != "")
                {
                    var tempID = int.Parse(item);
                    lstArtist.Add(db.ARTISTs.FirstOrDefault(p=>p.ID== tempID).NAME);
                }
            }

            string fullname = obj.NAME + " - ";
            for (int i = 0; i < lstArtist.Count; i++)
            {
                fullname += lstArtist[i];
                if (i != lstArtist.Count - 1)
                {
                    fullname += " ft ";
                }
            }
            newTrack.FULL_NAME = fullname;

            short idGenre = short.Parse(obj.GENRE);

            string genre = db.GENREs.FirstOrDefault(p => p.ID == idGenre).NAME;
            newTrack.GENRE = genre;

            db.TRACKs.Add(newTrack);
            db.SaveChanges();

            //add track_artist
            TRACK maxTrack = db.TRACKs.OrderByDescending(p => p.ID).FirstOrDefault();
            for (int i = 0; i < lstArtist.Count; i++)
            {
                string sss = lstArtist[i];
                ARTIST tempArtist = db.ARTISTs.Where(p => p.NAME == sss).FirstOrDefault();
                if (tempArtist != null)
                {
                    TRACK_ARTIST newTrackArtist = new TRACK_ARTIST();
                    newTrackArtist.ID_TRACK = maxTrack.ID;
                    newTrackArtist.ID_ARTIST = tempArtist.ID;
                    newTrackArtist.NAME_ARTIST = tempArtist.NAME;
                    newTrackArtist.NAME_LABEL = tempArtist.NAME_LABEL;
                    newTrackArtist.COST = maxTrack.COST;
                    newTrackArtist.NAME_TRACK = maxTrack.NAME;
                    newTrackArtist.POINT_MONTH = 0;
                    newTrackArtist.POINT_ALL = 0;
                    newTrackArtist.GENRE = maxTrack.GENRE;
                    newTrackArtist.LINK_IMG = maxTrack.LINK_IMG;
                    newTrackArtist.POINT_DAY = 0;
                    db.TRACK_ARTIST.Add(newTrackArtist);
                    db.SaveChanges();
                }
            }

            //add statistic_track
            STATISTIC_TRACK sttTrack = new STATISTIC_TRACK();
            sttTrack.ID = maxTrack.ID;
            sttTrack.CLICK_ALL = 0;
            sttTrack.CLICK_MONTH = 0;
            sttTrack.BUY_ALL = 0;
            sttTrack.BUY_MONTH = 0;
            db.STATISTIC_TRACK.Add(sttTrack);
            db.SaveChanges();

        }

        [HttpPost]
        public JsonResult UploadMusic_Full(MusicFileUpload obj)
        {
            var fileMusic = Session["FileMusic"] as HttpPostedFileBase;
            var fileImage = Session["FileImg"] as HttpPostedFileBase;
            var fileNameMusic = Path.GetFileName(fileMusic.FileName);
            var fileNameIMG = Path.GetFileName(fileImage.FileName);

            if (fileMusic == null || fileImage == null)
            {
                return Json("0");
            }

            if (obj.TYPEMUSIC == "1")    //Track
            {
                AddNewTrack(obj, fileNameMusic, fileNameIMG);

                return Json("1");
            }


            return Json("1");
        }

        public ActionResult UploadArtistLabel()
        {
            return View();
        }
    }
}