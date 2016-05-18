using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class ArtistController : Controller
    {
        MusicEntities db = new MusicEntities();

        public string Detail_Artist(int id)
        {
            ARTIST artist = db.ARTISTs.FirstOrDefault(p => p.ID == id);
            var genre = db.GENRE_ARTIST.Where(p => p.ID_ARTIST == id).OrderByDescending(p => p.POINT).Select(p => p.NAME_GENRE).Take(3).ToList();

            StringBuilder sb = new StringBuilder();


            sb.Append("<div class='detail-artist'>");
            sb.Append("<div class='col-sm-12'>");
            sb.Append("<div class='col-sm-4 detail-artist-left'>");
            sb.Append("<img src='." + artist.IMG + "'>");
            sb.Append("</div>");
            sb.Append("<div class='col-sm-8 detail-artist-right'>");
            sb.Append("<p class='detail-artist-nav'>ARTIST</p>");
            sb.Append("<p class='detail-artist-name'>" + artist.NAME + "</p>");
            sb.Append("<br>");
            sb.Append("<p class='detail-artist-genres'>GENRES</p>");
            foreach (var item in genre)
            {
                sb.Append("<a href='#' class='detail-artist-genres'>" + item + "</a>");
                sb.Append("<span> . </span>");
            }
            sb.Append("<br>");

            sb.Append("<p class='detail-artist-release'>Birthday</p>");
            sb.Append("<span class='detail-artist-release'>" + artist.DATE.Value.Date + "</span>");
            sb.Append("<br>");

            sb.Append("<p class='detail-artist-label'>LABELS</p>");
            sb.Append("<a href='#' class='detail-artist-label'>" + artist.NAME_LABEL + "</a>");
            sb.Append("<br>");
            sb.Append("<div class='detail-artist-descrip'>");
            sb.Append("<span class='detail-artist-descrip-title'>DESCRIPTION</span>");
            sb.Append("<span id='detail-artist-descrip-content' >" + artist.DESCRIP + "</span>");
            sb.Append("<span class='detail-artist-more'>More</span>");
            sb.Append("<span class='detail-artist-less'>Less</span>");
            sb.Append("</div>");
            sb.Append("<div class='detail-artist-follow'>");
            sb.Append("<p>Follow</p>");
            sb.Append("<a target='_blank' href='" + artist.FB + "' class='detail-artist-fb'><i class='fa fa-facebook'></i></a>");
            sb.Append("<a target='_blank' href='" + artist.TW + "' class='detail-artist-tw'><i class='fa fa-twitter'></i></a>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public string Total_Track_Artist(int id)
        {
            List<int> idTrack = db.TRACK_ARTIST.Where(p => p.ID_ARTIST == id).Select(p => p.ID_TRACK).ToList();
            List<TRACK> trackTotal = db.TRACKs.Where(p => idTrack.Contains(p.ID)).OrderByDescending(p => p.POINT_ALL).Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='track-total'>");
            sb.Append("<div class='col-sm-12'>");
            sb.Append("<div class='detail-artist-total-track'>");
            sb.Append("<div class='detail-artist-total-track-title'>");
            sb.Append("<span>3 TRACKS TOTAL</span>");
            sb.Append("</div>");
            sb.Append("<br>");
            sb.Append("<div class='detail-artist-total-track-content'>");
            sb.Append("<ul>");
            sb.Append("<li>");
            sb.Append("<div class='detail-artist-total-track-play'>ORDINAL</div>");
            sb.Append("<div class='detail-artist-total-track-name'>TITLE</div>");
            sb.Append("<div class='detail-artist-total-track-artist'>ARTIST</div>");
            sb.Append("<div class='detail-artist-total-track-remixer'>REMIXER</div>");
            sb.Append("<div class='detail-artist-total-track-genre'>GENRE</div>");
            sb.Append("<div class='detail-artist-total-track-bpm'>BPM</div>");
            sb.Append("<div class='detail-artist-total-track-key'>KEY</div>");
            sb.Append("<div class='detail-artist-total-track-length'>LENGTH</div>");
            sb.Append("<div class='detail-artist-total-track-buy'>COST</div>");
            sb.Append("</li>");
            for (var i = 0; i < trackTotal.Count; i++)
            {
                sb.Append("<li>");
                sb.Append("<div class='detail-artist-total-track-play'>");
                sb.Append("<span>" + i + 1 + "</span>");
                sb.Append("<button><i class='fa fa-play'></i></button>");
                sb.Append("</div>");
                sb.Append("<div class='detail-artist-total-track-name'><a href='#'>" + trackTotal[i].NAME + "</a>");
                sb.Append("</div>");
                sb.Append("<div class='detail-artist-total-track-artist'>");
                var ss = trackTotal[i].ID;
                var artistTemp = db.TRACK_ARTIST.Where(p => p.ID_TRACK == ss).Select(p => p.NAME_ARTIST).ToList();
                foreach (var item in artistTemp)
                {
                    sb.Append("<a href='#' > " + item + " </a>");
                }
                sb.Append("</div>");
                sb.Append("<div class='detail-artist-total-track-remixer'><a href='#'></a></div>");
                sb.Append("<div class='detail-artist-total-track-genre'><a href='#'>" + trackTotal[i].GENRE + "</a></div>");

                sb.Append("<div class='detail-artist-total-track-bpm'><span>" + trackTotal[i].TEMPO + "</span></div>");
                sb.Append("<div class='detail-artist-total-track-key'><span>" + trackTotal[i].KEY_ + "</span></div>");
                sb.Append("<div class='detail-artist-total-track-length'><span>" + trackTotal[i].LENGTH + "</span></div>");
                sb.Append("<div class='detail-artist-total-track-buy'><button>$" + trackTotal[i].COST + "</button></div>");
                sb.Append("</li>");
            }

            sb.Append("</ul></div></div></div></div>");


            return sb.ToString();
        }

        public string Hot_Remix(int id)
        {
            List<int> idRemix = db.REMIX_ARTIST.Where(p => p.ID_ARTIST == id).Distinct().Select(p => p.ID_REMIX).ToList();
            List<REMIX> listRemix = db.REMIXes.Where(p => idRemix.Contains(p.ID)).OrderByDescending(p => p.POINT_ALL).Take(10).ToList();
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='detail-artist-remix'>");
            sb.Append("<p class='detail-artist-remix-title'>Hot Remix This Artist</p>");
            sb.Append("<div class='detail-artist-remix-content'>");
            var count = 0;
            for (int i = 0; i < 2; i++)
            {
                sb.Append("<div stt='" + i + "' class='detail-artist-remix-slide'>");
                sb.Append("<ul>");

                for (int j = 0; j < 5; j++)
                {
                    if (listRemix.Count <= count)
                    {
                        break;
                    }
                    sb.Append("<li>");
                    sb.Append("<div class='detail-artist-remix-child'>");
                    sb.Append("<div class='detail-artist-remix-child-top'>");
                    sb.Append("<img src='." + listRemix[count].LINK_IMG + "'>");
                    sb.Append("<div class='detail-artist-remix-child-control'>");
                    sb.Append("<button class='detail-artist-remix-child-play'><i class='fa fa-play'></i></button>");
                    sb.Append("<button class='detail-artist-remix-child-buy'>$" + listRemix[count].COST + "</button>");
                    sb.Append("<button class='detail-artist-remix-child-share'><i class='fa fa-facebook'></i>Share</button>");
                    sb.Append("</div>");
                    sb.Append("<p></p>");
                    sb.Append("</div>");
                    sb.Append("<div class='detail-artist-remix-child-bottom'>");
                    sb.Append("<p class='detail-artist-remix-child-name'><a href='#'>" + listRemix[count].NAME + " (Remix)</a></p>");
                    sb.Append("<p class='detail-artist-remix-child-artist'>");
                    var ss = listRemix[count].ID;
                    var trackartist = db.REMIX_ARTIST.Where(p => p.ID_REMIX == ss).ToList();
                    for (int k = trackartist.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a href='#'>" + trackartist[k].NAME_ARTIST + "</a>");
                        if (k != 0)
                        {
                            sb.Append("<span> ft </span>");
                        }
                    }
                    sb.Append("</p>");
                    sb.Append("<p class='detail-artist-remix-child-label'>");
                    for (int k = trackartist.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a href='#'>" + trackartist[k].NAME_LABEL + "</a>");
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
                sb.Append("</div>");
            }

            sb.Append("<div class='detail-artist-remix-slider-control'>");
            
            if (listRemix.Count > 5)
            {
                sb.Append("<div stt='0' class='detail-artist-remix-slider-button-active detail-artist-remix-slider-button'></div>");
                sb.Append("<div stt='1' class='detail-artist-remix-slider-button'></div>");
            }
            sb.Append("</div>");
            sb.Append("</div></div>");

            return sb.ToString();
        }

        public string Hot_Track_Label(int id)
        {

            string nameLabel = db.TRACK_ARTIST.Where(p => p.ID_ARTIST == id).Select(p => p.NAME_LABEL).FirstOrDefault();
            List<int> idTrack = db.TRACK_ARTIST.Where(p => p.NAME_LABEL == nameLabel).OrderByDescending(p => p.POINT_ALL).Take(15).Distinct().Select(p => p.ID_TRACK).ToList();
            List<TRACK> listTrack = db.TRACKs.Where(p => idTrack.Contains(p.ID)).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='detail-artist-trackLabel'>");
            sb.Append("<p class='detail-artist-trackLabel-title'>Hot Track Same Label</p>");
            sb.Append("<div class='detail-artist-trackLabel-content'>");

            var count = 0;
            for (int i = 0; i < 3; i++)
            {
                sb.Append("<div stt='" + i + "' class='detail-artist-trackLabel-slide'>");
                sb.Append("<ul>");

                for (int j = 0; j < 5; j++)
                {
                    if (listTrack.Count <= count)
                    {
                        break;
                    }

                    sb.Append("<li>");
                    sb.Append("<div class='detail-artist-trackLabel-child'>");
                    sb.Append("<div class='detail-artist-trackLabel-child-top'>");
                    sb.Append("<img src='." + listTrack[count].LINK_IMG + "'>");
                    sb.Append("<div class='detail-artist-trackLabel-child-control'>");
                    sb.Append("<button class='detail-artist-trackLabel-child-play'><i class='fa fa-play'></i></button>");
                    sb.Append("<button class='detail-artist-trackLabel-child-buy'>$" + listTrack[count].COST + "</button>");
                    sb.Append("<button class='detail-artist-trackLabel-child-share'><i class='fa fa-facebook'></i>Share</button>");
                    sb.Append("</div>");
                    sb.Append("<p></p>");
                    sb.Append("</div>");
                    sb.Append("<div class='detail-artist-trackLabel-child-bottom'>");
                    sb.Append("<p class='detail-artist-trackLabel-child-name'><a href='#'>" + listTrack[count].NAME + "</a></p>");
                    sb.Append("<p class='detail-artist-trackLabel-child-artist'>");
                    var ss = listTrack[count].ID;
                    var artist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == ss).ToList();
                    for (int k = artist.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a href='#'>" + artist[k].NAME_ARTIST + "</a>");
                    }
                    sb.Append("</p>");
                    sb.Append("<p class='detail-artist-trackLabel-child-label'>");

                    for (int k = artist.Count - 1; k >= 0; k--)
                    {
                        sb.Append("<a href='#'>" + artist[k].NAME_LABEL + "</a>");
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

            sb.Append("<div class='detail-artist-trackLabel-slider-control'>");
            sb.Append("<div stt='0' class='detail-artist-trackLabel-slider-button-active detail-artist-trackLabel-slider-button'></div>");
            if (listTrack.Count > 5)
            {
                sb.Append("<div stt='1' class='detail-artist-trackLabel-slider-button'></div>");
            }
            if (listTrack.Count > 10)
            {
                sb.Append("<div stt='2' class='detail-artist-trackLabel-slider-button'></div>");
            }

            sb.Append("</div>");

            sb.Append("</div>");
            sb.Append("</div>");


            return sb.ToString();
        }

        public JsonResult Index(string artistName)
        {
            var id = db.ARTISTs.Where(p => p.NAME == artistName).Select(p => p.ID).FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.Append("<link href='./Content/MainLayout_CSS/Artist.css' rel='stylesheet'/>");
            sb.Append("<div class='container'>");
            sb.Append("<div class='row'>");
            sb.Append("<div class='col-sm-12 detail-artist-wrap'>");

            sb.Append(Detail_Artist(id));
            sb.Append(Total_Track_Artist(id));
            sb.Append(Hot_Remix(id));
            sb.Append(Hot_Track_Label(id));

            sb.Append("</div></div></div>");

            return Json(sb.ToString());
        }
    }
}