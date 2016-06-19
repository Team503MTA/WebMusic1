using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ViewBag.listArtist = new SelectList(db.ARTISTs,"ID","NAME");
            ViewBag.listArtist1 = ViewBag.listArtist;
            ViewBag.listArtist2 = ViewBag.listArtist;
            ViewBag.listArtist3 = ViewBag.listArtist;
            ViewBag.genre = new SelectList(db.GENREs,"ID","NAME");

            return View();
        }

        [HttpPost]
        public JsonResult UploadMusic_File()
        {
            var file = Request.Files[0];

            if (file.ContentType == "audio/mp3")
            {
                Session["FileMusic"] = file;
            }else
            {
                Session["FileImg"] = file;
            }

            return Json("1");
        }

        public ActionResult UploadArtistLabel()
        {
            return View();
        }
    }
}