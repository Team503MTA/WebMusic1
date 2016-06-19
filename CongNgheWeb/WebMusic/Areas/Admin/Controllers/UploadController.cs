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
            }
            else
            {
                Session["FileImg"] = file;
            }
        }

        public void AddNewTrack(MusicFileUpload obj)
        {
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
        }

        [HttpPost]
        public JsonResult UploadMusic_Full(MusicFileUpload obj)
        {
            var fileMusic = Session["FileMusic"] as HttpPostedFileBase;
            var fileImage = Session["FileImg"] as HttpPostedFileBase;

            if (fileMusic == null || fileImage == null)
            {
                return Json("0");
            }

            if (obj.TYPEMUSIC == "1")    //Track
            {
                var fileNameMusic = Path.GetFileName(fileMusic.FileName);
                string pathMusic = Path.Combine(Server.MapPath("~/music/"), fileNameMusic);
                fileMusic.SaveAs(pathMusic);

                
                var fileNameIMG = Path.GetFileName(fileImage.FileName);
                string pathIMG = Path.Combine(Server.MapPath("~/IMG/Track/Alesso/"), fileNameIMG);
                fileImage.SaveAs(pathIMG);

                
            }


            return Json("1");
        }

        public ActionResult UploadArtistLabel()
        {
            return View();
        }
    }
}