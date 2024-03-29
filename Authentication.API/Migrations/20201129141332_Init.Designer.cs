﻿// <auto-generated />
using Authentication.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Authentication.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201129141332_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "University"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Volunteer"
                        });
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "info@uniwa.gr",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 1,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "uniwa"
                        },
                        new
                        {
                            Id = 2,
                            Email = "webmaster@aueb.gr",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 1,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "aueb"
                        },
                        new
                        {
                            Id = 3,
                            Email = "volunteer1@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer1"
                        },
                        new
                        {
                            Id = 4,
                            Email = "volunteer2@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer2"
                        },
                        new
                        {
                            Id = 5,
                            Email = "volunteer3@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer3"
                        },
                        new
                        {
                            Id = 6,
                            Email = "volunteer4@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer4"
                        },
                        new
                        {
                            Id = 7,
                            Email = "volunteer5@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer5"
                        },
                        new
                        {
                            Id = 8,
                            Email = "volunteer6@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer6"
                        },
                        new
                        {
                            Id = 9,
                            Email = "volunteer7@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer7"
                        },
                        new
                        {
                            Id = 10,
                            Email = "volunteer8@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer8"
                        },
                        new
                        {
                            Id = 11,
                            Email = "volunteer9@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer9"
                        },
                        new
                        {
                            Id = 12,
                            Email = "volunteer10@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer10"
                        },
                        new
                        {
                            Id = 13,
                            Email = "volunteer11@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer11"
                        },
                        new
                        {
                            Id = 14,
                            Email = "volunteer12@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer12"
                        },
                        new
                        {
                            Id = 15,
                            Email = "volunteer13@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer13"
                        },
                        new
                        {
                            Id = 16,
                            Email = "volunteer14@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer14"
                        },
                        new
                        {
                            Id = 17,
                            Email = "volunteer15@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer15"
                        },
                        new
                        {
                            Id = 18,
                            Email = "volunteer16@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer16"
                        },
                        new
                        {
                            Id = 19,
                            Email = "volunteer17@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer17"
                        },
                        new
                        {
                            Id = 20,
                            Email = "volunteer18@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer18"
                        },
                        new
                        {
                            Id = 21,
                            Email = "volunteer19@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer19"
                        },
                        new
                        {
                            Id = 22,
                            Email = "volunteer20@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer20"
                        },
                        new
                        {
                            Id = 23,
                            Email = "volunteer21@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer21"
                        },
                        new
                        {
                            Id = 24,
                            Email = "volunteer22@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer22"
                        },
                        new
                        {
                            Id = 25,
                            Email = "volunteer23@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer23"
                        },
                        new
                        {
                            Id = 26,
                            Email = "volunteer24@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer24"
                        },
                        new
                        {
                            Id = 27,
                            Email = "volunteer25@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer25"
                        },
                        new
                        {
                            Id = 28,
                            Email = "volunteer26@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer26"
                        },
                        new
                        {
                            Id = 29,
                            Email = "volunteer27@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer27"
                        },
                        new
                        {
                            Id = 30,
                            Email = "volunteer28@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer28"
                        },
                        new
                        {
                            Id = 31,
                            Email = "volunteer29@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer29"
                        },
                        new
                        {
                            Id = 32,
                            Email = "volunteer30@mail.com",
                            Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                            RoleId = 2,
                            Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                            Username = "volunteer30"
                        });
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.HasOne("Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
