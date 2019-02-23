﻿using ListedIN.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ListedIN.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index(string id)
        {
            if (id != User.Identity.GetUserId())
            {
               var readOnlyUser =  _context.Users.Single(c => c.Id == id);
                return View("Index _ReadOnly",readOnlyUser);
            }

            var user = _context.Users.Single(c => c.Id == id);

            return View(user);
        }
                                            

        [HttpPost]
        public ActionResult EditSec1(ApplicationUser user)
        {
            var userEdit = _context.Users.Find(user.Id);

            if (user.FirstName != null || user.LastName != null)
            // AutoMapper is helpful here !
            {
                userEdit.FirstName = user.FirstName;
                userEdit.LastName = user.LastName;
                userEdit.Position = user.Position;
                userEdit.HeadLine = user.HeadLine;
                userEdit.Summary = user.Summary;
                userEdit.Country = user.Country;
                _context.SaveChanges();
                return PartialView("_Partial_Sec1", userEdit);

            }

            return View("Index", userEdit);


        }


        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase file)
        {
            var loggedId = HttpContext.User.Identity.GetUserId();
            var user = _context.Users.Single(c => c.Id == loggedId);


            if (file != null && file.ContentLength > 0)
            {
               
                var id = user.Id;
                var fileExt = Path.GetExtension(file.FileName);
                var fnm = id + ".png";
                if (fileExt.ToLower().EndsWith(".png") || fileExt.ToLower().EndsWith(".jpg"))// Important for security if saving in webroot
                {
                    var filePath = HostingEnvironment.MapPath("~/Content/images/profile/") + fnm;
                    var directory = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/images/profile/"));
                    if (directory.Exists == false)
                    {
                        directory.Create();
                    }
                    ViewBag.FilePath = filePath.ToString();
                    file.SaveAs(filePath);
                    return View("Index", user);
                }
                
            }
            return View("Index", user);
        }






    }
}