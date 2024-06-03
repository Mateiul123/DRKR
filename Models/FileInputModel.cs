using System.Web;

namespace DRKR.Models
{
    public class FileInputModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TextInput { get; set; }
        public HttpPostedFileBase VideoFile { get; set; }
        public HttpPostedFileBase AudioFile { get; set; }
        public string VideoFilePath { get; set; }
        public string AudioFilePath { get; set; }
    }
}
