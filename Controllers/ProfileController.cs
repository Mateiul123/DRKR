using System.Linq;
using System.Web.Mvc;
using DRKR.Models;
using Microsoft.AspNet.Identity;

namespace DRKR.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            return View(user);
        }

        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
