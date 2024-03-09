using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRKR.Models
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; }
        public int? DurationInSeconds { get; set; }

        // Navigation properties
        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public virtual string GetFormattedUploadDate() => UploadDate.ToString("yyyy-MM-dd");
        public virtual string GetFormattedDuration() => DurationInSeconds.HasValue ? $"{DurationInSeconds.Value / 60} min {DurationInSeconds.Value % 60} sec" : "N/A";
        public abstract string DisplayInfo();
    }

}
