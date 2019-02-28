using ListedIN.Models;
using ListedIN.ViewModels;
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
            var profileModel = new ProfileViewModel
            {
                User = _context.Users.Single(c => c.Id == id),
                Educations = _context.Educations.Where(e => e.fk_User == id).ToList()
            };

            if (id != User.Identity.GetUserId())
            {

                return View("Index _ReadOnly", profileModel);
            }



            return View(profileModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return PartialView("_Partial_Sec1", userEdit);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPhoto(HttpPostedFileBase file)
        {
            var loggedId = HttpContext.User.Identity.GetUserId();
            var user = _context.Users.Single(c => c.Id == loggedId);

            var profileModel = new ProfileViewModel
            {
                User = user,
                Educations = _context.Educations.Where(e => e.fk_User == loggedId).ToList()
            };


            if (file != null && file.ContentLength > 0)
            {

                var id = user.Id;
                var fileExt = Path.GetExtension(file.FileName);
                var fnm = id + ".png";
                if (fileExt.ToLower().EndsWith(".png") || fileExt.ToLower().EndsWith(".jpg")
                ) // Important for security if saving in webroot
                {
                    var filePath = HostingEnvironment.MapPath("~/Content/images/profile/") + fnm;
                    var directory = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/images/profile/"));
                    if (directory.Exists == false)
                    {
                        directory.Create();
                    }

                    ViewBag.FilePath = filePath.ToString();
                    file.SaveAs(filePath);
                }

            }
            return PartialView("_Partial_Sec1", profileModel.User);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSec2(Education education)
        {
            var model = new ProfileViewModel
            {
                User = _context.Users.SingleOrDefault(e => e.Id == education.fk_User),
                Educations = _context.Educations.Where(e => e.fk_User == education.fk_User).ToList()
            };
            //var listOfEdus = _context.Educations.Where(e => e.fk_User == education.fk_User).ToList();

            if (education.Name != null)
            {
                var eduEdit = _context.Educations.Single(e => e.Id == education.Id);

                //AutoMapper should do this crappy code
                eduEdit.Name = education.Name;
                eduEdit.Degree = education.Degree;
                eduEdit.Grade = education.Grade;
                eduEdit.Field = education.Field;
                eduEdit.Description = education.Description;
                eduEdit.FromYear = education.FromYear;
                eduEdit.ToYear = education.ToYear;
                _context.SaveChanges();
                return PartialView("_Partial_Sec2", model);
            }

            return PartialView("_Partial_Sec2", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSec2(Education education)
        {

            var model = new ProfileViewModel
            {
                User = _context.Users.SingleOrDefault(e => e.Id == education.fk_User),
                Educations = _context.Educations.Where(e => e.fk_User == education.fk_User).ToList()
            };



            if (education.Name != null)
            {
                _context.Educations.Add(education);
                _context.SaveChanges();
                
                return PartialView("_Partial_Sec2_Add_Render", education);

            }

            return PartialView("_Partial_Sec2", model);

        }

        [HttpPost]
        [OutputCache(Duration = 0,NoStore = true,VaryByParam = "*")]
        public ActionResult Delete(int id)
        {
            var edu = _context.Educations.SingleOrDefault(e => e.Id == id);

            var model = new ProfileViewModel
            {
                User = _context.Users.SingleOrDefault(e => e.Id == edu.fk_User),
                Educations = _context.Educations.Where(e => e.fk_User == edu.fk_User).ToList()
            };

            if (edu != null)
            {
                var userId = edu.fk_User;
                _context.Educations.Remove(edu);
                _context.SaveChanges();
                var modelDel = new ProfileViewModel
                {
                    User = _context.Users.SingleOrDefault(e => e.Id == userId),
                   Educations = _context.Educations.Where(e => e.fk_User == userId).ToList()
                };
                return PartialView("_Partial_Sec2", modelDel);
            }

            //return RedirectToAction("Index", new { id = indexId });

            return PartialView("_Partial_Sec2", model);
        }
    }
}
