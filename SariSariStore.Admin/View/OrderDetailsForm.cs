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
    public partial class OrderDetailsForm : Form
    {
        private Orders _order;
        public OrderDetailsForm()
        {
            InitializeComponent();
            
        }

        public OrderDetailsForm(Orders order) :this()
        {
            _order = order;
            LoadOrdersDetails();
        }

        private void LoadOrdersDetails()
        {
            // Display order information
            lblOrderID.Text = _order.OrderID.ToString();
            lblCustomerName.Text = _order.CustomerName;
            lblOrderDate.Text = _order.OrderDate.ToString("yyyy-MM-dd HH:mm");
            lblTotalAmount.Text = _order.TotalAmount.ToString("C2");
            lblNotes.Text = _order.Notes;
            lblRemarks.Text = _order.Remarks;
            lblPaymentStatus.Text = _order.IsPaid ? "Paid" : "Unpaid";

            // Display order items
            dgvOrderItems.DataSource = _order.Items;

            // Format the grid
            dgvOrderItems.Columns["OrderDetailID"].Visible = false;
            dgvOrderItems.Columns["OrderID"].Visible = false;
            dgvOrderItems.Columns["ProductID"].HeaderText = "Product ID";
            dgvOrderItems.Columns["Quantity"].HeaderText = "Qty";
            dgvOrderItems.Columns["UnitPrice"].HeaderText = "Unit Price";
            dgvOrderItems.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
            dgvOrderItems.Columns["TotalPrice"].HeaderText = "Total Price";
            dgvOrderItems.Columns["TotalPrice"].DefaultCellStyle.Format = "C2";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
