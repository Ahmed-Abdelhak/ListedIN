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
                var users = _context.Users.Where(u => u.FirstName.StartsWith(first) || u.LastName.StartsWith(last))
                    .ToList();
                return View(users);
            }
            return View();

        }
    }
}