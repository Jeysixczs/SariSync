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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            Loadingbar.BackColor = Color.FromArgb(52, 86, 139);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void timer_Loading_Tick(object sender, EventArgs e)
        {



            if (Loadingbar.Value < Loadingbar.Maximum)
            {
                Loadingbar.Value += 1;
            }
            else
            {
                timer_Loading.Stop();
               LoginForm form = new LoginForm();
                form.Show();

                this.Hide();
            }





        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            timer_Loading.Start(); // Start the timer when the form loads
        }

        private void Loadingbar_Click(object sender, EventArgs e)
        {

        }
    }
}
