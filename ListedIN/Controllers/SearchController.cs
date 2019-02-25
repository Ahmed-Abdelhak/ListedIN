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

        public ActionResult Index(string first, string last)
        {
            if (first != null || last != null)
            {
                var users = _context.Users.Where(u =>
                        u.FirstName.Contains(first) && u.LastName.Contains(last) || first == null || last == null)
                    .ToList();
                return View(users);
            }

            return View();

        }

        [HttpPost]
        public ActionResult Index(string search)
        {

            if (search != null)
            { 
                var searchWords = search.ToLower().Split(' ');
                var searchWord = searchWords[0];

                if (searchWords.Length > 1 && searchWords[1] != null)
                {
                    var first = searchWords[0];   // i have to store in a temp variable, if i use it in my query EF will give an error
                    var last = searchWords[1];
                    var users = _context.Users.Where(u =>
                            u.FirstName.ToLower().Contains(first) && u.LastName.ToLower().Contains(last) ||
                            search == null)
                        .ToList();
                    return View(users);

                }
                else if(searchWords.Length == 1)
                {
                    var users = _context.Users.Where(u =>
                            u.FirstName.ToLower().Contains(searchWord) ||
                            search == null)
                        .ToList();
                    return View(users);
                }
               
            }

           

            return View();

        }
    }
}
