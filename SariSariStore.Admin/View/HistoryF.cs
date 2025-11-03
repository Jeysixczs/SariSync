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



        public void DisplayOrderHistory()
        {
            dgv_orderhistory.Rows.Clear();
            dgv_orderhistory.DataSource = ord.GetAllOrders();

            //Format the dgv_orderhistory
            if (dgv_orderhistory.Columns.Count > 0)
            {
                dgv_orderhistory.Columns["OrderID"].HeaderText = "Order ID";
                dgv_orderhistory.Columns["CustomerName"].HeaderText = "Customer Name";
                dgv_orderhistory.Columns["OrderDate"].HeaderText = "Order Date";
                dgv_orderhistory.Columns["TotalAmount"].HeaderText = "Total Amount";
                dgv_orderhistory.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                dgv_orderhistory.Columns["IsPaid"].HeaderText = "Paid";
                dgv_orderhistory.Columns["Notes"].HeaderText = "Notes";
                dgv_orderhistory.Columns["Remarks"].HeaderText = "Remarks";

                // Format date column
                dgv_orderhistory.Columns["OrderDate"].DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
            }
        }

        private void btn_printreceipt_Click(object sender, EventArgs e)
        {
            //print the selected rows in dgvorderhistory give the value to the Receiptform
            if (dgv_orderhistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to print the receipt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //Get the selected order ID
                int selectedOrderId = Convert.ToInt32(dgv_orderhistory.SelectedRows[0].Cells["OrderID"].Value);

                //Get the complete order with items
                Orders selectedOrder = ord.GetOrderWithDetails(selectedOrderId);

                if (selectedOrder != null)
                {
                    //Open the ReceiptForm and pass the selected order
                    ReceiptForm receiptForm = new ReceiptForm(selectedOrder);
                    receiptForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Order details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            dgv_orderhistory.DataSource = ord.SearchOrders(searchTerm);
        }

        private void dgv_orderhistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dgv_orderhistory.Rows[e.RowIndex].Cells["OrderID"].Value);
                ShowOrderDetails(orderId);
            }
        }

        private void ShowOrderDetails(int orderId)
        {
            Orders order = ord.GetOrderWithDetails(orderId);
            if (order != null)
            {
                OrderDetailsForm detailsForm = new OrderDetailsForm(order);
                detailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_checkorder_Click(object sender, EventArgs e)
        {



        }

        private void dgv_orderhistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
