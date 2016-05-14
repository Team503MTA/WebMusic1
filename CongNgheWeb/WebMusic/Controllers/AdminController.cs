using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace ASP_WebMusic.Controllers
{
    public class AdminController : Controller
    {

        MusicEntities db = new MusicEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        //Thêm Mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(TRACK track)
        {

            db.TRACKs.Add(track);
            db.SaveChanges();

            return View();
        }


        //Sửa
        [HttpGet]
        public ActionResult Sua()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sua(TRACK track)
        {
            db.TRACKs.Add(track);
            db.SaveChanges();
            return View();
        }


        //Xóa
        [HttpGet]
        public ActionResult Xoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Xoa(TRACK track)
        {
            db.TRACKs.Add(track);
            db.SaveChanges();
            return View();
        }
    }
}