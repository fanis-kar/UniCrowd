using MainAuthentication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainAuthentication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //================================================================================//

            //================================================================================//

            builder
                .Entity<Account>()
                .HasData(
                    new Account { Id = 1, UserName = "fanis.kar", Password = "1234", Email = "fanis.karamichalelis@gmail.com", Created = DateTime.Parse("2020-08-20") },
                    new Account { Id = 2, UserName = "uniwa", Password = "5678", Email = "info@uniwa.gr", Created = DateTime.Parse("2020-08-20") }
                );
        }
    }
}
