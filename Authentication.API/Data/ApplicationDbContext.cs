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
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "University"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Volunteer"
                    }
                );

            builder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Username = "uniwa",
                        Email = "info@uniwa.gr",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 1
                    },
                    new User
                    {
                        Id = 2,
                        Username = "uoa",
                        Email = "info@uoa.gr",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 1
                    }
                );
        }
    }
}
