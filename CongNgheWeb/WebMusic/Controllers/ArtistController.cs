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
            sb.Append("<span class='detail-artist-descrip-title'>DESCRIPTION: </span>");
            sb.Append("<span id='short-text-content-artist' >" + artist.DESCRIP + "</span>");
            sb.Append("<span class='short-text-content-artist-more'>More</span>");
            sb.Append("<span class='short-text-content-artist-less'>Less</span>");
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

        public string Hot_Remix(int id, int quantity)
        {
            List<int> idRemix = db.REMIX_ARTIST.Where(p => p.ID_ARTIST == id).Distinct().Select(p => p.ID_REMIX).ToList();
            List<REMIX> listRemix;
            if (quantity == 0)
            {
                listRemix = db.REMIXes.Where(p => idRemix.Contains(p.ID)).OrderByDescending(p => p.POINT_ALL).ToList();
            }
            else
            {
                listRemix = db.REMIXes.Where(p => idRemix.Contains(p.ID)).OrderByDescending(p => p.POINT_ALL).Take(quantity).ToList();
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<span id='detail-artist-hot-remix-viewall' onclick='detailArtist_hotRemix(" + id + ")'>View All</span>");
            sb.Append("<div class='detail-artist-hot-remix-title'><span>Hot Remix This Artist</span></div>");
            sb.Append("<div class='detail-artist-hot-remix-content'>");
            sb.Append("<div class='slider-detail-artist-hot-remix' id='detail-artist-remix-id'>");
            foreach (var item in listRemix)
            {
                sb.Append("<div class='detail-artist-hot-remix'>");
                sb.Append("<div class='detail-artist-hot-remix-top'>");
                sb.Append("<img src='." + item.LINK_IMG + "'>");
                sb.Append("<div class='detail-artist-hot-remix-top-control'>");
                sb.Append("<button class='detail-artist-hot-remix-play'><i class='fa fa-play' ></i ></button>");
                sb.Append("<button class='detail-artist-hot-remix-buy'>$" + item.COST + "</button>");
                sb.Append("<button class='detail-artist-hot-remix-share'><i class='fa fa-facebook' ></i >Share</button>");
                sb.Append("</div><p></p></div>");
                sb.Append("<div class='detail-artist-hot-remix-bottom'>");
                sb.Append("<p class='detail-artist-hot-remix-name'><a href='#' onclick='ViewDetailTrackAll_fun(" + item.ID + "); return false;' >" + item.NAME + "</a></p>");

                sb.Append("<p class='detail-artist-hot-remix-artist'>");

                var lstArtist = db.REMIX_ARTIST.Where(p => p.ID_REMIX == id).Select(p => p.NAME_ARTIST).ToList();

                for(int i = 0 ; i < lstArtist.Count ; i++)
                {
                    sb.Append("<a href='#' onclick='detail_Artist(\"" + lstArtist[i] + "\"); return false;' >" + lstArtist[i] + "</a>");
                    if (i != lstArtist.Count - 1)
                    {
                        sb.Append("<span class='ft'> ft </span>");
                    }
                }
                sb.Append("</p>");

                var lstLabel = db.REMIX_ARTIST.Where(p => p.ID_REMIX == id).Select(p => p.NAME_LABEL).ToList();
                sb.Append("<p class='detail-artist-hot-remix-label'>");
                for (int k = 0; k < lstLabel.Count; k++)
                {
                    sb.Append("<a href='#' onclick='detail_Label(\"" + lstLabel[k] + "\"); return false;' >" + lstLabel[k] + "</a>");
                    if (k != lstLabel.Count - 1)
                    {
                        sb.Append("<span class='ft'> ft </span>");
                    }
                }
                sb.Append("</p>");
                sb.Append("</div></div>");
            }

            sb.Append("</div>");
            sb.Append("</div>");


            return sb.ToString();
        }

        public JsonResult Hot_Remix_Full(int id)
        {
            return Json(Hot_Remix(id, 0));
        }

        public string Hot_Track_Label(int id, int quantity)
        {

            string nameLabel = db.TRACK_ARTIST.Where(p => p.ID_ARTIST == id).Select(p => p.NAME_LABEL).FirstOrDefault();
            List<int> idTrack = db.TRACK_ARTIST.Where(p => p.NAME_LABEL == nameLabel).OrderByDescending(p => p.POINT_ALL).Take(15).Distinct().Select(p => p.ID_TRACK).ToList();
            List<TRACK> listTrack;
            if (quantity == 0)
            {
                listTrack = db.TRACKs.Where(p => idTrack.Contains(p.ID)).ToList();
            }
            else
            {
                listTrack = db.TRACKs.Where(p => idTrack.Contains(p.ID)).Take(quantity).ToList();
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<span id='detail-artist-hot-track-viewall' onclick='detailArtist_hotTrack(" + id + ")'>View All</span>");
            sb.Append("<div class='detail-artist-hot-track-title'><span>Hot Track Same Label</span></div>");
            sb.Append("<div class='detail-artist-hot-track-content'>");
            sb.Append("<div class='slider-detail-artist-hot-track' id='slider-detail-artist-track-id'>");
            foreach (var item in listTrack)
            {
                sb.Append("<div class='detail-artist-hot-track'>");
                sb.Append("<div class='detail-artist-hot-track-top'>");
                sb.Append("<img src='." + item.LINK_IMG + "'>");
                sb.Append("<div class='detail-artist-hot-track-top-control'>");
                sb.Append("<button class='detail-artist-hot-track-play'><i class='fa fa-play' ></i ></button>");
                sb.Append("<button class='detail-artist-hot-track-buy'>$" + item.COST + "</button>");
                sb.Append("<button class='detail-artist-hot-track-share'><i class='fa fa-facebook' ></i >Share</button>");
                sb.Append("</div><p></p></div>");
                sb.Append("<div class='detail-artist-hot-track-bottom'>");
                sb.Append("<p class='detail-artist-hot-track-name'><a href='#' onclick='ViewDetailTrackAll_fun(" + item.ID + "); return false;' >" + item.NAME + "</a></p>");

                sb.Append("<p class='detail-artist-hot-track-artist'>");

                var lstArtist = db.REMIX_ARTIST.Where(p => p.ID_REMIX == id).Select(p => p.NAME_ARTIST).ToList();

                for (int i = 0; i < lstArtist.Count; i++)
                {
                    sb.Append("<a href='#' onclick='detail_Artist(\"" + lstArtist[i] + "\"); return false;' >" + lstArtist[i] + "</a>");
                    if (i != lstArtist.Count - 1)
                    {
                        sb.Append("<span class='ft'> ft </span>");
                    }
                }
                sb.Append("</p>");

                var lstLabel = db.REMIX_ARTIST.Where(p => p.ID_REMIX == id).Select(p => p.NAME_LABEL).ToList();
                sb.Append("<p class='detail-artist-hot-track-label'>");
                for (int k = 0; k < lstLabel.Count; k++)
                {
                    sb.Append("<a href='#' onclick='detail_Label(\"" + lstLabel[k] + "\"); return false;' >" + lstLabel[k] + "</a>");
                    if (k != lstLabel.Count - 1)
                    {
                        sb.Append("<span class='ft'> ft </span>");
                    }
                }
                sb.Append("</p>");
                sb.Append("</div></div>");
            }

            sb.Append("</div>");
            sb.Append("</div>");



            return sb.ToString();
        }

        public JsonResult Hot_Track_Label_Full(int id)
        {
            return Json(Hot_Track_Label(id, 0));
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

            sb.Append("<div id='id_detail-artist-hot-remix' class='col-sm-12'>");
            sb.Append(Hot_Remix(id, 10));
            sb.Append("</div>");

            sb.Append("<div id='id_detail-artist-hot-track' class='col-sm-12'>");
            sb.Append(Hot_Track_Label(id,10));
            sb.Append("</div>");

            sb.Append("</div></div></div>");

            return Json(sb.ToString());
        }
    }
}