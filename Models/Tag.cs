namespace DRKR.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for the media items associated with this tag
        public ICollection<Media> MediaItems { get; set; } = new List<Media>();
    }

}


