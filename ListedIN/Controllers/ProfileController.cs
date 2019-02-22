using ListedIN.Models;
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

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Edit(int id)
        {
            var member = _context.Members.Find(id);

            if (member != null)
                return HttpNotFound();

            return View(member);

        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {

            return View();
        }

    }
}