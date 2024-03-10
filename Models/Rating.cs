namespace DRKR.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Value { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }
    }

}



