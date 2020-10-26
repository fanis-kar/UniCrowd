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
                        Username = "aueb",
                        Email = "webmaster@aueb.gr",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 1
                    },
                    new User
                    {
                        Id = 3,
                        Username = "volunteer1",
                        Email = "volunteer1@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 4,
                        Username = "volunteer2",
                        Email = "volunteer2@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 5,
                        Username = "volunteer3",
                        Email = "volunteer3@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 6,
                        Username = "volunteer4",
                        Email = "volunteer4@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 7,
                        Username = "volunteer5",
                        Email = "volunteer5@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 8,
                        Username = "volunteer6",
                        Email = "volunteer6@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 9,
                        Username = "volunteer7",
                        Email = "volunteer7@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 10,
                        Username = "volunteer8",
                        Email = "volunteer8@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 11,
                        Username = "volunteer9",
                        Email = "volunteer9@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 12,
                        Username = "volunteer10",
                        Email = "volunteer10@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 13,
                        Username = "volunteer11",
                        Email = "volunteer11@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 14,
                        Username = "volunteer12",
                        Email = "volunteer12@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 15,
                        Username = "volunteer13",
                        Email = "volunteer13@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 16,
                        Username = "volunteer14",
                        Email = "volunteer14@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 17,
                        Username = "volunteer15",
                        Email = "volunteer15@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 18,
                        Username = "volunteer16",
                        Email = "volunteer16@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 19,
                        Username = "volunteer17",
                        Email = "volunteer17@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 20,
                        Username = "volunteer18",
                        Email = "volunteer18@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 21,
                        Username = "volunteer19",
                        Email = "volunteer19@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 22,
                        Username = "volunteer20",
                        Email = "volunteer20@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 23,
                        Username = "volunteer21",
                        Email = "volunteer21@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 24,
                        Username = "volunteer22",
                        Email = "volunteer22@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 25,
                        Username = "volunteer23",
                        Email = "volunteer23@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 26,
                        Username = "volunteer24",
                        Email = "volunteer24@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 27,
                        Username = "volunteer25",
                        Email = "volunteer25@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 28,
                        Username = "volunteer26",
                        Email = "volunteer26@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 29,
                        Username = "volunteer27",
                        Email = "volunteer27@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 30,
                        Username = "volunteer28",
                        Email = "volunteer28@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 31,
                        Username = "volunteer29",
                        Email = "volunteer29@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    },
                    new User
                    {
                        Id = 32,
                        Username = "volunteer30",
                        Email = "volunteer30@mail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    }    
                );
        }
    }
}
