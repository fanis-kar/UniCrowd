using Authentication.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

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
