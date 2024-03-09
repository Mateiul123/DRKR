using Microsoft.EntityFrameworkCore;
using DRKR.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet properties for your entities
    public DbSet<Media> Medias { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Audio> Audios { get; set; }
    public DbSet<Text> TextContents { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
}