using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class SearchController : Controller
    {
        MusicEntities db = new MusicEntities();

        // GET: Searchsearch-tracks-page
        public JsonResult Search(string keyWord)
        {
            if (keyWord == null)
            {
                return Json("");
            }

            StringBuilder sb = new StringBuilder();

            //lay du lieu cho Track
            var temp1 = db.TRACKs.Where(p => p.FULL_NAME.StartsWith(keyWord)).Select(p => new { p.ID, p.FULL_NAME }).OrderBy(p => p.FULL_NAME).Take(5).ToList();
            if (temp1.Count > 0)
            {
                sb.Append("<div class='show-search-child'>");
                sb.Append("<div class='show-search-title'>");
                sb.Append("<i class='fa fa-music search-title-icon' aria-hidden='true'></i>");
                sb.Append("<span class='show-search-type'>Track</span>");
                sb.Append("</div>");
                sb.Append("<div class='show-search-content'>");
                foreach (var item in temp1)
                {
                    sb.Append("<div class='show-search-value' idd='" + item.ID + "'>" + item.FULL_NAME + "</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
            }

            //lay du lieu cho Remix
            var temp2 = db.REMIXes.Where(p => p.FULL_ARTIST.StartsWith(keyWord)).Select(p => new { p.ID, p.FULL_ARTIST }).OrderBy(p => p.FULL_ARTIST).Take(5).ToList();
            if (temp2.Count > 0)
            {
                sb.Append("<div class='show-search-child'>");
                sb.Append("<div class='show-search-title'>");
                sb.Append("<i class='fa fa-music search-title-icon' aria-hidden='true'></i>");
                sb.Append("<span class='show-search-type'>Remix</span>");
                sb.Append("</div>");
                sb.Append("<div class='show-search-content'>");
                foreach (var item in temp2)
                {
                    sb.Append("<div class='show-search-value' idd='" + item.ID + "'>" + item.FULL_ARTIST + "</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
            }

            //lay du lieu cho Artist
            var temp3 = db.ARTISTs.Where(p => p.NAME.StartsWith(keyWord)).Select(p => new { p.ID, p.NAME }).Take(5).OrderBy(p => p.NAME).ToList();
            if (temp3.Count > 0)
            {
                sb.Append("<div class='show-search-child'>");
                sb.Append("<div class='show-search-title'>");
                sb.Append("<i class='fa fa-music search-title-icon' aria-hidden='true'></i>");
                sb.Append("<span class='show-search-type'>Artist</span>");
                sb.Append("</div>");
                sb.Append("<div class='show-search-content'>");
                foreach (var item in temp3)
                {
                    sb.Append("<div class='show-search-value' idd='" + item.ID + "'>" + item.NAME + "</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
            }

            //lay du lieu cho Label
            var temp4 = db.LABELs.Where(p => p.NAME.StartsWith(keyWord)).Select(p => new { p.ID, p.NAME }).Take(5).OrderBy(p => p.NAME).ToList();
            if (temp4.Count > 0)
            {
                sb.Append("<div class='show-search-child'>");
                sb.Append("<div class='show-search-title'>");
                sb.Append("<i class='fa fa-music search-title-icon' aria-hidden='true'></i>");
                sb.Append("<span class='show-search-type'>Label</span>");
                sb.Append("</div>");
                sb.Append("<div class='show-search-content'>");
                foreach (var item in temp4)
                {
                    sb.Append("<div class='show-search-value' idd='" + item.ID + "'>" + item.NAME + "</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
            }

            //lay du lieu cho Genre
            var temp5 = db.GENREs.Where(p => p.NAME.StartsWith(keyWord)).Select(p => new { p.ID, p.NAME }).Take(5).OrderBy(p => p.NAME).ToList();
            if (temp5.Count > 0)
            {
                sb.Append("<div class='show-search-child'>");
                sb.Append("<div class='show-search-title'>");
                sb.Append("<i class='fa fa-music search-title-icon' aria-hidden='true'></i>");
                sb.Append("<span class='show-search-type'>Genre</span>");
                sb.Append("</div>");
                sb.Append("<div class='show-search-content'>");
                foreach (var item in temp5)
                {
                    sb.Append("<div class='show-search-value' idd='" + item.ID + "'>" + item.NAME + "</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
            }

            return Json(sb.ToString());
        }

        public string TrackSearch(string keyWord , bool isFull)
        {
            StringBuilder sb = new StringBuilder();
            //add du lieu cho track
            var temp1 = db.TRACKs.Select(p => new { p.ID, p.NAME, p.COST, p.LINK_IMG }).Take(2).ToList();
            if (isFull)
            {
                temp1 = db.TRACKs.Where(p => p.NAME.StartsWith(keyWord)).Select(p => new { p.ID, p.NAME, p.COST, p.LINK_IMG }).OrderBy(p => p.NAME).ToList();
            }
            else
            {
                temp1 = db.TRACKs.Where(p => p.NAME.StartsWith(keyWord)).Select(p => new { p.ID, p.NAME, p.COST, p.LINK_IMG }).OrderBy(p => p.NAME).Take(6).ToList();
            }
            
            string strTemp = "";
            List<string> lstTemp = new List<string>();
            if (temp1.Count > 0)
            {
                foreach (var item in temp1)
                {
                    sb.Append("<div class='col-sm-2-search-track'>");
                    sb.Append("<div class='song-vertical'>");
                    sb.Append("<div class='song-vertical-top'>");
                    if (item.LINK_IMG[0] == '~')
                    {
                        strTemp = item.LINK_IMG.TrimStart('~');
                        strTemp = '.' + strTemp;
                        sb.Append("<img src = '" + strTemp + "' alt=''>");
                    }
                    else
                    {
                        sb.Append("<img src = '" + item.LINK_IMG + "' alt=''>");
                    }
                    sb.Append("<div class='song-vertical-top-control'>");
                    sb.Append("<button class='song-vertical-play'><i class='fa fa-play'></i></button>");
                    sb.Append("<button class='song-vertical-buy'>$" + item.COST + "</button>");
                    sb.Append("<button class='song-vertical-share'><i class='fa fa-facebook'></i>Share</button>");
                    sb.Append("</div>");
                    sb.Append("<p></p>");
                    sb.Append("</div>");
                    sb.Append("<div class='song-vertical-bottom'>");
                    sb.Append("<p class='wrap-name-level'><a class='name-level-1' href='#'>" + item.NAME + "</a></p>");
                    //artist
                    sb.Append("<p class='wrap-name-level'>");
                    lstTemp = db.TRACK_ARTIST.Where(p => p.ID_TRACK == item.ID).Select(p => p.NAME_ARTIST).ToList();
                    for (int item1 = 0; item1 < lstTemp.Count; item1++)
                    {
                        sb.Append("<a class='name-level-2' href='#'>" + lstTemp[item1] + "</a>");
                        if (item1 != lstTemp.Count - 1)
                        {
                            sb.Append("<span class='name-level-2' style='color:#888 !important;'> ft </span>");
                        }
                    }
                    sb.Append("</p>");
                    //label
                    sb.Append("<p class='wrap-name-level'>");
                    lstTemp = db.TRACK_ARTIST.Where(p => p.ID_TRACK == item.ID).Select(p => p.NAME_LABEL).ToList();
                    for (int item1 = 0; item1 < lstTemp.Count; item1++)
                    {
                        sb.Append("<a class='name-level-3' href='#'>" + lstTemp[item1] + "</a>");
                        if (item1 != lstTemp.Count - 1)
                        {
                            sb.Append("<span class='name-level-3'  style='color:#888 !important;'> ft </span>");
                        }
                    }
                    sb.Append("</p>");

                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
            }

            return sb.ToString();
        }

        public string trackTotal(string keyWord , bool isFull)
        {
            StringBuilder sb = new StringBuilder();
            var temp = db.REMIXes.Take(2).ToList();
            if (isFull)
            {
                temp = db.REMIXes.Where(p => p.NAME.StartsWith(keyWord)).OrderBy(p => p.NAME).ToList();
            }
            else
            {
                temp = db.REMIXes.Where(p => p.NAME.StartsWith(keyWord)).OrderBy(p => p.NAME).Take(6).ToList();
            }
            
            if (temp.Count > 0)
            {
                sb.Append("<div class='col-sm-12'>");
                sb.Append("<p class='detail-song-track-total-title'>");
                sb.Append("<span style='float:left;'>6 Song Remix</span>");
                sb.Append("<span style='float:right; color:#888; font-size:64%; cursor:pointer;' id='searchRemixAllView' onclick='searchRemixAllView()' keyword='" + keyWord + "' >VIEW ALL</span>");
                sb.Append("</p>");
                sb.Append("<ul>");
                sb.Append("<li class='detail-song-row-title'>");
                sb.Append("<div class='col-sm-12'>");
                sb.Append("<div class='col-sm-1'></div>");
                sb.Append("<div class='col-sm-2'>TITLE</div>");
                sb.Append("<div class='col-sm-2'>ARTIST</div>");
                sb.Append("<div class='col-sm-2'>REMIXERS</div>");
                sb.Append("<div class='col-sm-1'>GENRE</div>");
                sb.Append("<div class='col-sm-1'>BPM</div>");
                sb.Append("<div class='col-sm-1'>KEY</div>");
                sb.Append("<div class='col-sm-1'>LENGTH</div>");
                sb.Append("<div class='col-sm-1'></div>");
                sb.Append("</div>");
                sb.Append("</li>");
                sb.Append("</ul>");

                sb.Append("<ul id='searchRemixAllPage'  style='height:380px;'>");
                for (int item = 0; item < temp.Count; item++)
                {
                    sb.Append("<li>");
                    sb.Append("<div class='col-sm-12'>");
                    sb.Append("<div class='col-sm-1 detail-song-track-total-col-play'>");
                    sb.Append("<span>" + (item + 1) + "</span>");
                    sb.Append("<button><i class='glyphicon glyphicon-play'></i></button>");
                    sb.Append("</div>");
                    sb.Append("<div class='col-sm-2 detail-song-track-total-col-name'><a href ='#'>" + temp[item].NAME + "</a></div>");

                    //artist
                    sb.Append("<div class='col-sm-2 detail-song-track-total-col-artist'>");
                    int sss = (int)temp[item].ID_TRACK;
                    var lstTemp = db.TRACK_ARTIST.Where(p => p.ID_TRACK == sss).Select(p => p.NAME_ARTIST).ToList();
                    for (int i = 0; i < lstTemp.Count; i++)
                    {
                        if (i != lstTemp.Count - 1)
                        {
                            sb.Append("<a href = '#' >" + lstTemp[i] + "</a>" + " ft ");
                        }
                        else
                        {
                            sb.Append("<a href = '#' >" + lstTemp[i] + "</a>");
                        }
                    }
                    sb.Append("</div>");


                    sb.Append("<div class='col-sm-2 detail-song-track-total-col-remixer'>");
                    sss = (int) temp[item].ID;
                    lstTemp = db.REMIX_ARTIST.Where(p => p.ID_REMIX == sss).Select(p => p.NAME_ARTIST).ToList();
                    for (int i = 0; i < lstTemp.Count; i++)
                    {
                        if (i != lstTemp.Count - 1)
                        {
                            sb.Append("<a href = '#' >" + lstTemp[i] + "</a>" + " ft ");
                        }
                        else
                        {
                            sb.Append("<a href = '#' >" + lstTemp[i] + "</a>");
                        }
                    }
                    sb.Append("</div>");

                    sb.Append("<div class='col-sm-1 detail-song-track-total-col-genre'><a href = '#' >" + temp[item].GENRE + "</a></div>");
                    sb.Append("<div class='col-sm-1 detail-song-track-total-col-bpm'>" + temp[item].TEMPO + "</div>");
                    sb.Append("<div class='col-sm-1 detail-song-track-total-col-key'>" + temp[item].KEY_ + "</div>");
                    sb.Append("<div class='col-sm-1 detail-song-track-total-col-length'>" + temp[item].LENGTH + "</div>");
                    sb.Append("<div class='col-sm-1 detail-song-track-total-col-cost'>");
                    sb.Append("<button>$" + temp[item].COST + "</button>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</li>");
                }

                sb.Append("</ul>");
                sb.Append("</div>");
            }
            return (sb.ToString());
        }

        public string searchLabel(string keyWord,bool isFull)
        {
            StringBuilder sb = new StringBuilder();
            string strTemp = "";
            var temp = db.LABELs.Select(p=> new {p.NAME , p.LINK_IMG,p.ID}).Take(2).ToList();
            if (isFull)
            {
                temp =
                    db.LABELs.Where(p => p.NAME.StartsWith(keyWord))
                        .Select(p => new {p.NAME, p.LINK_IMG, p.ID})
                        .OrderBy(p => p.NAME)
                        .ToList();
            }
            else
            {
                temp = db.LABELs.Where(p => p.NAME.StartsWith(keyWord)).Select(p => new { p.NAME, p.LINK_IMG, p.ID }).OrderBy(p => p.NAME).Take(4).ToList();
            }

            if (temp != null)
            {
                sb.Append("<div class='search-label'>");
                sb.Append("<div class='col-sm-12'>");

                sb.Append("<div class='search-label-title'>");
                sb.Append("<span>LABEL</span>");
                sb.Append("<a href = '#' > VIEW ALL</a>");
                sb.Append("</div>");
                for (int item = 0; item < temp.Count; item++)
                {
                    sb.Append("<div class='col-sm-3'>");
                    sb.Append("<div class='search-label-detail'>");
                    sb.Append("<img src = '" + temp[item].LINK_IMG +"' alt=''>");
                    sb.Append("<p class='search-label-name' idd='" + temp[item].ID + "'><a href ='#'>" + temp[item].NAME + "</a></p>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
            }

            return sb.ToString();
        }

        public string searchArtist(string keyWord , bool isFull)
        {
            StringBuilder sb = new StringBuilder();
            string strTemp = "";
            var temp = db.ARTISTs.Select(p => new { p.NAME, p.IMG, p.ID }).Take(2).ToList();
            if (isFull)
            {
                temp =
                    db.ARTISTs.Where(p => p.NAME.StartsWith(keyWord))
                        .Select(p => new {p.NAME, p.IMG, p.ID})
                        .OrderBy(p => p.NAME)
                        .ToList();
            }
            else
            {
                temp = db.ARTISTs.Where(p => p.NAME.StartsWith(keyWord)).Select(p => new { p.NAME, p.IMG, p.ID }).OrderBy(p => p.NAME).Take(6).ToList();
            }
            if (temp.Count > 0)
            {
                sb.Append("<div class='col-sm-12'>");
                sb.Append("<div class='search-artist-title'>");
                sb.Append("<span>ARTIST</span>");
                sb.Append("<a href = '#' class='search-artist-viewall' id='searchArtistButtonView' onclick='searchArtistAllView_fun()' keyword='" + keyWord + "'>VIEW ALL</a>");
                sb.Append("</div>");
                sb.Append("<br>");

                for (int i = 0; i < temp.Count; i++)
                {
                    sb.Append("<div class='col-sm-2'>");
                    sb.Append("<div class='down-color'>");
                    sb.Append("<img src = '" + temp[i].IMG + "' alt=''>");
                    sb.Append("<a href='#' idd='" + temp[i].ID + "' class='down-color-link'>");
                    sb.Append("</a>");
                    sb.Append("<span class='down-color-name'>" + temp[i].NAME + "</span>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                sb.Append("</div>");
            }
            
            return sb.ToString();
        }

        public JsonResult SearchPage(string keyWord)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='container'>");
            sb.Append("<div class='row'>");
            sb.Append("<br><br>");
            sb.Append("<div class='search-tracks'>");
            sb.Append("<div id='contentPageSearch'>");

            sb.Append("<div class='search-tracks-title' id='search-tracks-title'>");
            sb.Append("<span style='font-size:120%; float:left; color:#eee'>TRACKS</span>");
            sb.Append("<span style='font-size:90%; float:right; color:#888; cursor:pointer' id='trackSearchViewAll' onclick='searchTrackAllView()' keyword='" + keyWord + "'> VIEW ALL</span>");
            sb.Append("</div>");
            sb.Append("<br>");
            sb.Append("<div id='search-tracks-page' class='col-sm-12'>");
            sb.Append(TrackSearch(keyWord,false));
            sb.Append("</div>");

            sb.Append("<br><br>");
            sb.Append("<div class='detail-song-track-total' id='detail-song-track-total'>");
            sb.Append(trackTotal(keyWord,false));
            sb.Append("</div>");

            sb.Append("<br><br><br><br>");
            sb.Append("<div class='search-artist' id='searchArtistViewAll'>");
            sb.Append(searchArtist(keyWord, false));
            sb.Append("</div>");

            sb.Append("<br><br><br><br><br>");
            sb.Append(searchLabel(keyWord, false));

            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return Json(sb.ToString());
        }

        public JsonResult searchTrachAll(string keyWord)
        {
            return Json(TrackSearch(keyWord, true));
        }

        public JsonResult searchTotalAll(string keyWord)
        {
            return Json(trackTotal(keyWord, true));
        }

        public JsonResult searchArtistAll(string keyWord)
        {
            return Json(searchArtist(keyWord, true));
        }
    }
}