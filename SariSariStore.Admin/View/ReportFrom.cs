using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;


namespace SariSariStore.Admin.View
{
    public partial class ReportFrom : Form
    {
        // public Expenses exp = new Expenses();
        public SalesReport salesReports = new SalesReport();
        public ReportFrom()
        {
            InitializeComponent();
            DisplaySalesReport();
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

        public void DisplaySalesReport()
        {
            //dgv_salereport.DataSource = exp.Getexpenses();
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
    }
}
