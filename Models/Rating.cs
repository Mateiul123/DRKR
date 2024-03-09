using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRKR.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; } 

        public int UserId { get; set; }
        public User User { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }
    }

}



