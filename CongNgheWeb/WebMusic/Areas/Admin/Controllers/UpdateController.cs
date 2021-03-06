﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Areas.Admin.Controllers
{
    public class UpdateController : Controller
    {
        MusicEntities db = new MusicEntities();
        // GET: Admin/Update
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Login(string username, string password)
        {
            var user = db.AccountAdmins.FirstOrDefault(p => p.USERNAME == username && p.PASSWORD == password);
            if (user == null)
            {
                return Json("0");
            }
            return Json("1");
        }

        //update NEW TRACK
        public JsonResult update_NewTrack()
        {
            db.NEW_TRACK.RemoveRange(db.NEW_TRACK.ToList());
            db.SaveChanges();

            var temp = db.TRACKs.OrderByDescending(p => p.DATE_RELEASE).Take(56).ToList();
            byte rank = 1;
            foreach (var item in temp)
            {
                NEW_TRACK track = new NEW_TRACK();
                track.ID = item.ID;
                track.NAME = item.NAME;
                track.COST = item.COST;
                track.LINK = item.LINK;
                track.LINK_IMG = item.LINK_IMG;
                track.RANKK = rank++;
                db.NEW_TRACK.Add(track);
            }
            db.SaveChanges();
            var hisUp = db.HISTORY_UPDATE.FirstOrDefault(p => p.TYPE == "NEW_TRACK");
            hisUp.LASTTIME = DateTime.Now.Date;
            db.SaveChanges();

            return Json("1");
        }

        //update Statistic
        public void update_Statistic()
        {
            var hisUp = db.HISTORY_UPDATE.FirstOrDefault(p => p.TYPE == "STATISTIC");
            if (hisUp.LASTTIME.Value.Month == DateTime.Now.Month)
            {
                return;
            }
            hisUp.LASTTIME = DateTime.Now.Date;
            db.SaveChanges();

            //update statistic track
            var statisticTrack = db.STATISTIC_TRACK.ToList();
            foreach (var item in statisticTrack)
            {
                item.CLICK_MONTH = 0;
                item.BUY_MONTH = 0;
            }
            db.SaveChanges();

            //update statistic remix
            var statisticRemix = db.STATISTIC_REMIX.ToList();
            foreach (var item in statisticRemix)
            {
                item.CLICK_MONTH = 0;
                item.BUY_MONTH = 0;
            }
            db.SaveChanges();
        }

        //update trackandRemix
        public JsonResult update_Track_Remix()
        {
            update_Statistic();
            var hisUp = db.HISTORY_UPDATE.FirstOrDefault(p => p.TYPE == "POINT_TRACK_REMIX");
            hisUp.LASTTIME = DateTime.Now.Date;
            db.SaveChanges();

            var Calcu = db.FORMULA_HOT.FirstOrDefault();

            //update TRACK   ( update TABLE TRACK AND TRACK_ARTIST )
            var lstTrack = db.TRACKs.ToList();
            var lstTrackArtist = db.TRACK_ARTIST.ToList();
            var lstStatisticTrack = db.STATISTIC_TRACK.ToList();
            var temp = 0.1;
            foreach (var item in lstTrack)
            {
                var tempStatis = lstStatisticTrack.FirstOrDefault(p => p.ID == item.ID);
                var tempTrackArtist = lstTrackArtist.Where(p => p.ID_TRACK == item.ID).ToList();
                if (tempStatis != null)
                {
                    temp = Calcu.BUY * tempStatis.BUY_MONTH.Value;
                    temp += Calcu.CLICK * tempStatis.CLICK_MONTH.Value;
                    temp = temp / 100;
                    item.POINT_MONTH = Convert.ToInt32(temp);

                    temp = Calcu.BUY * tempStatis.BUY_ALL.Value;
                    temp += Calcu.CLICK * tempStatis.CLICK_ALL.Value;
                    temp = temp / 100;
                    item.POINT_ALL = Convert.ToInt32(temp);

                    foreach (var itemm in tempTrackArtist)
                    {
                        itemm.POINT_MONTH = item.POINT_MONTH;
                        itemm.POINT_ALL = item.POINT_ALL;
                    }
                }
            }
            db.SaveChanges();

            //update REMIX    ( Update Remix and Remix_Artist )
            var lstRemix = db.REMIXes.ToList();
            var lstRemixArtist = db.REMIX_ARTIST.ToList();
            var lstStatisticRemix = db.STATISTIC_REMIX.ToList();
            var temp1 = 0.1;
            foreach (var item in lstRemix)
            {
                var tempStatis = lstStatisticRemix.FirstOrDefault(p => p.ID == item.ID);
                var tempRemixArtist = lstRemixArtist.Where(p => p.ID_REMIX == item.ID).ToList();
                if (tempStatis != null)
                {
                    temp1 = Calcu.BUY * tempStatis.BUY_MONTH.Value;
                    temp1 += Calcu.CLICK * tempStatis.CLICK_MONTH.Value;
                    temp1 = temp1 / 100;
                    item.POINT_MONTH = Convert.ToInt32(temp1);

                    temp1 = Calcu.BUY * tempStatis.BUY_ALL.Value;
                    temp1 += Calcu.CLICK * tempStatis.CLICK_ALL.Value;
                    temp1 = temp1 / 100;
                    item.POINT_MONTH = Convert.ToInt32(temp1);

                    foreach (var itemm in tempRemixArtist)
                    {
                        itemm.POINT_MONTH = item.POINT_MONTH;
                        itemm.POINT_ALL = item.POINT_ALL;
                    }
                }
            }
            db.SaveChanges();

            return Json("1");
        }

        //update point artist
        public JsonResult update_Point_Artist()
        {
            //update music
            update_Track_Remix();

            var listArtist = db.ARTISTs.ToList();
            var listTrack_Artist = db.TRACK_ARTIST.ToList();
            var listRemix_Artist = db.REMIX_ARTIST.ToList();
            var sum = 1;
            foreach (var item in listArtist)
            {
                sum = listTrack_Artist.Where(p => p.ID_ARTIST == item.ID).Sum(p => p.POINT_MONTH.Value);
                sum += listRemix_Artist.Where(p => p.ID_ARTIST == item.ID).Sum(p => p.POINT_MONTH.Value);
                item.POINT_MONTH = sum;

                sum = listTrack_Artist.Where(p => p.ID_ARTIST == item.ID).Sum(p => p.POINT_ALL.Value);
                sum += listRemix_Artist.Where(p => p.ID_ARTIST == item.ID).Sum(p => p.POINT_ALL.Value);
                item.POINT_ALL = sum;
            }
            db.SaveChanges();

            return Json("1");
        }

        //update all
        public JsonResult update_All()
        {
            update_NewTrack();
            update_Track_Remix();
            update_Point_Artist();

            return Json("1");
        }

    }
}