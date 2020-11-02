using Microsoft.EntityFrameworkCore;
using Model;
using Model.Task;

namespace Task.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskSkill> TasksSkills { get; set; }
        public DbSet<VolunteerSkill> VolunteersSkills { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<VolunteerGroup> VolunteersGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ------------------------------------------------------------------------- //
            // Set Primary Keys

            builder
                .Entity<TaskSkill>()
                .HasKey(ts => new { ts.TaskId, ts.SkillId });

            builder
                .Entity<VolunteerSkill>()
                .HasKey(vs => new { vs.VolunteerId, vs.SkillId });

            builder
                .Entity<VolunteerGroup>()
                .HasKey(vg => new { vg.VolunteerId, vg.GroupId });

            // ------------------------------------------------------------------------- //
            // Set Collumn Types

            builder.Entity<Skill>()
                .Property(s => s.Description)
                .HasColumnType("text");

            builder.Entity<Tasks>()
                .Property(t => t.Description)
                .HasColumnType("text");

            builder.Entity<Invitation>()
                .Property(i => i.Description)
                .HasColumnType("text");

            // ------------------------------------------------------------------------- //

            builder.Seed();
        }
    }
}
