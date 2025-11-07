using SariSariStore.Admin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void coundowntimer_Tick(object sender, EventArgs e)
        {
            countdown--;
            lblLoading.Text = $"Shutting down in {countdown} seconds... Please wait";

            if (countdown <= 0)
            {
                coundowntimer.Stop();
                timer.Stop();

               
                Application.Exit();
            }
        }

    }
}