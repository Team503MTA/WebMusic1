using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebMusic.Models;

namespace MusicWeb.Controllers
{
    public class ChartsController : Controller
    {
        //
        // GET: /Home/
        readonly MusicEntities _db = new MusicEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ChartsGenrePartial()
        {
            return PartialView(_db.GENREs.ToList());
        }

        public PartialViewResult NewChartsPartial()
        {
            var c = _db.CHARTs.ToList();
            List<string> img = new List<string>();
            foreach (var item in c)
            {
                var i =
                    _db.TRACKs.Where(p => p.GENRE == item.NAME_GENRE)
                        .Take(1)
                        .OrderByDescending(p => p.POINT_ALL)
                        .Select(p => p.LINK_IMG)
                        .FirstOrDefault();
                img.Add(i);
            }
            ViewBag.img = img;
            return PartialView(c);
        }

        public PartialViewResult SliderChartsPartial()
        {
            var c = _db.CHARTs.Take(7).ToList();
            List<string> img = new List<string>();
            foreach (var item in c)
            {
                var i = _db.TRACKs.Where(p => p.GENRE == item.NAME_GENRE).Take(1).OrderByDescending(p => p.POINT_MONTH).Select(p => p.LINK_IMG).FirstOrDefault();
                img.Add(i);
            }
            ViewBag.img = img;
            return PartialView(c);
        }


    }
}
