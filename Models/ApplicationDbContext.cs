using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DRKR.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FileInputModel> FileInputs { get; set; }
        public DbSet<BadWord> BadWords { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
