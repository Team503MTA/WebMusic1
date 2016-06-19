using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult UploadMusic()
        {
            ViewBag.listArtist = db.ARTISTs.Select(p=>p.NAME).ToList();

            return View();
        }

        public ActionResult UploadArtistLabel()
        {
            return View();
        }
    }
}