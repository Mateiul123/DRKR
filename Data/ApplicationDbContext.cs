using DRKR.Models;
using Microsoft.EntityFrameworkCore;

namespace DRKR.Data;

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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Media)
            .WithMany()
            .HasForeignKey(r => r.MediaId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
    }

}
