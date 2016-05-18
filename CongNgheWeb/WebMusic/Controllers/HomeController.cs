using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class HomeController : Controller
    {

        MusicEntities db = new MusicEntities();

        public string HotSlider()
        {
            var temp = db.HOME_HOT_NEW.ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='hot-slider'>");
            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    sb.Append("<div stt='" + i + "' class='hot-slider-img'>");
                    sb.Append("<a href ='#'><img src='." + temp[i].LINK_IMG + "'></a>");
                    sb.Append("</div>");
                }
                sb.Append("<div class='hot -slider-control'>");
                for (int i = 0; i < temp.Count; i++)
                {
                    if (i == 0)
                    {
                        sb.Append("<div stt = '0' class='hot-slider-button-active hot-slider-button' ></div>");
                    }
                    else
                    {
                        sb.Append("<div stt = '" + i + "' class='hot-slider-button'></div>");
                    }
                }
                sb.Append("</div>");
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        public string Top_6_DJ()
        {
            var temp = db.TOP_6_DJ.ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='top-6-dj'>");
            sb.Append("<p class='top-6-dj-title'>Top 6 DJ</p>");
            sb.Append("<div class='top -6-dj-content'>");
            sb.Append("<div class='top -6-dj-slider'>");

            sb.Append("<div stt = '0' class='top-6-dj-child'>");
            sb.Append("<ul>");
            for (int i = 0; i < 3; i++)
            {
                sb.Append("<li>");
                sb.Append("<div class='string-in-img'>");
                sb.Append("<img src='." + temp[i].IMG + "' style='cursor:pointer;' onclick='detail_Artist(\"" + temp[i].NAME_ARTIST + "\")' >");
                sb.Append("<div class='string-in-img-control'>");
                sb.Append("<span>Follow</span>");
                sb.Append("<button class='string-in-img-fb'>");
                sb.Append("<i class='fa fa-facebook'></i>");
                sb.Append("</button>");
                sb.Append("<button class='string-in-img-tw'><i class='fa fa-twitter'></i></button>");
                sb.Append("</div>");
                sb.Append("<div class='string-in-img-name'>");
                sb.Append("<a href='#' id='string-name-right' onclick='detail_Artist(\"" + temp[i].NAME_ARTIST + "\")'>" + temp[i].NAME_ARTIST + "</a>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            sb.Append("</div>");

            sb.Append("<div stt = '1' class='top-6-dj-child'>");
            sb.Append("<ul>");
            for (int i = 3; i < 6; i++)
            {
                sb.Append("<li>");
                sb.Append("<div class='string-in-img'>");
                sb.Append("<img src='." + temp[i].IMG + "'>");
                sb.Append("<div class='string-in-img-control'>");
                sb.Append("<span>Follow</span>");
                sb.Append("<button class='string-in-img-fb'>");
                sb.Append("<i class='fa fa-facebook'></i>");
                sb.Append("</button>");
                sb.Append("<button class='string-in-img-tw'><i class='fa fa-twitter'></i></button>");
                sb.Append("</div>");
                sb.Append("<div class='string-in-img-name'>");
                sb.Append("<a href='#' id='string-name-right'>" + temp[i].NAME_ARTIST + "</a>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            sb.Append("</div>");

            sb.Append("<div class='top-6-dj-control'>");
            sb.Append("<div stt = '0' class='top-6-dj-button-active top-6-dj-button'></div>");
            sb.Append("<div stt = '1' class='top-6-dj-button'></div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public string New_Track()
        {

            List<NEW_TRACK> lst;
            lst = (from p in db.NEW_TRACK select p).OrderBy(p => p.RANKK).ToList();

            List<List<List<string>>> info = new List<List<List<string>>>();
            for (int i = 0; i < lst.Count; i++)
            {
                List<List<string>> tempParent = new List<List<string>>();

                int tempVar = lst[i].ID;

                tempParent.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == tempVar).Select(p => p.NAME_ARTIST).ToList());
                tempParent.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == tempVar).Select(p => p.NAME_LABEL).ToList());
                info.Add(tempParent);
            }

            StringBuilder sb = new StringBuilder();
            var count = 0;
            sb.Append("<div class='new-tracks'>");
            sb.Append("<p class='new-tracks-title'>New Tracks</p>");

            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    sb.Append("<div stt='" + i + "' class='new-track-div new-track-div-active'>");
                }
                else
                {
                    sb.Append("<div stt='" + i + "' class='new-track-div'>");
                }
                for (int j = 0; j < 8; j++)
                {
                    if (j % 4 == 0)
                    {
                        sb.Append("<ul class='new-track-div-ul'>");
                    }

                    count = i * 7 + j;
                    sb.Append("<li>");
                    sb.Append("<div class='new-track-child'>");
                    sb.Append("<div class='new-track-child-top'>");
                    sb.Append("<img src='." + lst[count].LINK_IMG + "'>");
                    sb.Append("<div class='new-track-child-top-control'>");
                    sb.Append("<button onclick='clickAllPlayMusic(" + lst[count].ID + ",1,1)' class='new-track-child-play all-playmusic'><i class='fa fa-play'></i></button>");
                    sb.Append("<button onclick='clickBuy_fun(" + lst[count].ID + ",1)' class='new-track-child-buy'>$" + lst[count].COST + "</button>");
                    sb.Append("<button class='new-track-child-share'><i class='fa fa-facebook'></i>Share</button>");
                    sb.Append("</div>");
                    sb.Append("<p></p>");
                    sb.Append("</div>");
                    sb.Append("<div class='new-track-child-bottom'>");
                    sb.Append("<p class='new-track-detail'>");
                    sb.Append("<span class='new-track-detail-1' style='cursor:pointer;' onclick='ViewDetailTrackAll_fun(" + lst[count].ID + ")' title='" + lst[count].NAME + "'>" + lst[count].NAME + "</span>");
                    sb.Append("</p>");
                    sb.Append("<p class='new-track-detail'>");
                    for (int k = 0; k < info[count][0].Count; k++)
                    {
                        sb.Append("<a class='new-track-detail-2' href='#' title='" + info[count][0][k] + "'>" + info[count][0][k] + "</a>");
                        if (k != info[count][0].Count - 1)
                        {
                            sb.Append("<span style='color:#22bbcc; font-size:65%;'> ft </span>");
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("<p class='new-track-detail'>");
                    for (int k = 0; k < info[count][1].Count; k++)
                    {
                        sb.Append("<a class='new-track-detail-3' href='#' title='" + info[count][1][k] + "'>" + info[count][1][k] + "</a>");
                        if (k != info[count][1].Count - 1)
                        {
                            sb.Append("<span style='color:#666; font-size:65%;'> ,</span>");
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");

                    count++;

                    if (j % 4 == 3)
                    {
                        sb.Append("</ul>");
                    }
                }
                sb.Append("</div>");
            }

            sb.Append("<div class='new-tracks-pages'>");
            sb.Append("<ul>");
            sb.Append("<li stt='0' class='new-tracks-pages-li new-tracks-pages-li-active'></li>");
            sb.Append("<li stt='1' class='new-tracks-pages-li'></li>");
            sb.Append("<li stt='2' class='new-tracks-pages-li'></li>");
            sb.Append("<li stt='3' class='new-tracks-pages-li'></li>");
            sb.Append("<li stt='4' class='new-tracks-pages-li'></li>");
            sb.Append("<li stt='5' class='new-tracks-pages-li'></li>");
            sb.Append("<li stt='6' class='new-tracks-pages-li'></li>");
            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public string Hot_Remix()
        {
            var listHot = db.REMIXes.OrderByDescending(p => p.POINT_MONTH).Take(12).ToList();
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='hot-remix'>");
            sb.Append("<p class='hot-remix-title'>Hot Remix</p>");
            var count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    sb.Append("<div stt='" + i + "' class='hot-remix-div hot-remix-div-active'>");
                }
                else
                {
                    sb.Append("<div stt='" + i + "' class='hot-remix-div'>");
                }


                sb.Append("<ul class='hot-remix-div-ul'>");

                for (int j = 0; j < 4; j++)
                {
                    sb.Append("<li>");
                    sb.Append("<div class='song-vertical'>");
                    sb.Append("<div class='song-vertical-top'>");
                    sb.Append("<img src='." + listHot[count].LINK_IMG + "'>");
                    sb.Append("<div class='song-vertical-top-control'>");
                    sb.Append("<button class='song-vertical-play'><i class='fa fa-play'></i></button>");
                    sb.Append("<button class='song-vertical-buy'>$" + listHot[count].COST + "</button>");
                    sb.Append("<button class='song-vertical-share'><i class='fa fa-facebook'></i>Share</button>");
                    sb.Append("</div>");
                    sb.Append("<p></p>");
                    sb.Append("</div>");
                    sb.Append("<div class='song-vertical-bottom'>");
                    sb.Append("<p class='wrap-name-level'><a class='name-level-1' href='#'>" + listHot[count].NAME + "</a></p>");
                    sb.Append("<p class='wrap-name-level'>");
                    int temp = listHot[count].ID;
                    var tempArtist =
                        db.REMIX_ARTIST.Where(p => p.ID_REMIX == temp).Select(p => p.NAME_ARTIST).ToList();
                    if (tempArtist != null)
                    {
                        for (int k = tempArtist.Count - 1; k >= 0; k--)
                        {
                            sb.Append("<a class='name-level-2' href='#'>" + tempArtist[k] + "</a>");
                            if (k != 0)
                            {
                                sb.Append("<span> ft </span>");
                            }
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("<p class='wrap-name-level'>");
                    var tempLabel =
                        db.REMIX_ARTIST.Where(p => p.ID_REMIX == temp).Select(p => p.NAME_LABEL).ToList();
                    if (tempLabel != null)
                    {
                        for (int k = tempLabel.Count - 1; k >= 0; k--)
                        {
                            sb.Append("<a class='name-level-3' href='#'>" + tempLabel[k] + "</a>");
                            if (k != 0)
                            {
                                sb.Append("<span> ft </span>");
                            }
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");

                    count++;
                }

                sb.Append("</ul>");

                sb.Append("</div>");
            }


            sb.Append("<div class='hot-remix-pages'>");
            sb.Append("<ul>");
            sb.Append("<li stt='0' class='hot-remix-pages-li hot-remix-pages-li-active'></li>");
            sb.Append("<li stt='1' class='hot-remix-pages-li'></li>");
            sb.Append("<li stt='2' class='hot-remix-pages-li'></li>");
            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public string Live_Set()
        {
            var liveset = db.LIVESETs.OrderByDescending(p => p.POINT_MONTH).Take(30).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='live-set'>");
            sb.Append("<p class='live-set-title'>Top Liveset</p>");
            sb.Append("<div class='live-set-content'>");
            var count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    sb.Append("<div stt='" + i + "' class='live-set-content-div live-set-content-active'>");
                }
                else
                {
                    sb.Append("<div stt='" + i + "' class='live-set-content-div'>");
                }
                for (int j = 0; j < 2; j++)
                {
                    sb.Append("<ul>");
                    for (int k = 0; k < 3; k++)
                    {
                        sb.Append("<li>");
                        sb.Append("<div class='song-vertical'>");
                        sb.Append("<div class='song-vertical-top'>");
                        sb.Append("<img src='." + liveset[count].LINK_IMG + "'>");
                        sb.Append("<div class='song-vertical-top-control'>");
                        sb.Append("<button class='song-vertical-play'><i class='fa fa-play'></i></button>");
                        sb.Append("<button class='song-vertical-buy'>$" + liveset[count].COST + "</button>");
                        sb.Append("<button class='song-vertical-share'><i class='fa fa-facebook'></i>Share</button>");
                        sb.Append("</div>");
                        sb.Append("<p></p>");
                        sb.Append("</div>");
                        sb.Append("<div class='song-vertical-bottom'>");
                        sb.Append("<p class='wrap-name-level'><a class='name-level-1' href='#'>" + liveset[count].NAME + "</a></p>");
                        sb.Append("<p class='wrap-name-level'>");
                        var ss = liveset[count].ID;
                        var artist = db.LIVESET_ARTIST.Where(p => p.ID_LIVESET == ss).Select(p => p.NAME_ARTIST).ToList();
                        for (int l = artist.Count - 1; l >= 0; l--)
                        {
                            sb.Append("<a class='name-level-2' href='#'>" + artist[l] + "</a>");
                            if (l != 0)
                            {
                                sb.Append("<span> ft </span>");
                            }
                        }
                        sb.Append("</p>");
                        sb.Append("<p class='wrap-name-level'>");
                        var label = db.LIVESET_ARTIST.Where(p => p.ID_LIVESET == ss).Select(p => p.NAME_LABEL).ToList();
                        for (int l = label.Count - 1; l >= 0; l--)
                        {
                            sb.Append("<a class='name-level-3' href='#'>" + label[l] + "</a>");
                            if (l != 0)
                            {
                                sb.Append("<span> ft </span>");
                            }
                        }
                        sb.Append("</p>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</li>");

                        count++;
                    }
                    sb.Append("</ul>");
                }
                sb.Append("</div>");
            }
            sb.Append("<div class='live-set-slider'>");
            sb.Append("<div stt='0' class='live-set-slider-div live-set-slider-div-active'></div>");
            sb.Append("<div stt='1' class='live-set-slider-div'></div>");
            sb.Append("<div stt='2' class='live-set-slider-div'></div>");
            sb.Append("<div stt='3' class='live-set-slider-div'></div>");
            sb.Append("<div stt='4' class='live-set-slider-div'></div>");
            sb.Append("</div>");

            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public string Demo()
        {
            var demo = db.DEMOes.ToList();
            var count = 0;
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='new-demo'>");
            sb.Append("<p class='new-demo-title'>New Demo</p>");
            sb.Append("<div class='new-demo-div'>");

            for (int i = 0; i < 2; i++)
            {
                sb.Append("<ul class='new-demo-div-ul'>");

                for (int j = 0; j < 4; j++)
                {
                    sb.Append("<li>");
                    sb.Append("<div class='song-vertical'>");
                    sb.Append("<div class='song-vertical-top'>");
                    sb.Append("<img src='." + demo[count].LINK_IMG + "' alt=''>");
                    sb.Append("<div class='song-vertical-top-control'>");
                    sb.Append("<button class='song-vertical-play'><i class='fa fa-play'></i></button>");
                    sb.Append("<button class='song-vertical-buy'>$" + demo[count].COST.Value + "</button>");
                    sb.Append("<button class='song-vertical-share'><i class='fa fa-facebook'></i>Share</button>");
                    sb.Append("</div>");
                    sb.Append("<p></p>");
                    sb.Append("</div>");
                    sb.Append("<div class='song-vertical-bottom'>");
                    sb.Append("<p class='wrap-name-level'><a class='name-level-1' href='#'>" + demo[count].NAME + "</a></p>");
                    var ss = demo[count].ID;
                    var artist = db.DEMO_ARTIST.Where(p => p.ID_DEMO == ss).Select(p => p.NAME_ARTIST).ToList();
                    sb.Append("<p class='wrap-name-level'>");
                    for (int k = artist.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a class='name-level-2' href='#'>" + artist[k] + "</a>");
                        if (k != 0)
                        {
                            sb.Append("<span> ft </span>");
                        }
                    }
                    sb.Append("</p>");

                    var label = db.DEMO_ARTIST.Where(p => p.ID_DEMO == ss).Select(p => p.NAME_LABEL).ToList();
                    sb.Append("<p class='wrap-name-level'>");
                    for (int k = label.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a class='name-level-3' href='#'>" + label[k] + "</a>");
                        if (k != 0)
                        {
                            sb.Append("<span> ft </span>");
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");

                    count++;
                }

                sb.Append("</ul>");
            }

            sb.Append("</div></div>");

            return sb.ToString();
        }

        public string Top_10_Track()
        {
            StringBuilder sb = new StringBuilder();

            var track = db.TRACKs.OrderByDescending(p => p.DATE_RELEASE).Take(10).ToList();

            sb.Append("<div class='top-ten'>");
            sb.Append("<p class='top-ten-title'>TOP TEN</p>");

            sb.Append("<ul>");
            for (int i = 0; i < track.Count; i++)
            {
                sb.Append("<li>");
                sb.Append("<div class='song-horizontal'>");
                sb.Append("<div class='song-horizontal-left'>");
                sb.Append("<p>" + (i + 1) + "</p>");
                sb.Append("<button><i class='fa fa-play'></i></button>");
                sb.Append("<span class='song-horizontal-left-top'></span>");
                sb.Append("<span class='song-horizontal-left-bottom'></span>");
                sb.Append("<span class='song-horizontal-left-left'></span>");
                sb.Append("<span class='song-horizontal-left-right'></span>");
                sb.Append("</div>");
                sb.Append("<div class='song-horizontal-right'>");
                sb.Append("<p class='song-horizontal-name'><a class='name-level-1' href='#'>" + track[i].NAME + "</a></p>");

                sb.Append("<p class='song-horizontal-artist'>");
                var ss = track[i].ID;
                var artist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == ss).Select(p => p.NAME_ARTIST).ToList();
                for (int j = artist.Count - 1; j >= 0; j--)
                {
                    sb.Append("<a class='name-level-2' href ='#'>" + artist[j] + "</a>");
                    if (j != 0)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }
                sb.Append("</p>");

                sb.Append("<p class='song-horizontal-artist'>");
                var label = db.TRACK_ARTIST.Where(p => p.ID_TRACK == ss).Select(p => p.NAME_LABEL).ToList();
                for (int j = label.Count - 1; j >= 0; j--)
                {
                    sb.Append("<a class='name-level-3' href ='#'>" + label[j] + "</a>");
                    if (j != 0)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }
                sb.Append("</p>");

                sb.Append("<button>$" + track[i].COST + "</button>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
            sb.Append("</ul>");

            sb.Append("</div>");


            return sb.ToString();
        }

        public string Bucket()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='bucket'>");
            sb.Append("<img stt='0' class='bucket-img bucket-img-active' src='./IMG/bucket/1.jpg' alt=''>");
            sb.Append("<img stt='1' class='bucket-img' src='./IMG/bucket/2.jpg' alt=''>");
            sb.Append("<img stt='2' class='bucket-img' src='./IMG/bucket/3.jpg' alt=''>");
            sb.Append("<img stt='3' class='bucket-img' src='./IMG/bucket/4.jpg' alt=''>");
            sb.Append("<div class='bucket-pages'>");
            sb.Append("<ul>");
            sb.Append("<li stt='0' class='bucket-pages-li bucket-pages-li-active'></li>");
            sb.Append("<li stt='1' class='bucket-pages-li'></li>");
            sb.Append("<li stt='2' class='bucket-pages-li'></li>");
            sb.Append("<li stt='3' class='bucket-pages-li'></li>");
            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public string Top_10_Demo()
        {
            var demo = db.DEMOes.OrderByDescending(p => p.POINT_MONTH).Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='top-ten-demo'>");
            sb.Append("<p class='top-ten-demo-title'>TOP TEN DEMO</p>");
            sb.Append("<ul>");

            for (int i = 0; i < demo.Count; i++)
            {
                sb.Append("<li>");
                sb.Append("<div class='top-ten-demo-img'>");
                sb.Append("<img src='." + demo[i].LINK_IMG + "' alt=''>");
                sb.Append("</div>");
                sb.Append("<div class='top-ten-demo-li-left'>" + (i+1) + "</div>");
                sb.Append("<div class='top-ten-demo-li-right'>");
                sb.Append("<a href='#' class='top-ten-demo-name link-decorate'>" + demo[i].NAME + "</a>");

                sb.Append("<a href='#' class='top-ten-demo-artist link-decorate'>");
                var ss = demo[i].ID;
                var artist = db.DEMO_ARTIST.Where(p => p.ID_DEMO == ss).Select(p => p.NAME_ARTIST).ToList();
                for (int j = artist.Count - 1; j >= 0; j--)
                {
                    sb.Append("<span>" + artist[j] + "</span>");
                    if (j != 0)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }
                sb.Append("</a>");

                sb.Append("<a href='#' class='top-ten-demo-label link-decorate'>");
                var label = db.DEMO_ARTIST.Where(p => p.ID_DEMO == ss).Select(p => p.NAME_LABEL).ToList();
                for (int j = label.Count - 1; j >= 0; j--)
                {
                    sb.Append("<span>" + label[j] + "</span>");
                    if (j != 0)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }
                sb.Append("</a>");

                sb.Append("<hr>");
                sb.Append("</div>");
                sb.Append("</li>");
            }

            sb.Append("</ul></div>");

            return sb.ToString();
        }

        public JsonResult LeftContent()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(HotSlider());
            sb.Append(Top_6_DJ());
            sb.Append(New_Track());
            sb.Append(Hot_Remix());
            sb.Append(Live_Set());
            sb.Append(Demo());

            return Json(sb.ToString());
        }

        public JsonResult RightContent()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Top_10_Track());
            sb.Append(Bucket());
            sb.Append(Top_10_Demo());

            return Json(sb.ToString());
        }

        public ActionResult Index()
        {
            Session["idRandom"] = 0;
            Session["typeSong"] = 1;
            Session["User"] = 0;
            return View();
        }
    }
}