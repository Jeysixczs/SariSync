using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SariSariStore.Admin.View
{
    public partial class OrderDetailsForm : Form
    {
        private Orders _order;
        private Orders _ordersService;
        private bool _isViewingAllOrders = true;
        public OrderDetailsForm()
        {
            InitializeComponent();
            _ordersService = new Orders();
            dgvOrderItems.ForeColor = Color.Black;
      

        }

        public OrderDetailsForm(Orders order) : this()
        {
            _order = order;
            if (_order != null && _order.OrderID > 0)
            {
                //Disabled();
                LoadOrdersDetails();
            }
        }
            
        private void LoadOrdersDetails()
        {
            if (_order == null) return;

            dgvOrderItems.DataSource = _order.Items;
            dgvOrderItems.Columns["OrderDetailID"].Visible = false;
            dgvOrderItems.Columns["OrderID"].Visible = false;
            dgvOrderItems.Columns["ProductID"].Visible = false;

            UpdateUIForOrderDetails();

            _isViewingAllOrders = false;
        }



        private void UpdateUIForOrderDetails()
        {
            lblOrderID.Visible = true;
            lblCustomerName.Visible = true;
            lblOrderDate.Visible = true;
            lblTotalAmount.Visible = true;
            lblNotes.Visible = true;
            lblRemarks.Visible = true;
            lblPaymentStatus.Visible = true;


            this.Text = $"Order Details - Order #{_order.OrderID}";
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrderItems_SelectionChanged(object sender, EventArgs e)
        {
            if (_isViewingAllOrders && dgvOrderItems.CurrentRow != null)
            {
                var selectedOrder = dgvOrderItems.CurrentRow.DataBoundItem as Orders;
                if (selectedOrder != null)
                {
                    _order = selectedOrder;
                    LoadOrdersDetails();
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
        
            if (dgvOrderItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to print the receipt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Orders orderToPrint = null;

                if (_isViewingAllOrders)
                {
                    if (dgvOrderItems.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please select an order to print the receipt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int selectedOrderId = Convert.ToInt32(dgvOrderItems.SelectedRows[0].Cells["OrderID"].Value);
                    orderToPrint = _ordersService.GetOrderWithDetails(selectedOrderId);
                }
                else
                {
                    if (_order != null)
                    {
                        orderToPrint = _ordersService.GetOrderWithDetails(_order.OrderID);
                    }
                }

                if (orderToPrint != null)
                {
                    ReceiptForm receiptForm = new ReceiptForm(orderToPrint);
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

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
