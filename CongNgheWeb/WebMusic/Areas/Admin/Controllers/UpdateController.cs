using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

        public JsonResult Login(string username, string password)
        {
            var user = db.AccountAdmins.FirstOrDefault(p => p.USERNAME == username && p.PASSWORD == password);
            if (user == null)
            {
                return Json("0");
            }
            return Json("1");
        }
    }
}