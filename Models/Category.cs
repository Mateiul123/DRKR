namespace DRKR.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Media> MediaItems { get; set; } = new List<Media>();
    }


}
