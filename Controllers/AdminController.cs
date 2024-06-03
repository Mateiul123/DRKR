using System.Linq;
using System.Web.Mvc;
using DRKR.Models;

namespace DRKR.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult ManageBadWords()
        {
            var badWords = db.BadWords.ToList();
            return View(badWords);
        }

        public ActionResult AddBadWord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBadWord(BadWord model)
        {
            if (ModelState.IsValid)
            {
                db.BadWords.Add(model);
                db.SaveChanges();
                return RedirectToAction("ManageBadWords");
            }
            return View(model);
        }

        public ActionResult DeleteBadWord(int id)
        {
            var badWord = db.BadWords.Find(id);
            db.BadWords.Remove(badWord);
            db.SaveChanges();
            return RedirectToAction("ManageBadWords");
        }
    }
}
