using Microsoft.Data.SqlClient;
using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
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
    public partial class ReportFrom : Form
    {
        private Rounded rounded;
        public int cornerRadius = 30;

        // public Expenses exp = new Expenses();
        public string ConnectionString = @"Data Source=JEYSI\\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public SalesReport salesReports = new SalesReport();
        public ReportFrom()
        {
            InitializeComponent();

            rounded = new Rounded();
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            rounded.MakePanelRounded(panel4, 30);
            //rounded.MakePanelRounded(panel5, 30);
            //rounded.MakePanelRounded(panel6, 30);
            //rounded.MakePanelRounded(panel7, 30);
            //rounded.MakePanelRounded(panel8, 30);
            //rounded.MakePanelRounded(panel9, 30);
            //rounded.MakePanelRounded(panel10, 30);
            //rounded.MakePanelRounded(panel11, 30);
            //rounded.MakePanelRounded(panel12, 30);
            //rounded.MakePanelRounded(panel13, 30);

            LoadReport();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }

        private void btn_Products_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
            this.Hide();
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.Show();
            this.Hide();
        }

        private void btn_History_Click(object sender, EventArgs e)
        {
            HistoryF historyF = new HistoryF();
            historyF.Show();
            this.Hide();
        }

        private void dgv_salereport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_report_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadReport()
        {
            dgv_report.DataSource = salesReports.SalesReports();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {

        }

        private void dgv_report_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReportFrom_Load(object sender, EventArgs e)
        {
            int startyear = 2000;

            int endyear = DateTime.Now.Year;

            for (int y = startyear; y <= endyear; y++)
            {
                comboBox3.Items.Add(y.ToString());
            }

            comboBox3.SelectedItem = DateTime.Now.Year.ToString();
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                string mth = comboBox2.SelectedItem.ToString();
                int yr = Convert.ToInt32(comboBox3.SelectedItem);

                dgv_report.DataSource = salesReports.Monthly(mth, yr);
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                string mth = comboBox2.SelectedItem.ToString();
                int yr = Convert.ToInt32(comboBox3.SelectedItem);

                dgv_report.DataSource = salesReports.Monthly(mth, yr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void ReportFrom_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }
    }


}

