using SariSariStore.Admin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SariSariStore.Admin.View
{
    public partial class ProductForm : Form
    {
        public int cornerRadius = 30;
        public Rounded rounded;
        public ProductForm()
        {
            InitializeComponent();
            rounded = new Rounded();
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            rounded.MakePanelRounded(panel4, 30);
            rounded.MakePanelRounded(panel5, 30);
            rounded.MakePanelRounded(panel6, 30);
            rounded.MakePanelRounded(panel7, 30);
            rounded.MakePanelRounded(panel8, 30);
            rounded.MakePanelRounded(panel9, 30);
        }

        private void ProductForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }
    }
}
