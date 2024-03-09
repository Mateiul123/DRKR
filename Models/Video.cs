using System.ComponentModel.DataAnnotations;

namespace DRKR.Models
{
    public class Video : Media
    {
        public string VideoUrl { get; set; }

        public override string DisplayInfo() => $"Video Title: {Title}, Duration: {GetFormattedDuration()}, URL: {VideoUrl}";
    }

}
