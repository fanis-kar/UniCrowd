using ApiCollection.Interfaces;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityDesktopApp
{
    public partial class LoginForm : Form
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly IUniversityApi _universityApi;

        public LoginForm()
        {
            _authenticationApi = (IAuthenticationApi)Program.ServiceProvider.GetService(typeof(IAuthenticationApi));
            _universityApi = (IUniversityApi)Program.ServiceProvider.GetService(typeof(IUniversityApi));

            InitializeComponent();
        }

        private async void LoginBtn_ClickAsync(object sender, EventArgs e)
        {
            User user = new User()
            {
                Username = usernameTextBox.Text.ToString(),
                Password = passwordTextBox.Text.ToString()
            };

            try
            {
                string response = await _authenticationApi.Login(user);

                var resultObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                University university = await _universityApi.GetUniversityByUserId(int.Parse(resultObject["userId"]), resultObject["jwtToken"]);

                MessageBox.Show(resultObject["userId"]);
            }
            catch (Exception)
            {
                MessageBox.Show("Σφάλμα");
            }
        }
    }
}
