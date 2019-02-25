using ListedIN.Models;
using System.Linq;
using System.Web.Mvc;

namespace ListedIN.Controllers
{
    [AllowAnonymous]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index(string first,string last)
        {
            if (first != null || last != null)
            {
                var users = _context.Users.Where(u => u.FirstName.Contains(first) && u.LastName.Contains(last) || first == null || last == null)
                    .ToList();
                return View(users);
            }
            return View();

        }
    }
}