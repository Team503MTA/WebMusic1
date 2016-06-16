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
                    sb.Append("<button onclick='clickAllPlayMusic(" + lst[count].ID +",1,1)' class='new-track-child-play all-playmusic'><i class='fa fa-play'></i></button>");
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
                        if (k != info[count][0].Count-1)
                        {
                            sb.Append("<span style='color:#22bbcc; font-size:65%;'> ft </span>");
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("<p class='new-track-detail'>");
                    for (int k = 0; k < info[count][1].Count; k++)
                    {
                        sb.Append("<a class='new-track-detail-3' href='#' title='" + info[count][1][k] + "'>" + info[count][1][k] + "</a>");
                        if (k != info[count][1].Count-1)
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

        public JsonResult FullIndex()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(HotSlider());
            sb.Append(Top_6_DJ());
            sb.Append(New_Track());
            return Json(sb.ToString());
        }

        public ActionResult Index()
        {

            Session["idRandom"] = 0;
            Session["User"] = 0;
            return View();
        }
    }
}