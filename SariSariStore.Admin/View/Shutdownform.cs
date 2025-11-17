using SariSariStore.Admin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SariSariStore.Admin.View
{
    public partial class Shutdownform : Form
    {
        private int progressValue = 0;
        private int countdown = 10;
        private int dotCount = 0;
        private string[] dots = { "●", "●●", "●●●", "●●●●", "●●●●●" };
        private SmoothTransition _smoothTransition;

        public Shutdownform(SmoothTransition smoothTransition = null)
        {
            InitializeComponent();
            _smoothTransition = smoothTransition ?? new SmoothTransition();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % dots.Length;
            circularProgress.Text = dots[dotCount];

            if (progressValue < 100)
            {
                progressValue += 2;
                progressBar.Value = Math.Min(progressValue, 100);
                lblProgress.Text = $"{progressValue}%";
            }
        }

        private async void coundowntimer_Tick(object sender, EventArgs e)
        {
            countdown--;
            lblLoading.Text = $"Shutting down in {countdown} seconds... Please wait";

            if (countdown <= 0)
            {
                coundowntimer.Stop();
                timer.Stop();

                // Gracefully shutdown Web API
                await StopWebApiGracefully();
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
      
        private async Task StopWebApiGracefully()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    var response = await client.PostAsync("https://10.147.144.141:7211/api/shutdown", null);

                    if (response.IsSuccessStatusCode)
                    {
                        lblLoading.Text = "Web API stopped gracefully...";
                    }
                }
            }
            catch (Exception ex)
            {
                // If graceful shutdown fails, force kill
                lblLoading.Text = "Force stopping Web API...";
                StopWebApiForced();
            }
        }

        private void StopWebApiForced()
        {
            try
            {
                // Kill all dotnet processes (be careful with this!)
                foreach (var process in Process.GetProcessesByName("dotnet"))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                        // Ignore errors
                    }
                }
            }
            catch
            {
                // Ignore all errors during forced shutdown
            }
        }

        private void Shutdownform_Load(object sender, EventArgs e)
        {

        }
    }
}