using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class TrackController : Controller
    {

        MusicEntities db = new MusicEntities();

        // GET: Track
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public string Detail_Track(int id)
        {
            var track = db.TRACKs.SingleOrDefault(p => p.ID == id);
            var lstArtist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == id).Select(p => p.NAME_ARTIST).ToList();
            var lstLabel = db.TRACK_ARTIST.Where(p => p.ID_TRACK == id).Select(p => p.NAME_LABEL).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='detail-song'>");
            sb.Append("<div class='col-sm-12'>");
            sb.Append("<div class='col-sm-4 detail-song-left'>");
            sb.Append("<img src='." + track.LINK_IMG + "'>");
            sb.Append("</div>");
            sb.Append("<div class='col-sm-8 detail-song-right'>");
            sb.Append("<p class='detail-song-nav'>RELEASE</p>");
            sb.Append("<p class='detail-song-name'>" + track.NAME + "</p>");
            sb.Append("<br>");
            sb.Append("<p class='artist'>ARTISTS</p>");
            for (int i = 0; i < lstArtist.Count; i++)
            {
                sb.Append("<a href='#' class='artist' title='" + lstArtist[i] + "'>" + lstArtist[i] + "</a>");
                if (i != lstArtist.Count - 1)
                {
                    sb.Append("<span style='font-size:65%; color:#666;'> ft </span>");
                }
            }

            sb.Append("<br>");
            sb.Append("<p class='release-date'>RELEASE DATE</p>");
            sb.Append("<span class='release-date'>" + track.DATE_RELEASE + "</span>");
            sb.Append("<br>");
            sb.Append("<p class='labels'>LABELS</p>");
            for (int i = 0; i < lstLabel.Count; i++)
            {
                sb.Append("<a href='#' class='labels' title='" + lstLabel[i] + "'>" + lstLabel[i] + "</a>");
            }
            sb.Append("<br>");
            sb.Append("<div class='detail-song-play-buy'>");
            sb.Append("<button class='detail-song-play' onclick='clickPlayMusicDetail(" + track.ID + ",1)'>");
            sb.Append("<i class='glyphicon glyphicon-play'></i>");
            sb.Append("</button>");
            sb.Append("<button class='detail-song-buy'>");
            sb.Append("<p>$" + track.COST + "</p>");
            sb.Append("</button>");
            sb.Append("</div>");
            sb.Append("<br>");
            sb.Append("<br>");
            sb.Append("<div class='detail-song-descrip'>");
            sb.Append("<span class='descrip-title'>DESCRIPTION</span>");
            sb.Append("<span id='short-text-content'>" + track.DESCRIPT + "</span>");
            sb.Append("<span class='short-text-content-more'>More</span>");
            sb.Append("<span class='short-text-content-less'>Less</span>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public string Track_Total(int id)
        {
            string nameTrack = db.TRACKs.Where(p => p.ID == id).Select(p => p.NAME).FirstOrDefault();

            var lstTrack = db.TRACKs.Where(p => p.NAME == nameTrack).ToList();     //list Track
            List<List<string>> lstTrackArtist = new List<List<string>>();          //list artist of track
            foreach (var item in lstTrack)
            {
                lstTrackArtist.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == item.ID).Select(p => p.NAME_ARTIST).ToList());
            }

            var lstRemix = db.REMIXes.Where(p => p.NAME == nameTrack).ToList();     //list Remix
            List<List<string>> lstRemixArtist = new List<List<string>>();           //list artist of remix
            List<List<string>> lstRemixRemixer = new List<List<string>>();          //list remixer of remix
            foreach (var item in lstRemix)
            {
                if (item.ID_TRACK != null)
                {
                    lstRemixArtist.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == item.ID_TRACK).Select(p => p.NAME_ARTIST).ToList());
                }
                else
                {
                    lstRemixArtist.Add(new List<string>());
                }
                lstRemixRemixer.Add(db.REMIX_ARTIST.Where(p => p.ID_REMIX == item.ID).Select(p => p.NAME_ARTIST).ToList());
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='col-sm-12'>");
            sb.Append("<div class='detail-song-all-track'>");
            sb.Append("<div class='detail-song-all-track-title'><span>" + (lstTrack.Count + lstRemix.Count) + " TRACKS TOTAL</span></div><br>");
            sb.Append("<div class='detail-song-all-track-content'>");
            sb.Append("<ul><li>");
            sb.Append("<div class='detail-song-all-track-play'>ORDINAL</div>");
            sb.Append("<div class='detail-song-all-track-name'>TITLE</div>");
            sb.Append("<div class='detail-song-all-track-artist'>ARTIST</div>");
            sb.Append("<div class='detail-song-all-track-remixer'>REMIXER</div>");
            sb.Append("<div class='detail-song-all-track-genre'>GENRE</div>");
            sb.Append("<div class='detail-song-all-track-bpm'>BPM</div>");
            sb.Append("<div class='detail-song-all-track-key'>KEY</div>");
            sb.Append("<div class='detail-song-all-track-length'>LENGTH</div>");
            sb.Append("<div class='detail-song-all-track-buy'>COST</div></li>");

            for (int i = 0; i < lstTrack.Count; i++)
            {
                sb.Append("<li>");
                sb.Append("<div class='detail-song-all-track-play'><span>" + (i + 1) + "</span><button><i class='fa fa-play'></i></button></div>");
                sb.Append("<div class='detail-song-all-track-name'><a href='#'>" + lstTrack[i].NAME + "</a></div>");
                sb.Append("<div class='detail-song-all-track-artist'>");
                foreach (var item in lstTrackArtist[i])
                {
                    sb.Append("<a href='#'>" + item + "</a>");
                }
                sb.Append("</div>");
                sb.Append("<div class='detail-song-all-track-remixer'><a href='#'></a></div>");
                sb.Append("<div class='detail-song-all-track-genre'><a href='#'>" + lstTrack[i].GENRE + "</a></div>");
                sb.Append("<div class='detail-song-all-track-bpm'><span>" + lstTrack[i].TEMPO + "</span></div>");
                sb.Append("<div class='detail-song-all-track-key'><span>" + lstTrack[i].KEY_ + "</span></div>");
                sb.Append("<div class='detail-song-all-track-length'><span>" + lstTrack[i].LENGTH + "</span></div>");
                sb.Append("<div class='detail-song-all-track-buy'><button>$" + lstTrack[i].COST + "</button></div>");
                sb.Append("</li>");
            }

            for (int i = 0; i < lstRemix.Count; i++)
            {
                sb.Append("<li>");
                sb.Append("<div class='detail-song-all-track-play'><span>" + (i + 1) + "</span><button><i class='fa fa-play'></i></button></div>");
                sb.Append("<div class='detail-song-all-track-name'><a href='#'>" + lstRemix[i].NAME + "</a></div>");
                sb.Append("<div class='detail-song-all-track-artist'>");
                foreach (var item in lstRemixArtist[i])
                {
                    sb.Append("<a href='#'>" + item + "</a>");
                }
                sb.Append("</div>");
                sb.Append("<div class='detail-song-all-track-remixer'>");
                foreach (var item in lstRemixRemixer[i])
                {
                    sb.Append("<a href='#'>" + item + "</a>");
                }
                sb.Append("</div>");
                sb.Append("<div class='detail-song-all-track-genre'><a href='#'>" + lstRemix[i].GENRE + "</a></div>");
                sb.Append("<div class='detail-song-all-track-bpm'><span>" + lstRemix[i].TEMPO + "</span></div>");
                sb.Append("<div class='detail-song-all-track-key'><span>" + lstRemix[i].KEY_ + "</span></div>");
                sb.Append("<div class='detail-song-all-track-length'><span>" + lstRemix[i].LENGTH + "</span></div>");
                sb.Append("<div class='detail-song-all-track-buy'><button>$" + lstRemix[i].COST + "</button></div>");
                sb.Append("</li>");
            }

            sb.Append("</ul></div></div></div>");

            return (sb.ToString());
        }

        public string More_Track_Artist(int id)       //id la id cua track -> lay id artist tu do 
        {

            List<TRACK> lstTrack = new List<TRACK>();
            List<List<string>> lstArtist = new List<List<string>>();
            List<List<string>> lstLabel = new List<List<string>>();

            //lay id cua tat ca cac artist tham gia
            List<int> tempIdArtist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == id).Select(p => p.ID_ARTIST).ToList();
            //lay id cua tat ca cac track cua cac artist do
            List<int> allIdTrackArtist = db.TRACK_ARTIST.Where(x => tempIdArtist.Contains(x.ID_ARTIST)).OrderByDescending(p => p.COST).Select(x => x.ID_TRACK).ToList();
            allIdTrackArtist.RemoveAll(x => x == id);
            allIdTrackArtist = allIdTrackArtist.Distinct().ToList();

            foreach (var i in allIdTrackArtist)
            {
                lstTrack.Add(db.TRACKs.Where(p => p.ID == i).FirstOrDefault());
                lstArtist.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == i).Select(p => p.NAME_ARTIST).ToList());
                lstLabel.Add(db.TRACK_ARTIST.Where(p => p.ID_TRACK == i).Select(p => p.NAME_LABEL).ToList());
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='col-sm-12 detail-song-artist'>");
            sb.Append("<div class='detail-song-artist-title'><span>More Track This Artist</span></div>");
            sb.Append("<div class='detail-song-artist-content'>");
            sb.Append("<div class='slider-detail-song-artist'>");
            for (int i = 0; i < lstTrack.Count; i++)
            {
                sb.Append("<div class='detail-song-artist-song'>");
                sb.Append("<div class='detail-song-artist-song-top'>");
                sb.Append("<img src='." + lstTrack[i].LINK_IMG + "'>");
                sb.Append("<div class='detail-song-artist-song-top-control'>");
                sb.Append("<button class='detail-song-artist-song-play'><i class='fa fa-play' ></i ></button>");
                sb.Append("<button class='detail-song-artist-song-buy'>$" + lstTrack[i].COST + "</button>");
                sb.Append("<button class='detail-song-artist-song-share'><i class='fa fa-facebook' ></i >Share</button>");
                sb.Append("</div><p></p></div>");
                sb.Append("<div class='detail-song-artist-song-bottom'>");
                sb.Append("<p class='detail-song-artist-song-name'><a href='#'>" + lstTrack[i].NAME + "</a></p>");

                sb.Append("<p class='detail-song-artist-song-artist'>");
                for (int k = 0; k < lstArtist[i].Count; k++)
                {
                    sb.Append("<a href='#'>" + lstArtist[i][k] + "</a>");
                    if (k != lstArtist[i].Count - 1)
                    {
                        sb.Append("<span style='color:#666;'> ft </span>");
                    }
                }
                sb.Append("</p>");
                sb.Append("<p class='detail-song-artist-song-label'>");
                for (int k = 0; k < lstLabel[i].Count; k++)
                {
                    sb.Append("<a href='#'>" + lstLabel[i][k] + "</a>");
                    if (k != lstLabel[i].Count - 1)
                    {
                        sb.Append("<span style='color:#666;'> ft </span>");
                    }
                }
                sb.Append("</p>");
                sb.Append("</div></div>");
            }

            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");



            return sb.ToString();
        }

        public string More_Track_Label(int id)       //id la id cua track -> lay id artist tu do 
        {

            List<List<string>> listTrack = new List<List<string>>();
            List<List<List<string>>> listInfo = new List<List<List<string>>>();

            //lay name cua tat ca cac label tham gia
            List<string> tempIdArtist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == id).Select(p => p.NAME_LABEL).ToList();
            tempIdArtist = tempIdArtist.Distinct().ToList();
            //lay id cua tat ca cac track cua cac label do
            List<int> allIdTrackLabel = db.TRACK_ARTIST.Where(x => tempIdArtist.Contains(x.NAME_LABEL)).OrderByDescending(p => p.COST).Select(x => x.ID_TRACK).ToList();
            allIdTrackLabel.RemoveAll(x => x == id);
            allIdTrackLabel = allIdTrackLabel.Distinct().ToList();

            List<TRACK> lstTrack = new List<TRACK>();
            List<List<string>>lstArtist = new List<List<string>>();
            List<List<string>>lstLabel = new List<List<string>>();

            foreach (var i in allIdTrackLabel)
            {
                lstTrack.Add(db.TRACKs.FirstOrDefault(p => p.ID==i));
                lstArtist.Add(db.TRACK_ARTIST.Where(p=>p.ID_TRACK==i).Select(p=>p.NAME_ARTIST).ToList());
                lstLabel.Add(db.TRACK_ARTIST.Where(p=>p.ID_TRACK==i).Select(p=>p.NAME_LABEL).ToList());
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='col-sm-12 detail-song-label'>");
            sb.Append("<div class='detail-song-label-title'><span>More Track This Label</span></div>");
            sb.Append("<div class='detail-song-label-content'>");
            sb.Append("<div class='slider-detail-song-label'>");

            for (int i = 0; i < lstTrack.Count; i++)
            {
                sb.Append("<div class='detail-song-label-song'>");
                sb.Append("<div class='detail-song-label-song-top'>");
                sb.Append("<img src = '." + lstTrack[i].LINK_IMG + "' alt=''>");
                sb.Append("<div class='detail-song-label-song-top-control'>");
                sb.Append("<button class='detail-song-label-song-play'><i class='fa fa-play'></i></button>");
                sb.Append("<button class='detail-song-label-song-buy'>$" + lstTrack[i].COST + "</button>");
                sb.Append("<button class='detail-song-label-song-share'><i class='fa fa-facebook'></i>Share</button>");
                sb.Append("</div><p></p></div>");
                sb.Append("<div class='detail-song-label-song-bottom'>");
                sb.Append("<p class='detail-song-label-song-name'><a href='#'>" + lstTrack[i].NAME + "</a></p>");
                sb.Append("<p class='detail-song-label-song-artist'>");
                for(int k = 0 ; k < lstArtist[i].Count ; k++)
                {
                    sb.Append("<a href='#'>" + lstArtist[i][k] + "</a>");
                    if (k != lstArtist[i].Count - 1)
                    {
                        sb.Append("<span style='color: #666;'> ft </span>");
                    }
                }
                                            sb.Append("</p>");
                sb.Append("<p class='detail-song-label-song-label'>");
                for (int k = 0; k < lstLabel[i].Count; k++)
                {
                    sb.Append("<a href='#'>" + lstLabel[i][k] + "</a>");
                    if (k != lstLabel[i].Count - 1)
                    {
                        sb.Append("<span style='color:#666;'> ft </span>");
                    }
                }
                sb.Append("</p></div></div>");
            }
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");


            return sb.ToString();
        }

        public string VisualizeMusicPlaying()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div id='visualizeMusic'>");

            sb.Append("<canvas id='analyser_render'>");
            sb.Append("</canvas>");

            sb.Append("</div>");

            return sb.ToString();
        }

        public JsonResult AllIndex(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='container'>");
            sb.Append("<div class='row'>");
            sb.Append("<div class='col-sm-12 detail-song-wrap'>");

            sb.Append(VisualizeMusicPlaying());
            sb.Append(Detail_Track(id));
            sb.Append(Track_Total(id));
            sb.Append(More_Track_Artist(id));
            sb.Append(More_Track_Label(id));

            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return Json(sb.ToString());
        }
    }
}