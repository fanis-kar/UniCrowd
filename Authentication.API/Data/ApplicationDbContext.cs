using Microsoft.EntityFrameworkCore;
using Model;

namespace Authentication.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ------------------------------------------------------------------------- //
            // Set Unique Fields

            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // ------------------------------------------------------------------------- //

            builder.Seed();
        }
    }
}
