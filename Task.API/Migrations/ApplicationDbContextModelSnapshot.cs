﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.API.Data;

namespace Task.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Stars")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Model.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Decision")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("Model.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Μη διαθέσιμη",
                            Name = "Βασικές γνώσεις Η/Υ"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Μη διαθέσιμη",
                            Name = "Προγραμματισμός με JAVA"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Μη διαθέσιμη",
                            Name = "Προγραμματισμός με C#"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Μη διαθέσιμη",
                            Name = "Προγραμματισμός με Python"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Μη διαθέσιμη",
                            Name = "Ανάπτυξη Web εφαρμογών με JAVA"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Μη διαθέσιμη",
                            Name = "Ανάπτυξη Web εφαρμογών με C#"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Μη διαθέσιμη",
                            Name = "Ανάπτυξη mobile εφαρμογών με JAVA"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Μη διαθέσιμη",
                            Name = "Ανάπτυξη mobile εφαρμογών με Xamarin Forms"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Μη διαθέσιμη",
                            Name = "Μηχανική μάθηση"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Μη διαθέσιμη",
                            Name = "Εξόρυξη δεδομένων"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Μη διαθέσιμη",
                            Name = "Διαχείριση δεδομένων μεγάλης κλίμακας"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Μη διαθέσιμη",
                            Name = "SQL Server"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Μη διαθέσιμη",
                            Name = "MongoDB"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Μη διαθέσιμη",
                            Name = "MySQL"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Μη διαθέσιμη",
                            Name = "Αγγλικά - Καλή γνώση (B2)"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Μη διαθέσιμη",
                            Name = "Αγγλικά - Πολύ καλή γνώση (Γ1)"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Μη διαθέσιμη",
                            Name = "Αγγλικά - Άριστη γνώση (Γ2)"
                        });
                });

            modelBuilder.Entity("Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1. ΔΗΜΙΟΥΡΓΙΑ GROUP"
                        },
                        new
                        {
                            Id = 2,
                            Name = "2. ΕΝΕΡΓΟ TASK"
                        },
                        new
                        {
                            Id = 3,
                            Name = "3. ΟΛΟΚΛΗΡΩΜΕΝΟ TASK"
                        },
                        new
                        {
                            Id = 4,
                            Name = "4. ΑΚΥΡΩΜΕΝΟ TASK"
                        });
                });

            modelBuilder.Entity("Model.Task.VolunteerGroup", b =>
                {
                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("VolunteerId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("VolunteersGroups");
                });

            modelBuilder.Entity("Model.TaskSkill", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("TaskId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("TasksSkills");
                });

            modelBuilder.Entity("Model.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<int>("VolunteerNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Model.VolunteerSkill", b =>
                {
                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("VolunteerId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("VolunteersSkills");

                    b.HasData(
                        new
                        {
                            VolunteerId = 1,
                            SkillId = 3
                        },
                        new
                        {
                            VolunteerId = 1,
                            SkillId = 6
                        },
                        new
                        {
                            VolunteerId = 1,
                            SkillId = 8
                        },
                        new
                        {
                            VolunteerId = 1,
                            SkillId = 12
                        },
                        new
                        {
                            VolunteerId = 1,
                            SkillId = 15
                        });
                });

            modelBuilder.Entity("Model.Group", b =>
                {
                    b.HasOne("Model.Tasks", "Task")
                        .WithOne("Group")
                        .HasForeignKey("Model.Group", "TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Invitation", b =>
                {
                    b.HasOne("Model.Tasks", "Task")
                        .WithMany("Invitations")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Task.VolunteerGroup", b =>
                {
                    b.HasOne("Model.Group", "Group")
                        .WithMany("VolunteersGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.TaskSkill", b =>
                {
                    b.HasOne("Model.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Tasks", "Task")
                        .WithMany("TasksSkills")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Tasks", b =>
                {
                    b.HasOne("Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.VolunteerSkill", b =>
                {
                    b.HasOne("Model.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
