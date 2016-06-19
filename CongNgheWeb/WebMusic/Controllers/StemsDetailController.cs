using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;
namespace WebMusic.Controllers
{
    public class StemsDetailController : Controller
    {
        //
        // GET: /StemsDetail/
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
        public string StemsDetailPartial(int id)
        {
            var stem = db.STEMS1.SingleOrDefault(p => p.STEMS_ID == id);
            var st = db.STEMs.Where(p => p.STEMS_ID == id).Select(p => p.ID).ToList();
            List<string> art = new List<string>();
            List<string> lbl = new List<string>();
            foreach (var item in st)
            {
                var a = db.STEM_ARTIST.Where(p => p.STEM_ID == item).Select(p => p.ARTIST_NAME).FirstOrDefault();
                if (Check(art, a) == true)
                    art.Add(a);
                var l = db.STEM_ARTIST.Where(p => p.STEM_ID == item).Select(p => p.NAME_LABEL).FirstOrDefault();
                if (Check(lbl, l) == true)
                    lbl.Add(l);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='stems-detail'>");
            sb.Append("<div class='div-img'>");
            sb.Append("<img src='@Url.Content('~/IMG/stems/'+' + stem.IMG + ')' alt=''>");
            sb.Append("</div>");
            sb.Append("<div class='div-info'>");
            sb.Append("<div class='stems-title'>");
            sb.Append("<p>STEMS</p>");
            sb.Append("</div>");
            sb.Append("<div class='stems-name'>");
            sb.Append("<h3>' + stem.NAME + '</h3>");
            sb.Append("</div>");
            sb.Append("<div class='stems-artist'>");
            sb.Append("<label for='artist'>ARTISTS</label>");
            for (var i = 0; i < art.Count; i++)
            {
                sb.Append("<a href ='#' id='artist'>' + art[i] + '</a>");
            }
            sb.Append("</div>");
            sb.Append("<div class='date-created'>");
            sb.Append("<label for='date-release'>RELEASE DATE</label>");
            sb.Append("<span id='date-release'> ' + stem.DATE_RELEASE + '</span>");
            sb.Append("</div>");
            sb.Append("<div class='stems-label'>");
            sb.Append("<label for='label'>LABEL</label>");
            for (var i = 0; i < lbl.Count; i++)
            {
                sb.Append("<a href='#' id='label'>' + lbl[i] + '</a>");
            }
            sb.Append("</div>");
            sb.Append("<div class='stems-catalog");
            sb.Append("<label for='catalog'>CATALOG</label");
            sb.Append("<span id='catalog'> ' + stem.CATALOG + '</span>");
            sb.Append("</div>");
            sb.Append("<div class='stems-extra'>");
            sb.Append("<span class='play glyphicon glyphicon-play'></span>");
            sb.Append("<span class='list glyphicon glyphicon-list'></span>");
            sb.Append("<button class='cost' type='button'>$ ' + stem.COST + '<span class='glyphicon glyphicon-menu-down'></span></button>");
            sb.Append("<a class='social-link' href='#' title='Like Us On Facebook' target='_blank'><img src='~/Image/sounds/fb.png'/></a>");
            sb.Append("<a class='social-link' href='#' title='Follow Us On Twitter' target='_blank'><img src='~/Image/sounds/tw.png'></a>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }
        public string StemDetailPartial(int id)
        {
            List<STEM> tem = new List<STEM>();
            tem = db.STEMs.Where(p => p.STEMS_ID == id).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='stem-detail");
            sb.Append("<div class='stem-title'>");
            sb.Append("<h3>" + tem.Count + " STEMS TOTAL</h3>");
            sb.Append("</div>");
            sb.Append("<div class='stem-list'>");
            sb.Append("<div class='stem-fields'>");
            sb.Append("hr/>");
            sb.Append("span>TITLE</span>");
            sb.Append("<span>ARTIST</span>");
            sb.Append("<span>GENRE</span>");
            sb.Append("<span>BPM</span>");
            sb.Append("<span>KEY</span>");
            sb.Append("<span>LENGTH</span>");
            sb.Append("</div>");
            List<string> art = new List<string>();
            List<string> lbl = new List<string>();
            for (var i = 0; i < tem.Count; i++)
            {
                art = db.STEM_ARTIST.Where(p => p.STEM_ID == tem[i].ID).Select(p => p.ARTIST_NAME).ToList();
                lbl = db.STEM_ARTIST.Where(p => p.STEM_ID == tem[i].ID).Select(p => p.NAME_LABEL).ToList();
                i++;
                sb.Append("<div class='stem'>");
                sb.Append("<div class='div-stem-img'>");
                sb.Append("<img src='~/IMG/stems/" + tem[i].LINK_IMG + "'>");
                sb.Append("</div>");
                sb.Append("<div class='div-stem-number'>");
                sb.Append("<span>" + i + "</span>");
                sb.Append("</div>");
                sb.Append("<div class='div-stem-play'>");
                sb.Append("<span class='play glyphicon glyphicon-play'></span>");
                sb.Append("<span class='list glyphicon glyphicon-list'></span>");
                sb.Append("</div>");
                sb.Append("<div class='div-stem-title'>");
                sb.Append("<span>" + tem[i].NAME + "</span>");
                sb.Append("</div>");
                sb.Append("<div class='div-stem-artist'>");
                for (var j = 0; j < art.Count; j++)
                {
                    sb.Append("<a href='#'> " + art[j] + "</a>");
                }
                sb.Append("</div>");
                sb.Append("<div class='div-stem-genre'>");
                sb.Append("<a href='#'> " + tem[i].GENRE + "</a>");
                sb.Append("</div>");
                sb.Append("<div class='div-stem-tempo");
                sb.Append("<span>" + tem[i].TEMPO + "</span>");
                sb.Append("</div>");
                sb.Append("<div class='div-stem-key'>");
                sb.Append("< span>" + tem[i].KEY_ + "</span>");
                sb.Append("</div>");
                sb.Append("<div class='div-stem-len'>");
                sb.Append("<a href='#'>" + tem[i].LENGTH + "</a>");
                sb.Append("</div");
                sb.Append("<div class='div-stem-cost'>");
                sb.Append("<button class='cost' type='button'>$ " + tem[i].COST + "<span class='glyphicon glyphicon-menu-down'></span></button>");
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
            sb.Append(StemsDetailPartial(id));
            sb.Append(StemDetailPartial(id));
            sb.Append("</div");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return Json(sb.ToString());
        }
    }
}
