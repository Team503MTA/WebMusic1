using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebMusic.Controllers
{
    public class ManageArtistController : Controller
    {
        //
        // GET: /ManageArtist/
        MusicEntities db = new MusicEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;

            return View(db.ARTISTs.ToList().OrderBy(p => p.NAME).ToPagedList(pageNumber, pageSize));
        }
        //Add new artist
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ARTIST artist, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.Messeges = "Pleas chose Image";
                return View();
            }
            var fileName = Path.GetFileName(fileUpload.FileName);
            // save url of file
            var path = Path.Combine(Server.MapPath("~/IMG/Artist"), fileName);
            // check img exit
            if (System.IO.File.Exists(path))
            {
                ViewBag.Messeges = "image Exists";
            }
            else
            {
                fileUpload.SaveAs(path);
            }
            if (ModelState.IsValid)
            {
                artist.IMG = fileUpload.FileName;
                db.ARTISTs.Add(artist);
                db.SaveChanges();
            }
            return View();
        }

        //Edit Artist
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            //pop artist for ID
            ARTIST artist = db.ARTISTs.SingleOrDefault(n => n.ID == ID);
            if (artist == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(artist);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ARTIST artist)
        {
            if (ModelState.IsValid)
            {
                //save in edit
                db.Entry(artist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Details(int ID)
        {
            //pop artist for ID
            ARTIST artist = db.ARTISTs.SingleOrDefault(n => n.ID == ID);
            if (artist == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(artist);
        }

        //delete

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            ARTIST artist = db.ARTISTs.SingleOrDefault(n => n.ID == ID);
            if (artist == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(artist);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteCompleted(int ID)
        {
            ARTIST artist = db.ARTISTs.SingleOrDefault(n => n.ID == ID);
            if (artist == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.ARTISTs.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}