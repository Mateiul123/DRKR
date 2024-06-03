using System.Linq;
using System.Web.Mvc;
using DRKR.Models;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;
using System.IO;

namespace DRKR.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const int MaxFileSize = 10485760; // 10MB

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(FileInputModel model)
        {
            if (ModelState.IsValid && ValidateFile(model.VideoFile) && ValidateFile(model.AudioFile))
            {
                var userId = User.Identity.GetUserId();
                model.TextInput = CensorBadWords(model.TextInput);
                model.UserId = userId;
                model.VideoFilePath = SaveFile(model.VideoFile, userId);
                model.AudioFilePath = SaveFile(model.AudioFile, userId);
                db.FileInputs.Add(model);
                db.SaveChanges();
                NotificationHub.Send("Your files have been uploaded successfully.");
                return PartialView("_UploadResult", model);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        private bool ValidateFile(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > MaxFileSize)
                {
                    ModelState.AddModelError("", "File size exceeds the maximum limit.");
                    return false;
                }
                string[] allowedFileTypes = { ".mp4", ".mp3" };
                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedFileTypes.Contains(fileExtension))
                {
                    ModelState.AddModelError("", "Invalid file type.");
                    return false;
                }
            }
            return true;
        }

        private string CensorBadWords(string input)
        {
            var badWords = db.BadWords.Select(b => b.Word).ToList();
            foreach (var badWord in badWords)
            {
                string pattern = $"\\b{badWord}\\b";
                string replacement = new string('*', badWord.Length);
                input = Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);
            }
            var badPhrases = new List<string> { "bad phrase", "offensive phrase" };
            foreach (var phrase in badPhrases)
            {
                string pattern = Regex.Escape(phrase);
                string replacement = new string('*', phrase.Length);
                input = Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);
            }
            return input;
        }

        private string SaveFile(HttpPostedFileBase file, string userId)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var userFolder = Path.Combine(Server.MapPath("~/App_Data/Uploads"), userId);
                Directory.CreateDirectory(userFolder);
                var path = Path.Combine(userFolder, fileName);
                file.SaveAs(path);
                return path;
            }
            return null;
        }
    }
}
