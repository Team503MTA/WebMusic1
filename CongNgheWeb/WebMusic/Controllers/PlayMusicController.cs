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
        [HttpPost]
        public JsonResult GetMusic(int id, int type, int typePlay)
        {
            //NOTE
            // TYPE : 1 is Track
            //             2 is Remix

            //TYPEPLAY :  1 is playSelect
            //                 2 is playRandom From Page Or PlayList

            var playList = Session["PlayList"] as List<USER_TRACKLIST>;
            if (typePlay == 2)
            {
                id = Convert.ToInt32(Session["idRandom"].ToString());
                if (playList == null)
                {
                    type = new Random().Next(1, 3);
                    if (type == 1)
                    {
                        id =
                            db.TRACKs.Where(p => p.ID != id)
                                .OrderBy(p => Guid.NewGuid())
                                .Select(p => p.ID)
                                .FirstOrDefault();
                    }
                    else if(type==2)
                    {
                        id =
                            db.REMIXes.Where(p => p.ID != id)
                                .OrderBy(p => Guid.NewGuid())
                                .Select(p => p.ID)
                                .FirstOrDefault();
                    }
                }
                else
                {
                    int typeSong = (int)Session["typeSong"];
                    USER_TRACKLIST temp =
                        playList.Where(p => p.ID_PROD != id || p.TYPE != typeSong).OrderBy(p => Guid.NewGuid()).FirstOrDefault();
                    if (temp == null)
                    {
                        id = Convert.ToInt32(Session["idRandom"].ToString());
                        type = typeSong;
                    }
                    else
                    {
                        id = temp.ID_PROD;
                        type = temp.TYPE;
                    }
                }
                Session["idRandom"] = id;
                Session["typeSong"] = type;
            }

            StringBuilder sb = new StringBuilder();
            if (type == 1)
            {
                TRACK track = db.TRACKs.FirstOrDefault(p => p.ID == id);
                var artist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == id).Select(p => p.NAME_ARTIST).ToList();

                sb.Append("<div class='tag-playmusic' id='all-tagMusicBottom'>");
                sb.Append("<div class='playmusic-info' id='all-playmusic-change'>");
                sb.Append("<div class='imgPlayMusic'>");
                sb.Append("<img src = '." + track.LINK_IMG + "' />");
                sb.Append("</div >");
                sb.Append("<div class='textPlayMusic'>");
                sb.Append("<a href='#' class='playmusic-name'>" + track.NAME + "</a>");
                for (int i = 0; i < artist.Count; i++)
                {
                    sb.Append("<a href='#' class='playmusic-artist'>" + artist[i] + "</a>");
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
                sb.Append("<button id='playmusic-prev' onclick='clickAllPlayMusic(1,1,2)'>");
                sb.Append("<i class='glyphicon glyphicon-backward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playButton'>");
                sb.Append("<i class='glyphicon glyphicon-play'></i>");
                sb.Append("<i class='glyphicon glyphicon-pause'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playmusic-next' onclick='clickAllPlayMusic(1,1,2)'>");
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
                sb.Append("<source src='." + track.LINK + "'>");
                sb.Append("</audio>");
                sb.Append("</div>");
            }
            else
            {
                REMIX track = db.REMIXes.FirstOrDefault(p => p.ID == id);
                var artist = db.REMIX_ARTIST.Where(p => p.ID_REMIX == id).Select(p => p.NAME_ARTIST).ToList();

                sb.Append("<div class='tag-playmusic' id='all-tagMusicBottom'>");
                sb.Append("<div class='playmusic-info' id='all-playmusic-change'>");
                sb.Append("<div class='imgPlayMusic'>");
                sb.Append("<img src = '." + track.LINK_IMG + "' />");
                sb.Append("</div >");
                sb.Append("<div class='textPlayMusic'>");
                sb.Append("<a href='#' class='playmusic-name'>" + track.NAME + "</a>");
                for (int i = 0; i < artist.Count; i++)
                {
                    sb.Append("<a href='#' class='playmusic-artist'>" + artist[i] + "</a>");
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
                sb.Append("<button id='playmusic-prev' onclick='clickAllPlayMusic(1,1,2)'>");
                sb.Append("<i class='glyphicon glyphicon-backward'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playButton'>");
                sb.Append("<i class='glyphicon glyphicon-play'></i>");
                sb.Append("<i class='glyphicon glyphicon-pause'></i>");
                sb.Append("</button>");
                sb.Append("<button id='playmusic-next' onclick='clickAllPlayMusic(1,1,2)'>");
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
                sb.Append("<source src='." + track.LINK + "'>");
                sb.Append("</audio>");
                sb.Append("</div>");
            }

            return Json(sb.ToString());
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
            sb.Append("<div id='playSelected_track_remix' class='userPage_left_control' onclick='playPlaylist(1)' >Play Selected Track And Remix</div>");
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
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return Json(sb.ToString());
        }

        public JsonResult playPlayList(int type)
        {
            //// TYPE : 1  __ USER
            //if (type == 1)
            //{
            //    USER user = Session["User"] as USER;
            //    var playList = db.USER_TRACKLIST.Where(p => p.ID_USER == user.ID).ToList();
            //    if (playList.Count == 0)
            //    {
            //        return Json("0");
            //    }
            //    Session["PlayList"] = playList;
            //}
            return Json("1");
        }
    }
}