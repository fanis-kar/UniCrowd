using Microsoft.EntityFrameworkCore;
using Model;

namespace Task.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TaskSkill> TasksSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<TaskSkill>()
                .HasNoKey();
        }
    }
}
