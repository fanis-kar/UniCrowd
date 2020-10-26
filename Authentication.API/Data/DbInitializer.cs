using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            //--------------------------------------------------------------------//

            context.Database.EnsureCreated();

            if (context.Users.Any() && context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            //--------------------------------------------------------------------//

            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role
                    {
                        Name = "University"
                    },
                    new Role
                    {
                        Name = "Volunteer"
                    }
                };

                foreach (Role r in roles)
                {
                    context.Roles.Add(r);
                }
                context.SaveChanges();
            }

            //--------------------------------------------------------------------//

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Username = "uniwa",
                        Email = "info@uniwa.gr",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 1
                    },
                    new User
                    {
                        Username = "uoa",
                        Email = "info@uoa.gr",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 1
                    },
                    new User
                    {
                        Username = "faniskar",
                        Email = "fanis.karamichalelis@gmail.com",
                        Password = "96tbuZBOeuX8HYLW+dyhrF29fVQdfH1FgZK9qZ4AeNC5ocMYmNHklg==",
                        Salt = "wugbF9pfkNFf7NMGQR30QjAV87TSTWmfQ860sECoKOAnw1OaAtVm4Q==",
                        RoleId = 2
                    }
                };

                foreach (User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }

            //--------------------------------------------------------------------//

        }
    }
}
