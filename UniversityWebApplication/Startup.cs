using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using UniversityApiCollection;
using UniversityApiCollection.Infrastructure;
using UniversityApiCollection.Interfaces;

namespace UniversityWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Project Dependencies
            services.AddHttpClient();
            services.AddTransient<IAuthenticationApi, AuthenticationApi>();
            services.AddTransient<IUniversityApi, UniversityApi>();
            services.AddTransient<IVolunteerApi, VolunteerApi>();
            services.AddTransient<ITaskApi, TaskApi>();
            services.AddTransient<IGroupApi, GroupApi>();
            services.AddTransient<ISkillApi, SkillApi>();
            services.AddTransient<IStatusApi, StatusApi>();
            services.AddTransient<IInvitationApi, InvitationApi>();
            services.AddTransient<IUniversityReportApi, UniversityReportApi>();
            services.AddTransient<IVolunteerReportApi, VolunteerReportApi>();
            #endregion

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromHours(168); //1 Week   
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
