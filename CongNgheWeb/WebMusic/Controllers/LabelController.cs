using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class LabelController : Controller
    {
        MusicEntities db = new MusicEntities();

        public string Detail(Int16 id)
        {
            LABEL lb = db.LABELs.FirstOrDefault(p => p.ID == id);

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='detail-label'>");
            sb.Append("<div class='col-sm-12'>");
            sb.Append("<div class='col-sm-4 detail-label-left'><img src='.." + lb.LINK_IMG + "'></div>");
            sb.Append("<div class='col-sm-8 detail-label-right'>");
            sb.Append("<p class='detail-label-nav'>LABEL</p>");
            sb.Append("<p class='detail-label-name'>" + lb.NAME + "</p><br>");
            sb.Append("<p class='detail-label-artist-name'>FOUNDED</p>");
            sb.Append("<a href = '#' class='detail-label-artist-name'>" + lb.FOUNDED + "</a>");
            sb.Append("<br>");
            sb.Append("<p class='detail-label-release'>FOUNDER</p>");
            sb.Append("<span class='detail-label-release'>" + lb.FOUNDER + "</span>");
            sb.Append("<br>");
            sb.Append("<p class='detail-label-location'>LOCATION</p>");
            sb.Append("<a href='#' class='detail-label-location'>" + lb.LOCATION + "</a>");
            sb.Append("<div class='detail-label-genres'><p>GENRE</p>");
            var listGenre = db.GENRE_LABEL.OrderByDescending(p => p.POINT).Select(p => p.NAME_GENRE).Take(3).ToList();
            for (int i = listGenre.Count - 1; i >= 0; i--)
            {
                sb.Append("<a href='#'>" + listGenre[i] + "</a>");
                if (i != 0)
                {
                    sb.Append("<span style='color:#aaa; font-size:75%;' > ft </span>");
                }
            }
            sb.Append("</div><br>");
            sb.Append("<div class='detail-label-descrip'>");
            sb.Append("<span class='detail-label-descrip-title'>DESCRIPTION</span>");
            sb.Append("<span id='detail-label-descrip-content'>" + lb.DESCRIP + "</span>");
            sb.Append("<span class='detail-label-more'>More</span>");
            sb.Append("<span class='detail-label-less'>Less</span>");
            sb.Append("</div></div></div></div>");

            return sb.ToString();
        }

        public string Artist_Label(Int16 id)
        {
            var listArtist = db.ARTISTs.Where(p => p.ID_LABEL == id).ToList();
            var widthButton = 0.1111;
            var loop = listArtist.Count / 4 + 1;
            if (loop == 1)
            {
                widthButton = 0;
            }
            else
            {
                widthButton = (100 - (loop - 1) * 0.5) / loop;
            }

            StringBuilder sb = new StringBuilder();
            var count = 0;

            sb.Append("<style>.detail-label-artist-pages-li{width: " + widthButton + "% !important;}</style>");

            sb.Append("<div class='detail-label-artist'>");
            sb.Append("<p class='detail-label-artist-title'>Artist of this label</p>");

            for (int i = 0; i < loop; i++)
            {
                if (i == 0)
                {
                    sb.Append("<div stt='" + i + "' class='detail-label-artist-info' style='display:inline-block;' >");
                }
                else
                {
                    sb.Append("<div stt='" + i + "' class='detail-label-artist-info'>");
                }
                sb.Append("<ul>");

                for (int j = 0; j < 4; j++)
                {
                    if (listArtist.Count <= count)
                    {
                        break;
                    }

                    sb.Append("<li>");
                    sb.Append("<div class='detail-label-artist-child'>");
                    sb.Append("<img src='.." + listArtist[count].IMG + "'>");
                    sb.Append("<div class='detail-label-artist-child-control'>");
                    sb.Append("<span>Follow</span>");
                    sb.Append("<a href='" + listArtist[count].FB + "' class='detail-label-artist-child-fb'>");
                    sb.Append("<i class='fa fa-facebook'></i>");
                    sb.Append("</a>");
                    sb.Append("<a href='" + listArtist[count].TW + "' class='detail-label-artist-child-tw'>");
                    sb.Append("<i class='fa fa-twitter'></i>");
                    sb.Append("</a>");
                    sb.Append("</div>");
                    sb.Append("<div class='detail-label-artist-child-name'>");
                    sb.Append("<a href='#'>" + listArtist[count].NAME + "</a>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");

                    count++;
                }

                sb.Append("</ul>");
                sb.Append("</div>");
            }

            sb.Append("<div class='detail-label-artist-pages'>");
            sb.Append("<ul>");
            for (int i = 0; i < loop; i++)
            {
                if (i == 0)
                {
                    sb.Append("<li stt='0' class='detail-label-artist-pages-li detail-label-artist-pages-li-active'></li>");
                }
                else
                {
                    sb.Append("<li stt='" + i + "' class='detail-label-artist-pages-li'></li>");
                }
            }
            sb.Append("</ul></div></div>");

            return sb.ToString();
        }

        public string Track_Label(Int16 id)
        {
            string temp = db.LABELs.Where(p => p.ID == id).Select(p => p.NAME).FirstOrDefault();
            List<int> tempInt = db.TRACK_ARTIST.Where(p => p.NAME_LABEL == temp).OrderByDescending(p => p.POINT_ALL).Select(p => p.ID_TRACK).Take(10).Distinct().ToList();
            var listTrack = db.TRACKs.Where(p => tempInt.Contains(p.ID)).OrderByDescending(p => p.POINT_ALL).ToList();

            var widthButton = 0.1111;
            var loop = listTrack.Count / 5 + 1;
            if (loop == 1)
            {
                widthButton = 0;
            }
            else
            {
                widthButton = (100 - (loop - 1) * 0.5) / loop;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<style>.detail-label-track-button{width: " + widthButton + "% !important;}</style>");

            sb.Append("<div class='detail-label-track'>");
            sb.Append("<p class='detail-label-track-title'>Hot Track This Label</p>");

            var count = 0;

            for (int i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    sb.Append("<div stt='" + i + "' class='detail-label-track-slide'>");
                }
                else
                {
                    sb.Append("<div stt='" + i + "' class='detail-label-track-slide detail-label-track-slide-active'>");
                }
                sb.Append("<ul>");

                for (int j = 0; j < 5; j++)
                {
                    if (listTrack.Count <= count)
                    {
                        break;
                    }

                    sb.Append("<li>");
                    sb.Append("<div class='detail-label-track-child'>");
                    sb.Append("<div class='detail-label-track-child-top'>");
                    sb.Append("<img src='.." + listTrack[count].LINK_IMG + "'>");
                    sb.Append("<div class='detail-label-track-child-top-control'>");
                    sb.Append("<a href='#' class='detail-label-track-child-play'><i class='fa fa-play'></i></a>");
                    sb.Append("<button class='detail-label-track-child-buy'>$" + listTrack[count].COST + "</button>");
                    sb.Append("<a href='#' class='detail-label-track-child-share'><i class='fa fa-facebook'></i>Share</a>");
                    sb.Append("</div>");
                    sb.Append("<p></p>");
                    sb.Append("</div>");
                    sb.Append("<div class='detail-label-track-child-bottom'>");
                    sb.Append("<p class='detail-label-track-child-name'>");
                    sb.Append("<a href='#'>" + listTrack[count].NAME + "</a>");
                    sb.Append("</p>");
                    sb.Append("<p class='detail-label-track-child-artist'>");
                    var ss = listTrack[i].ID;
                    var info = db.TRACK_ARTIST.Where(p => p.ID_TRACK == ss).ToList();

                    for (int k = info.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a href='#'>" + info[k].NAME_ARTIST + "</a>");
                        if (k != 0)
                        {
                            sb.Append("<span style='color:#555;'> ft </span>");
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("<p class='detail-label-track-child-label'>");
                    for (int k = info.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a href='#'>" + info[k].NAME_LABEL + "</a>");
                        if (k != 0)
                        {
                            sb.Append("<span style='color:#555;'> ft </span>");
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

            sb.Append("</div>");

            return sb.ToString();
        }

        public JsonResult Index(string name)
        {
            var id = db.LABELs.Where(p => p.NAME == name).Select(p => p.ID).FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.Append("<link href='./Content/MainLayout_CSS/Label.css' rel='stylesheet' />");

            sb.Append("<div class='container'>");
            sb.Append("<div class='row'>");
            sb.Append("<div class='col-sm-12 detail-label-wrap>");

            sb.Append(Detail(id));
            sb.Append(Artist_Label(id));
            sb.Append(Track_Label(id));

            sb.Append("</div></div></div>");

            return Json(sb.ToString());
        }
    }
}