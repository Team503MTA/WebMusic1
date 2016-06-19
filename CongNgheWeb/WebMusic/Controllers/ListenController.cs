using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class ListenController : Controller
    {
        //
        // GET: /Listen/
        MusicEntities db = new MusicEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SliderListen()
        {
            var lstSliderListen = db.LISTEN_SLIDER.Take(9).ToList();
            return PartialView(lstSliderListen);
        }

        public PartialViewResult ThePulesChart()
        {
            var lstThePulesChart = db.TRACK_ARTIST.OrderByDescending(p => p.COST).Take(10).ToList();
            return PartialView(lstThePulesChart);
        }
        public PartialViewResult DailyRotation()
        {
            var lstDailyRotation = db.TRACK_ARTIST.OrderByDescending(p => p.POINT_DAY).Take(12).ToList();
            return PartialView(lstDailyRotation);
        }

        public PartialViewResult HotPlayList()
        {
            var lstHotPlayList = db.TRACKs.OrderByDescending(p => p.POINT_MONTH).Take(6).ToList();
            return PartialView(lstHotPlayList);
        }

        public PartialViewResult Staffpick()
        {
            var lstStaffpick = db.TRACK_ARTIST.Take(9).ToList();
            return PartialView(lstStaffpick);
        }
        public PartialViewResult FeatureArtist()
        {
            var lstFeatureArtist = db.ARTISTs.OrderByDescending(p => p.POINT_MONTH).Take(8).ToList();
            return PartialView(lstFeatureArtist);
        }
        // Chi tiet slider listen

        public ViewResult DetailsSliderListen(int ID = 0)
        {
            LISTEN_SLIDER sliderListen = db.LISTEN_SLIDER.SingleOrDefault(n => n.ID == ID);
            if (sliderListen == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sliderListen);

        }
    }
}