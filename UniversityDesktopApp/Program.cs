using ApiCollection;
using ApiCollection.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityDesktopApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            services.AddTransient<IAuthenticationApi, AuthenticationApi>();
            services.AddTransient<IUniversityApi, UniversityApi>();
            //services.AddTransient<IVolunteerApi, VolunteerApi>();
            //services.AddTransient<ITaskApi, TaskApi>();
            //services.AddTransient<IGroupApi, GroupApi>();
            //services.AddTransient<ISkillApi, SkillApi>();
            //services.AddTransient<IStatusApi, StatusApi>();
            //services.AddTransient<IInvitationApi, InvitationApi>();
            //services.AddTransient<IUniversityReportApi, UniversityReportApi>();
            //services.AddTransient<IVolunteerReportApi, VolunteerReportApi>();
            ServiceProvider = services.BuildServiceProvider();
        }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new LoginForm());
        }
    }
}
