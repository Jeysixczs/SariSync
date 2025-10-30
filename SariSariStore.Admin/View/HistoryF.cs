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
    public partial class HistoryF : Form
    {
        private Rounded rounded;
        public int cornerRadius = 30;

        public Orders ord = new Orders();
        public HistoryF()
        {
            
            InitializeComponent();
            DisplayOrderHistory();

            rounded = new Rounded();
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            //rounded.MakePanelRounded(panel4, 30);
            //rounded.MakePanelRounded(panel5, 30);
            //rounded.MakePanelRounded(panel6, 30);
            //rounded.MakePanelRounded(panel7, 30);
            //rounded.MakePanelRounded(panel8, 30);
            //rounded.MakePanelRounded(panel9, 30);
            //rounded.MakePanelRounded(panel10, 30);
            //rounded.MakePanelRounded(panel11, 30);
            //rounded.MakePanelRounded(panel12, 30);
            //rounded.MakePanelRounded(panel13, 30);
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

        private void btn_Report_Click(object sender, EventArgs e)
        {
            ReportFrom reportFrom = new ReportFrom();
            reportFrom.Show();
            this.Hide();
        }

        private void dgv_orderhistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void DisplayOrderHistory()
        {
            dgv_orderhistory.Rows.Clear();
            dgv_orderhistory.DataSource = ord.GetAllOrders();
        }

        private void btn_printreceipt_Click(object sender, EventArgs e)
        {
            //print the selected rows in dgvorderhistory give the value to the Receiptform
            if (dgv_orderhistory.SelectedRows.Count == 0) return;

            var selected = dgv_orderhistory.SelectedRows;



        }

        private void dgv_orderhistory_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HistoryF_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }
    }
}
