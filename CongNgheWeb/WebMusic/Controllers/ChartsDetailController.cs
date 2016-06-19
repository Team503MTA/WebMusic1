using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using WebMusic.Models;
namespace WebMusic.Controllers
{
    public class ChartsDetailController : Controller
    {
        //
        // GET: /ChartsDetail/
        MusicEntities db = new MusicEntities();
        public bool Check(List<string> lst, string str)
        {
            foreach (string t in lst)
            {
                if (t == str)
                    return false;
            }
            return true;
        }
        public string ChartsDetailPartial(int id)
        {
            string g = db.CHARTs.Where(p => p.ID == id).Select(p => p.NAME_GENRE).SingleOrDefault();
            var i = db.TRACKs.Where(p => p.GENRE == g).OrderByDescending(p => p.POINT_MONTH).Select(p => p.LINK_IMG).FirstOrDefault();
            if (i == null)
            {
                i = "/IMG/blank_artist.png";
            }
            var chart = db.CHARTs.SingleOrDefault(p => p.ID == id);
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='charts-detail'>");
            sb.Append("<div class='div-img'>");
            sb.Append("<img src = '." + i + "' alt=''>");
            sb.Append("</div>");
            sb.Append("<div class='div-info'>");
            sb.Append("<div class='charts-title'>");
            sb.Append("<p>CHART</p>");
            sb.Append("</div>");
            sb.Append("<div class='charts-name'>");
            sb.Append("<h3>" + chart.NAME + "</h3>");
            sb.Append("</div>");
            sb.Append("<div class='charts-creator'>");
            sb.Append("<label for='creator'>CREATED BY</label>");
            sb.Append("<a href='#' id='creator'> BEATPORT </a>");
            sb.Append("</div>");
            sb.Append("<div class='date-created'>");
            sb.Append("<label for='date-release'>DATE CREATED</label>");
            sb.Append("<span id='date-release'>" + chart.DATE_RELEASE + "</span>");
            sb.Append("</div>");
            sb.Append("<div class='charts-genre'>");
            sb.Append("<label for='genre'>GENRES</label>");
            sb.Append("<a href='#' id='genre'>" + chart.NAME_GENRE + "</a>");
            sb.Append("</div>");
            sb.Append("<div class='charts-extra'>");
            sb.Append("<span class='play glyphicon glyphicon-play'></span>");
            sb.Append("<span class='list glyphicon glyphicon-list'></span>");
            sb.Append("<button class='cost' type='button'>$" + chart.COST + "<span class='glyphicon glyphicon-menu-down'></span></button>");
            sb.Append("<a class='social-link' href='#' title='Like Us On Facebook' target='_blank'><img src = './IMG/sounds/fb.png'/></a>");
            sb.Append("<a class='social-link' href='#' title='Follow Us On Twitter' target='_blank'><img src = './IMG/sounds/tw.png'></a>");
            sb.Append("</div>");
            sb.Append("<div class='charts-descrip'>");
            sb.Append("<label for='descrip'>DESCRIPTION</label>");
            sb.Append("<span id='descrip'>" + chart.DESCRIP + "</ span >");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }
        public string TracksDetailPartial(int id)
        {
            string g = db.CHARTs.Where(p => p.ID == id).Select(p => p.NAME_GENRE).FirstOrDefault();
            var t = db.TRACKs.Where(p => p.GENRE == g).Take(3).OrderByDescending(p => p.POINT_MONTH).ToList();
            ViewBag.quantum = t.Count;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='tracks-detail'>");
            sb.Append("<div class='tracks-title'>");
            sb.Append("<h3>" + t.Count + " TRACKS TOTAL</h3>");
            sb.Append("</div>");
            sb.Append("<div class='tracks-list'>");
            sb.Append("<div class='tracks-fields'>");
            sb.Append("<hr/>");
            sb.Append("<span>TITLE</span>");
            sb.Append("<span>ARTIST</span>");
            sb.Append("<span>LABEL</span>");
            sb.Append("<span>GENRE</span>");
            sb.Append("<span>RELEASED</span>");
            sb.Append("</div>");
            List<string> tempArtist = new List<string>();
            List<string> tempLabel = new List<string>();
            for (var i = 0; i < t.Count; i++)
            {
                if (t[i].LINK_IMG == null)
                {
                    t[i].LINK_IMG = "~/IMG/blank_artist.png";
                }
                int temp = t[i].ID;
                tempArtist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == temp).Select(p => p.NAME_ARTIST).ToList();
                tempLabel = db.TRACK_ARTIST.Where(p => p.ID_TRACK == temp).Select(p => p.NAME_LABEL).ToList();
                sb.Append("<div class='tracks'>");
                sb.Append("<div class='div-tracks-img'>");
                sb.Append("<img src = '." + t[i].LINK_IMG + "'>");
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-number'>");
                sb.Append("<span>" + (i + 1) + "</span>");
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-play'>");
                sb.Append("<span class='play glyphicon glyphicon-play'></span>");
                sb.Append("<span class='list glyphicon glyphicon-list'></span>");
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-title'>");
                sb.Append("<span>" + t[i].NAME + "</span>");
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-artist'>");
                for (int k = 0; k < tempArtist.Count; k++)
                {
                    sb.Append("<a href='#'>" + tempArtist[k] + "</a>");
                    if (k != tempArtist.Count - 1)
                    {
                        sb.Append("<span> ft </span>");
                    }
                }
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-label'>");
                for (int k = 0; k < tempLabel.Count; k++)
                {
                    sb.Append("<a href='#'>" + tempLabel[k] + "</a>");
                    if (k != tempLabel.Count - 1)
                    {
                        sb.Append("<span> ,</span>");
                    }
                }
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-genre'>");
                sb.Append("<a href='#'>" + t[i].GENRE + "</a>");
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-released'>");
                sb.Append("<span>" + t[i].DATE_RELEASE + "</span>");
                sb.Append("</div>");
                sb.Append("<div class='div-tracks-cost'>");
                sb.Append("<button class='cost' type='button'>$" + t[i].COST +
                          "<span class='glyphicon glyphicon-menu-down'></span></button>");
                sb.Append("</div>");
                sb.Append("</div>");
            }
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }
        public JsonResult Index(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='content'>");
            sb.Append("<div id='charts-detail'>");
            sb.Append("<div class='container'>");
            sb.Append("<div class='row'>");
            sb.Append("<div class='col-xs-12'>");
            sb.Append(ChartsDetailPartial(id));
            sb.Append(TracksDetailPartial(id));
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return Json(sb.ToString());
        }
    }
}
