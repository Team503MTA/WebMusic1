using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Areas.Admin.Controllers
{
    public class UpdateController : Controller
    {
        MusicEntities db = new MusicEntities();
        // GET: Admin/Update
        public ActionResult Index()
        {
            
            return View();
        }
    }
}