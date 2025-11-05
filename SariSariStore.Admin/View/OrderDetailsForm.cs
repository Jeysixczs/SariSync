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
        public OrderDetailsForm()
        {
            InitializeComponent();
            _ordersService = new Orders();
            LoadAllOrders();
            dgvOrderItems.ForeColor = Color.Black;

        }

        public OrderDetailsForm(Orders order) : this()
        {
            _order = order;
            if (_order != null && _order.OrderID > 0)
            {
                LoadOrdersDetails(); //will load the specific order details
            }
        }

        private void LoadOrdersDetails()
        {
            if (_order == null) return;

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

            FormatOrderItemsGrid();

            // Show/hide controls appropriately
            UpdateUIForOrderDetails();
        }
        private void LoadAllOrders()
        {
            var allOrders = _ordersService.GetAllOrders();
            dgvOrderItems.DataSource = allOrders;


            dgvOrderItems.Visible = true;

            // Format the grid for order list
            FormatAllOrdersGrid();

            // Update labels for "all orders" view
            UpdateUIForAllOrders();
        }

        private void FormatOrderItemsGrid()
        {
            dgvOrderItems.Columns.Clear();
            dgvOrderItems.AutoGenerateColumns = false;
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Create columns for order items
            var columns = new[]
            {
            new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Product Name", DataPropertyName = "ProductName", Width = 80 },
            new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Quantity", DataPropertyName = "Quantity", Width = 60 },
            new DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "Unit Price", DataPropertyName = "UnitPrice", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } },
            new DataGridViewTextBoxColumn { Name = "TotalPrice", HeaderText = "Total Price", DataPropertyName = "TotalPrice", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } }
        };

            dgvOrderItems.Columns.AddRange(columns);

            // Hide unnecessary columns if they exist
            if (dgvOrderItems.Columns["OrderDetailID"] != null)
                dgvOrderItems.Columns["OrderDetailID"].Visible = false;
            if (dgvOrderItems.Columns["OrderID"] != null)
                dgvOrderItems.Columns["OrderID"].Visible = false;
            //if (dgvOrderItems.Columns["ProductID"] != null)
            //    dgvOrderItems.Columns["ProductID"].Visible = false;
        }

        private void FormatAllOrdersGrid()
        {
            dgvOrderItems.Columns.Clear();
            dgvOrderItems.AutoGenerateColumns = false;

            // Create columns individually
            var colOrderID = new DataGridViewTextBoxColumn
            {
                Name = "OrderID",
                HeaderText = "Order ID",
                DataPropertyName = "OrderID",
                Width = 80
            };

            var colCustomerName = new DataGridViewTextBoxColumn
            {
                Name = "CustomerName",
                HeaderText = "Customer",
                DataPropertyName = "CustomerName",
                Width = 150
            };

            var colOrderDate = new DataGridViewTextBoxColumn
            {
                Name = "OrderDate",
                HeaderText = "Order Date",
                DataPropertyName = "OrderDate",
                Width = 120
            };

            var colTotalAmount = new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Total Amount",
                DataPropertyName = "TotalAmount",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };

            var colIsPaid = new DataGridViewCheckBoxColumn
            {
                Name = "IsPaid",
                HeaderText = "Paid",
                DataPropertyName = "IsPaid",
                Width = 50
            };

            // Add columns to grid
            dgvOrderItems.Columns.AddRange(new DataGridViewColumn[] {
        colOrderID, colCustomerName, colOrderDate, colTotalAmount, colIsPaid
            });

        }

        private void UpdateUIForOrderDetails()
        {
            // Show all detail labels
            lblOrderID.Visible = true;
            lblCustomerName.Visible = true;
            lblOrderDate.Visible = true;
            lblTotalAmount.Visible = true;
            lblNotes.Visible = true;
            lblRemarks.Visible = true;
            lblPaymentStatus.Visible = true;


            // Change form title
            this.Text = $"Order Details - Order #{_order.OrderID}";
        }

        private void UpdateUIForAllOrders()
        {
            // Hide detail labels when viewing all orders
            lblOrderID.Visible = false;
            lblCustomerName.Visible = false;
            lblOrderDate.Visible = false;
            lblTotalAmount.Visible = false;
            lblNotes.Visible = false;
            lblRemarks.Visible = false;
            lblPaymentStatus.Visible = false;

            // Change form title
            this.Text = "All Orders";
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrderItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrderItems.CurrentRow != null)
            {
                var selectedOrder = dgvOrderItems.CurrentRow.DataBoundItem as Orders;
                if (selectedOrder != null)
                {
                    _order = selectedOrder;
                    LoadOrdersDetails();
                    dgvOrderItems.Visible = false;
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {



        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
