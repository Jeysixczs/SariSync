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
    public partial class InventoryForm : Form
    {

        public ProductForm prod = new ProductForm();
        public Supplier supplier = new Supplier();
        public InventoryForm()
        {
            InitializeComponent();
            DisplaySupplier();
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

        private void btn_History_Click(object sender, EventArgs e)
        {
            HistoryF historyF = new HistoryF();
            historyF.Show();
            this.Hide();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            ReportFrom reportFrom = new ReportFrom();
            reportFrom.Show();
            this.Hide();
        }

        private void btn_StockStatus_Click(object sender, EventArgs e)
        {
            NotificationForm stock = new NotificationForm();
            stock.ShowDialog();
        }

        private void dgv_supplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void DisplaySupplier()
        {
            dgv_supplier.DataSource = supplier.GetAllSuppliers();
           
        }
    }
}
