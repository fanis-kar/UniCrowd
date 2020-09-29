using Volunteer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Volunteer.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Volunteer.API.Models.Volunteer> Volunteers { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder
            //    .Entity<Role>()
            //    .HasData(
            //        new Role { 
            //            Id = 1, 
            //            Name = "University" 
            //        },
            //        new Role
            //        {
            //            Id = 2,
            //            Name = "Volunteer"
            //        }
            //    );
        }
    }
}
