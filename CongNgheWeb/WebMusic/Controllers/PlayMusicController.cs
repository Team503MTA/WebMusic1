using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class PlayMusicController : Controller
    {
        MusicEntities db = new MusicEntities();

        // GET: PlayMusic
        public string GetMusic(int id, int type)
        {
            StringBuilder sb = new StringBuilder();
            if (type == 1)
            {
                //add statistic for track
                var statisTrack = db.STATISTIC_TRACK.FirstOrDefault(p => p.ID == id);
                statisTrack.CLICK_MONTH++;
                statisTrack.CLICK_ALL++;
                db.SaveChanges();

                TRACK track = db.TRACKs.FirstOrDefault(p => p.ID == id);
                var artist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == id).Select(p => p.NAME_ARTIST).ToList();

                sb.Append("<div class='tag-playmusic' id='all-tagMusicBottom'>");
                sb.Append("<div class='playmusic-info' id='all-playmusic-change'>");
                sb.Append("<div class='imgPlayMusic'>");
                sb.Append("<img src = '.." + track.LINK_IMG + "' />");
                sb.Append("</div >");
                sb.Append("<div class='textPlayMusic'>");
                sb.Append("<a href='#' class='playmusic-name' onclick='ViewDetailTrackAll_fun(" + id + "); return false;' >" + track.NAME + "</a>");
                for (int i = 0; i < artist.Count; i++)
                {
                    sb.Append("<a href='#' class='playmusic-artist' onclick='detail_Artist(\"" + artist[i] + "\"); return false;' >" + artist[i] + "</a>");
                    if (i != artist.Count - 1)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-time'>");
                sb.Append("<label id ='playmusic-start'></label>");
                sb.Append("<progress id='playmusic-process' value='0' max='100'></progress>");
                sb.Append("<label id='playmusic-end'></ label >");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-button'>");
                sb.Append("<button id='playmusic-prev' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-backward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playButton'>");
                sb.Append("<i class='glyphicon glyphicon-play'></i>");
                sb.Append("<i class='glyphicon glyphicon-pause'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playmusic-next' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-forward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='loopButton'>");
                sb.Append("<i class='glyphicon glyphicon-repeat'></i>");
                sb.Append("</button>");
                sb.Append("<div id='volume'>");
                sb.Append("<button id='volumeButton'>");
                sb.Append("<i class='glyphicon glyphicon-volume-down'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-up'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-off'></i>");
                sb.Append("</button>");
                sb.Append("<progress id='volumeProBar' value='100' max='100'></progress>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<audio id='myTune' controls onloadedmetadata='audioLoad()' >");
                sb.Append("<source src='.." + track.LINK + "'>");
                sb.Append("</audio>");
                sb.Append("</div>");
            }
            else if (type == 2)
            {
                //add statistic for Remix
                var statisRemix = db.STATISTIC_REMIX.FirstOrDefault(p => p.ID == id);
                statisRemix.CLICK_MONTH++;
                statisRemix.CLICK_ALL++;
                db.SaveChanges();

                REMIX remix = db.REMIXes.FirstOrDefault(p => p.ID == id);
                var artist = db.REMIX_ARTIST.Where(p => p.ID_REMIX == id).Select(p => p.NAME_ARTIST).ToList();

                sb.Append("<div class='tag-playmusic' id='all-tagMusicBottom'>");
                sb.Append("<div class='playmusic-info' id='all-playmusic-change'>");
                sb.Append("<div class='imgPlayMusic'>");
                sb.Append("<img src = '.." + remix.LINK_IMG + "' />");
                sb.Append("</div >");
                sb.Append("<div class='textPlayMusic'>");
                sb.Append("<a href='#' class='playmusic-name' onclick='return false;' >" + remix.NAME + "</a>");
                for (int i = 0; i < artist.Count; i++)
                {
                    sb.Append("<a href='#' class='playmusic-artist' onclick='detail_Artist(\"" + artist[i] + "\"); return false;' >" + artist[i] + "</a>");
                    if (i != artist.Count - 1)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-time'>");
                sb.Append("<label id ='playmusic-start'></label>");
                sb.Append("<progress id='playmusic-process' value='0' max='100'></progress>");
                sb.Append("<label id='playmusic-end'></ label >");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-button'>");
                sb.Append("<button id='playmusic-prev' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-backward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playButton'>");
                sb.Append("<i class='glyphicon glyphicon-play'></i>");
                sb.Append("<i class='glyphicon glyphicon-pause'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playmusic-next' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-forward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='loopButton'>");
                sb.Append("<i class='glyphicon glyphicon-repeat'></i>");
                sb.Append("</button>");
                sb.Append("<div id='volume'>");
                sb.Append("<button id='volumeButton'>");
                sb.Append("<i class='glyphicon glyphicon-volume-down'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-up'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-off'></i>");
                sb.Append("</button>");
                sb.Append("<progress id='volumeProBar' value='100' max='100'></progress>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<audio id='myTune' controls onloadedmetadata='audioLoad()' >");
                sb.Append("<source src='.." + remix.LINK + "'>");
                sb.Append("</audio>");
                sb.Append("</div>");
            }
            else if (type == 3)
            {
                //add statistic for track
                var statisLiveset = db.STATISTIC_LIVESET.FirstOrDefault(p => p.ID == id);
                statisLiveset.CLICK_MONTH++;
                statisLiveset.CLICK_ALL++;
                db.SaveChanges();

                LIVESET liveset = db.LIVESETs.FirstOrDefault(p => p.ID == id);
                var artist = db.LIVESET_ARTIST.Where(p => p.ID_LIVESET == id).Select(p => p.NAME_ARTIST).ToList();

                sb.Append("<div class='tag-playmusic' id='all-tagMusicBottom'>");
                sb.Append("<div class='playmusic-info' id='all-playmusic-change'>");
                sb.Append("<div class='imgPlayMusic'>");
                sb.Append("<img src = '.." + liveset.LINK_IMG + "' />");
                sb.Append("</div >");
                sb.Append("<div class='textPlayMusic'>");
                sb.Append("<a href='#' class='playmusic-name' onclick='return false;' >" + liveset.NAME + "</a>");
                for (int i = 0; i < artist.Count; i++)
                {
                    sb.Append("<a href='#' class='playmusic-artist' onclick='detail_Artist(\"" + artist[i] + "\"); return false;' >" + artist[i] + "</a>");
                    if (i != artist.Count - 1)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-time'>");
                sb.Append("<label id ='playmusic-start'></label>");
                sb.Append("<progress id='playmusic-process' value='0' max='100'></progress>");
                sb.Append("<label id='playmusic-end'></ label >");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-button'>");
                sb.Append("<button id='playmusic-prev' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-backward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playButton'>");
                sb.Append("<i class='glyphicon glyphicon-play'></i>");
                sb.Append("<i class='glyphicon glyphicon-pause'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playmusic-next' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-forward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='loopButton'>");
                sb.Append("<i class='glyphicon glyphicon-repeat'></i>");
                sb.Append("</button>");
                sb.Append("<div id='volume'>");
                sb.Append("<button id='volumeButton'>");
                sb.Append("<i class='glyphicon glyphicon-volume-down'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-up'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-off'></i>");
                sb.Append("</button>");
                sb.Append("<progress id='volumeProBar' value='100' max='100'></progress>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<audio id='myTune' controls onloadedmetadata='audioLoad()' >");
                sb.Append("<source src='.." + liveset.LINK + "'>");
                sb.Append("</audio>");
                sb.Append("</div>");
            }
            else if (type == 4)
            {
                //add statistic for track
                var statisDemo = db.STATISTIC_DEMO.FirstOrDefault(p => p.ID == id);
                statisDemo.CLICK_MONTH++;
                statisDemo.CLICK_ALL++;
                db.SaveChanges();

                DEMO demo = db.DEMOes.FirstOrDefault(p => p.ID == id);
                var artist = db.DEMO_ARTIST.Where(p => p.ID_DEMO == id).Select(p => p.NAME_ARTIST).ToList();

                sb.Append("<div class='tag-playmusic' id='all-tagMusicBottom'>");
                sb.Append("<div class='playmusic-info' id='all-playmusic-change'>");
                sb.Append("<div class='imgPlayMusic'>");
                sb.Append("<img src = '.." + demo.LINK_IMG + "' />");
                sb.Append("</div >");
                sb.Append("<div class='textPlayMusic'>");
                sb.Append("<a href='#' class='playmusic-name' onclick='return false;' >" + demo.NAME + "</a>");
                for (int i = 0; i < artist.Count; i++)
                {
                    sb.Append("<a href='#' class='playmusic-artist' onclick='detail_Artist(\"" + artist[i] + "\"); return false;' >" + artist[i] + "</a>");
                    if (i != artist.Count - 1)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-time'>");
                sb.Append("<label id ='playmusic-start'></label>");
                sb.Append("<progress id='playmusic-process' value='0' max='100'></progress>");
                sb.Append("<label id='playmusic-end'></ label >");
                sb.Append("</div>");
                sb.Append("<div class='playmusic-button'>");
                sb.Append("<button id='playmusic-prev' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-backward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playButton'>");
                sb.Append("<i class='glyphicon glyphicon-play'></i>");
                sb.Append("<i class='glyphicon glyphicon-pause'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playmusic-next' onclick='RandomMusic()'>");
                sb.Append("<i class='glyphicon glyphicon-forward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='loopButton'>");
                sb.Append("<i class='glyphicon glyphicon-repeat'></i>");
                sb.Append("</button>");
                sb.Append("<div id='volume'>");
                sb.Append("<button id='volumeButton'>");
                sb.Append("<i class='glyphicon glyphicon-volume-down'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-up'></i>");
                sb.Append("<i class='glyphicon glyphicon-volume-off'></i>");
                sb.Append("</button>");
                sb.Append("<progress id='volumeProBar' value='100' max='100'></progress>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<audio id='myTune' controls onloadedmetadata='audioLoad()' >");
                sb.Append("<source src='.." + demo.LINK + "'>");
                sb.Append("</audio>");
                sb.Append("</div>");
            }

            return sb.ToString();
        }

        public JsonResult selectSong(Song song)
        {
            List<USER_TRACKLIST> playlist = Session["PlayList"] as List<USER_TRACKLIST>;
            var temp = playlist.FirstOrDefault(p => p.ID_PROD == song.id && p.TYPE == song.type);
            if (temp == null)
            {
                var lst = Session["PlaylistRight"] as List<USER_TRACKLIST>;
                var addsong = lst.FirstOrDefault(p => p.ID_PROD == song.id && p.TYPE == song.type);
                playlist.Add(addsong);
            }
            else
            {
                playlist.Remove(temp);
            }
            Session["PlayList"] = playlist;
            return Json("");
        }

        public JsonResult PlayList()
        {
            USER user = Session["User"] as USER;
            var playList = db.USER_TRACKLIST.Where(p => p.ID_USER == user.ID).ToList();
            Session["PlaylistRight"] = playList;
            if (playList.Count == 0)
            {
                return Json("");
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='container'>");
            sb.Append("<div class='row'>");
            sb.Append("<div class='col-sm-12'>");

            sb.Append("<div class='col-sm-3' id='userPage_left'>");
            sb.Append("<div id='playlistUser' class='userPage_left_control'>Playlist</div>");
            sb.Append("<div id='editUser' class='userPage_left_control'>Edit User</div>");
            sb.Append("<div id='playSelected_track_remix' class='userPage_left_control' onclick='RandomMusic();' >Play Selected Track And Remix</div>");
            sb.Append("</div>");

            sb.Append("<div class='col-sm-offset-4 col-sm-8' id='userPage_right'>");

            //  Track
            sb.Append("<div id='user_trackPlaylist'>");
            sb.Append("<p class='user_title'>Track</p>");
            sb.Append("<input type='checkbox' id='user_trackCheckAll' class='user_checkAll' checked>");
            sb.Append("<span class='user_checkAllText'>Sellect All</span>");

            sb.Append("<div id='userContent_trackPlaylist' class='user_beautyScroll'>");
            foreach (var item in playList)
            {
                if (item.TYPE == 1)
                {
                    sb.Append("<div class='user_trackDetail'>");
                    sb.Append("<input type='checkbox' checked onclick='select_notSelect_Song(" + item.ID_PROD + ",1)' >");
                    sb.Append("<span>" + item.NAME + "</span>");
                    sb.Append("</div>");
                }
            }
            sb.Append("</div>");
            sb.Append("<br/>");
            sb.Append("</div>");

            //  Remix
            sb.Append("< br/>");
            sb.Append("<div style='background:transparent; display:inline-block; height:400px; width:100%;' ></ div >");
            sb.Append("<br/>");

            sb.Append("<div id='user_remixPlaylist'>");
            sb.Append("<p class='user_title'>Remix</p>");
            sb.Append("<input type='checkbox' id='user_remixCheckAll' class='user_checkAll' checked>");
            sb.Append("<span class='user_checkAllText'>Sellect All</span>");

            sb.Append("<div id='userContent_remixPlaylist' class='user_beautyScroll'>");
            foreach (var item in playList)
            {
                if (item.TYPE == 2)
                {
                    sb.Append("<div class='user_trackDetail'>");
                    sb.Append("<input type='checkbox' checked onclick='select_notSelect_Song(" + item.ID_PROD + ",2)'>");
                    sb.Append("<span>" + item.NAME + "</span>");
                    sb.Append("</div>");
                }
            }
            sb.Append("</div>");
            sb.Append("</br>");
            sb.Append("</div>");


            //  liveset
            sb.Append("< br/>");
            sb.Append("<div style='background:transparent; display:inline-block; height:400px; width:100%;' ></ div >");
            sb.Append("<br/>");

            sb.Append("<div id='user_livesetPlaylist'>");
            sb.Append("<p class='user_title'>LiveSet</p>");
            sb.Append("<input type='checkbox' id='user_livesetCheckAll' class='user_checkAll' checked>");
            sb.Append("<span class='user_checkAllText'>Sellect All</span>");

            sb.Append("<div id='userContent_livesetPlaylist' class='user_beautyScroll'>");
            foreach (var item in playList)
            {
                if (item.TYPE == 3)
                {
                    sb.Append("<div class='user_trackDetail'>");
                    sb.Append("<input type='checkbox' checked onclick='select_notSelect_Song(" + item.ID_PROD + ",3)'>");
                    sb.Append("<span>" + item.NAME + "</span>");
                    sb.Append("</div>");
                }
            }
            sb.Append("</div>");
            sb.Append("</br>");
            sb.Append("</div>");

            //  demo
            sb.Append("< br/>");
            sb.Append("<div style='background:transparent; display:inline-block; height:400px; width:100%;' ></ div >");
            sb.Append("<br/>");

            sb.Append("<div id='user_demoPlaylist'>");
            sb.Append("<p class='user_title'>Demo</p>");
            sb.Append("<input type='checkbox' id='user_demoCheckAll' class='user_checkAll' checked>");
            sb.Append("<span class='user_checkAllText'>Sellect All</span>");

            sb.Append("<div id='userContent_demoPlaylist' class='user_beautyScroll'>");
            foreach (var item in playList)
            {
                if (item.TYPE == 4)
                {
                    sb.Append("<div class='user_trackDetail'>");
                    sb.Append("<input type='checkbox' checked onclick='select_notSelect_Song(" + item.ID_PROD + ",4)'>");
                    sb.Append("<span>" + item.NAME + "</span>");
                    sb.Append("</div>");
                }
            }
            sb.Append("</div>");
            sb.Append("</br>");
            sb.Append("</div>");





            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return Json(sb.ToString());
        }

        public JsonResult status_PlayMusic()
        {
            //status = 0 : random auto all , status = 1 : random playlist

            if (Session["typePlayMusic"].ToString() == "0")
            {
                Session["typePlayMusic"] = 1;
                return Json("1");
            }
            else
            {
                Session["typePlayMusic"] = 0;
                return Json("0");
            }
        }

        public JsonResult PlayMusic()
        {
            int id_Old = Convert.ToInt32(Session["idRandom"].ToString());
            int type_Old = Convert.ToInt32(Session["typeRandom"].ToString());
            int id = 0;

            if (Session["typePlayMusic"].ToString() == "0")
            {
                Random r = new Random();
                int rInt = r.Next(0, 12);
                int type = 1; // 1:Track,  2:Remix,  3:Liveset,  4:Demo
                if (rInt <= 3) // (0-3) track, (4-7) remix, (8-9) liveset, (10-11) demo 
                {
                    type = 1;
                    id = db.TRACKs.Where(p => p.ID != id_Old || type_Old != 1).OrderBy(p => Guid.NewGuid()).Select(p => p.ID).FirstOrDefault();
                }
                else if (rInt <= 7)
                {
                    type = 2;
                    id = db.REMIXes.Where(p => p.ID != id_Old || type_Old != 2).OrderBy(p => Guid.NewGuid()).Select(p => p.ID).FirstOrDefault();
                }
                else if (rInt <= 9)
                {
                    type = 3;
                    id = db.LIVESETs.Where(p => p.ID != id_Old || type_Old != 3).OrderBy(p => Guid.NewGuid()).Select(p => p.ID).FirstOrDefault();
                }
                else if (rInt <= 11)
                {
                    type = 4;
                    id = db.DEMOes.Where(p => p.ID != id_Old || type_Old != 4).OrderBy(p => Guid.NewGuid()).Select(p => p.ID).FirstOrDefault();
                }

                id_Old = id;
                Session["idRandom"] = id;
                type_Old = type;
                Session["typeRandom"] = type;
            }
            else
            {
                var playList = Session["PlayList"] as List<USER_TRACKLIST>;
                USER_TRACKLIST temp = playList.Where(p => p.ID_PROD != id_Old || p.TYPE != type_Old).OrderBy(p => Guid.NewGuid()).FirstOrDefault();
                id_Old = temp.ID_PROD;
                Session["idRandom"] = temp.ID_PROD;
                type_Old = temp.TYPE;
                Session["typeRandom"] = temp.TYPE;
            }

            return Json(GetMusic(id_Old,type_Old));
        }

        public JsonResult SelectMusic(int id, int type)
        {
            return Json(GetMusic(id,type));
        }

        //public JsonResult playPlayList()
        //{
        //    int id = Convert.ToInt32(Session["idRandom"].ToString());
        //    var playList = Session["PlayList"] as List<USER_TRACKLIST>;
        //    if (playList.Count == 0)
        //    {
        //        return Json("0");
        //    }

        //    Random r = new Random();
        //    int rInt = 0;
        //    int idRan = 0;
        //    while (1 == 1)
        //    {
        //        rInt = r.Next(0, 2);
        //        if (rInt == 1)
        //        {
        //            idRan = r.Next(0, playList.Count);
        //            break;
        //        }
        //    }
        //}
    }
}