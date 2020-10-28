using Microsoft.EntityFrameworkCore;
using Model;

namespace Group.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Group> Groups { get; set; }
        public DbSet<UniversityReport> UniversitiesReports { get; set; }
        public DbSet<VolunteerReport> VolunteersReports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
        }
    }
}
