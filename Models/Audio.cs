namespace DRKR.Models
{

    public class Audio : Media
    {
        public string AudioUrl { get; set; }

        public override string DisplayInfo()
        {
            return $"Audio Title: {Title}, Duration: {GetFormattedDuration()}, URL: {AudioUrl}";
        }
    }
}
