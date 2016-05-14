using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;
namespace WebMusic.Controllers
{
    public class ShowController : Controller
    {
        //
        // GET: /Show/

        MusicEntities db = new MusicEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SliderShow()
        {
            var lstSliderShow = db.SHOWs.Take(5).ToList();
            return PartialView(lstSliderShow);
        }

        public PartialViewResult ListShow()
        {
            var lstListShow = db.SHOW_LIST.Take(9).ToList();
            return PartialView(lstListShow);
        }
        //Action Xem chi tiet
        public ViewResult XemChiTiet(int ID = 0)
        {
            SHOW show = db.SHOWs.SingleOrDefault(n => n.ID == ID);
            if (show == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(show);
        }
        public ViewResult DetailListShow(int ID = 0)
        {
            SHOW_LIST showlist = db.SHOW_LIST.SingleOrDefault(n => n.ID == ID);
            if (showlist == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(showlist);
        }
    }
}