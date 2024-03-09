using System.ComponentModel.DataAnnotations;

namespace DRKR.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        
        public ICollection<Media> MediaItems { get; set; } = new List<Media>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }


}

