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
    public partial class PointOfSaleForm : Form
    {
        private Products _products;
        private Orders _orders;
        //private List<OrderItems> _cartItems;
        private List<CartItemDisplay> _cartItems;
        private decimal _totalAmount;
        private Orders _lastProcessedOrder;
        public PointOfSaleForm()
        {
            InitializeComponent();
            _products = new Products();
            _orders = new Orders();
            //  _cartItems = new List<OrderItems>();
            _cartItems = new List<CartItemDisplay>();
            initializeForm();
        }

        private void initializeForm()
        {
            RefreshProductList();
            InitializeCartGrid();
            UpdateCartDisplay();
            dtpOrderDate.Value = DateTime.Now;
        }

        private void InitializeCartGrid()
        {
            // Clear existing columns
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            // Create columns for cart display
            var colProductName = new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product Name",
                DataPropertyName = "ProductName",
                Width = 150,
                ReadOnly = true
            };

            var colQuantity = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Qty",
                DataPropertyName = "Quantity",
                Width = 60
            };

            var colUnitPrice = new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Unit Price",
                DataPropertyName = "UnitPrice",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };

            var colTotalPrice = new DataGridViewTextBoxColumn
            {
                Name = "TotalPrice",
                HeaderText = "Total",
                DataPropertyName = "TotalPrice",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };

            dgvCart.Columns.AddRange(new DataGridViewColumn[] {
                colProductName, colQuantity, colUnitPrice, colTotalPrice
            });
        }

        private void RefreshProductList()
        {
            var products = _products.SearchProductsForOrder("");
            dgvProducts.DataSource = products;

            //format of product grid to show only necessary details
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            var colProductID = new DataGridViewTextBoxColumn
            {
                Name = "ProductID",
                HeaderText = "ID",
                DataPropertyName = "ProductID",
                Width = 20,
                Visible = false
            };

            var colName = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Product Name",
                DataPropertyName = "Name",
                Width = 150
            };

            var colPrice = new DataGridViewTextBoxColumn
            {
                Name = "SellingPrice",
                HeaderText = "SellingPrice",
                DataPropertyName = "SellingPrice",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            };

            var colStock = new DataGridViewTextBoxColumn
            {
                Name = "Stock",
                HeaderText = "Stock",
                DataPropertyName = "Stock",
                Width = 60
            };

            dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                colProductID, colName, colPrice, colStock
            });
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                //int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
                //int quantity = (int)numericQuantity.Value;

                // Use CurrentRow instead of SelectedRows - it's more reliable
                if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.Index >= 0)
                {

                    var selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as Products;

                    if (selectedProduct != null)
                    {
                        int productId = selectedProduct.ProductID;
                        int quantity = (int)numericQuantity.Value;

                        if (quantity > 0)
                        {
                            AddToCart(productId, quantity);
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid quantity.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product first.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void AddToCart(int productId, int quantity)
        {
            var product = _products.GetProductForOrder(productId);
            if (product != null)
            {
                if (quantity > product.Stock)
                {
                    MessageBox.Show($"Insufficient stock! Available: {product.Stock}", "Stock Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = _cartItems.FirstOrDefault(item => item.ProductID == productId);
                if (existingItem != null)
                {
                    if (existingItem.Quantity + quantity > product.Stock)
                    {
                        MessageBox.Show($"Cannot add more than available stock! Available: {product.Stock}",
                            "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    existingItem.Quantity += quantity;
                    existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
                }
                else
                {
                    //_cartItems.Add(new OrderItems
                    //{
                    //    ProductID = product.ProductID,
                    //    Quantity = quantity,
                    //    UnitPrice = product.SellingPrice,
                    //    TotalPrice = product.SellingPrice * quantity
                    //});
                    _cartItems.Add(new CartItemDisplay
                    {
                        ProductID = product.ProductID,
                        ProductName = product.Name,
                        Quantity = quantity,
                        UnitPrice = product.SellingPrice,
                        TotalPrice = product.SellingPrice * quantity
                    });
                }
                UpdateCartDisplay();
                numericQuantity.Value = 1;
            }
        }
        private void UpdateCartDisplay()
        {
            //dgvCart.Columns["OrderDetailID"].Visible = false;
            //dgvCart.Columns["OrderID"].Visible = false;
            //dgvCart.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
            //dgvCart.Columns["TotalPrice"].DefaultCellStyle.Format = "C2";

            //_totalAmount = _cartItems.Sum(item => item.TotalPrice);
            //txtTotal.Text = _totalAmount.ToString("C2");

            //bind data list instead of raw Orderitems
            //dgvCart.DataSource = null;
            //dgvCart.DataSource = _cartItems;
            //_totalAmount = _cartItems.Sum(item => item.TotalPrice);
            //txtTotal.Text = _totalAmount.ToString("C2");

            try
            {
                dgvCart.DataSource = null;
                if (_cartItems != null && _cartItems.Count > 0)
                {
                    dgvCart.DataSource = _cartItems;
                }
                else
                {
                    dgvCart.DataSource = new List<CartItemDisplay>(); // Empty list
                }

                _totalAmount = _cartItems?.Sum(item => item.TotalPrice) ?? 0;
                txtTotal.Text = _totalAmount.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating cart display: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private string GetProductName(int productId)
        //{
        //    var product = _products.GetProductForOrder(productId);
        //    return product?.Name ?? "Unknown Product";
        //}

        private void btnRemovefromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index >= 0)
            {
                //var selectedItem = dgvCart.SelectedRows[0].DataBoundItem as OrderItems;
                var selectedItem = dgvCart.CurrentRow.DataBoundItem as CartItemDisplay;
                if (selectedItem != null)
                {
                    _cartItems.Remove(selectedItem);
                    UpdateCartDisplay();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove from cart.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Please add items to cart before processing order.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter customer name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            try
            {
                //Convert cart items to order items for saving
                var orderItems = _cartItems.Select(cartItem => new OrderItems
                {
                    ProductID = cartItem.ProductID,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice,
                    TotalPrice = cartItem.TotalPrice
                }).ToList();

                var order = new Orders
                {
                    CustomerName = txtCustomerName.Text.Trim(),
                    Notes = txtNotes.Text.Trim(),
                    Remarks = txtRemarks.Text.Trim(),
                    OrderDate = dtpOrderDate.Value,
                    IsPaid = chkIsPaid.Checked,
                    TotalAmount = _totalAmount
                };

                int orderId = _orders.CreateOrder(order, orderItems);

                _lastProcessedOrder = new Orders
                {
                    OrderID = orderId,
                    CustomerName = order.CustomerName,
                    Notes = order.Notes,
                    Remarks = order.Remarks,
                    OrderDate = order.OrderDate,
                    IsPaid = order.IsPaid,
                    TotalAmount = order.TotalAmount,
                    Items = orderItems
                };

                MessageBox.Show($"Order processed successfully!\nOrder ID: {orderId}\nTotal Amount: {_totalAmount:C2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing order: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            _cartItems.Clear();
            UpdateCartDisplay();
            txtCustomerName.Clear();
            txtNotes.Clear();
            txtRemarks.Clear();
            chkIsPaid.Checked = false;
            dtpOrderDate.Value = DateTime.Now;
            RefreshProductList();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearchProduct.Text.Trim();
            var products = _products.SearchProductsForOrder(searchTerm);
            dgvProducts.DataSource = products;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only select if it's a data row (not header)
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                //dgvProducts.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCart.Rows.Count)
            {
                //dgvCart.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvCart_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }

        private void btn_OrderDetails_Click(object sender, EventArgs e)
        {
            if(_lastProcessedOrder != null)
            {
                OrderDetailsForm orderDetailsForm = new OrderDetailsForm(_lastProcessedOrder);
                orderDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No order has been processed yet.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //OrderDetailsForm orderDetailsForm = new OrderDetailsForm();
                //orderDetailsForm.Show();
            }

        }
    }
}
