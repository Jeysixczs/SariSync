using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
using System.Data;

namespace SariSariStore.Admin.View
{
    public partial class PointOfSaleForm : Form
    {
        private Products _products;
        private Orders _orders;
        private List<CartItemDisplay> _cartItems;
        private decimal _totalAmount;
        public SmoothTransition transition = new SmoothTransition();
        public PointOfSaleForm()
        {
            InitializeComponent();
            _products = new Products();
            _orders = new Orders();
            _cartItems = new List<CartItemDisplay>();
            initializeForm();
            DisplayCategory();

        }

        private void initializeForm()
        {
            RefreshProductList();
            UpdateCartDisplay();
            Getdate();
        }

        public void Getdate()
        {
            DateTime now = DateTime.Now;
            label10.Text = now.ToString("MMM dd, yyyy");

        }
        private void RefreshProductList()
        {
            var products = _products.GetAllProducts();
            dgvProducts.DataSource = products;

            dgvProducts.Columns["ProductID"].Visible = false;
            dgvProducts.Columns["Description"].Visible = false;
            dgvProducts.Columns["ImagePath"].Visible = false;
            dgvProducts.Columns["Price"].Visible = false;
            dgvProducts.Columns["DateAdded"].Visible = false;
            dgvProducts.Columns["DateExpired"].Visible = false;
            dgvProducts.Columns["SupplierID"].Visible = false;
            dgvProducts.Columns["SupplierName"].Visible = false;
            dgvProducts.Columns["supplier_payment"].Visible = false;
            dgvProducts.Columns["supplier"].Visible = false;

        }


        private void AddToCart(int productId, int quantity)
        {
            // This should only check stock, not reduce it
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
            else
            {
                MessageBox.Show("Product not found or out of stock.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateCartDisplay()
        {

            try
            {
                dgvCart.DataSource = null;
                if (_cartItems != null && _cartItems.Count > 0)
                {
                    dgvCart.DataSource = _cartItems;
                }
                else
                {
                    dgvCart.DataSource = new List<CartItemDisplay>();
                }

                _totalAmount = _cartItems?.Sum(item => item.TotalPrice) ?? 0;
                txtTotal.Text = _totalAmount.ToString("C2");
                Calculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating cart display: {ex.Message}", "Error",
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

            RefreshProductList();
        }

        private void btnAddtoCart_Click_1(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
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

        private void btnRemovefromCart_Click_1(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index >= 0)
            {
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

            if (!chkIsPaid.Checked)
            {
                MessageBox.Show("You can't process the order until payment is received.",
                    "Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var orderItems = _cartItems.Select(item => new OrderItems
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ProductName = item.ProductName // Make sure to include ProductName
                }).ToList();

                var order = new Orders
                {
                    CustomerName = txtCustomerName.Text.Trim(),
                    Notes = txtNotes.Text.Trim(),
                    Remarks = txtRemarks.Text.Trim(),
                    OrderDate = DateTime.Now,
                    IsPaid = chkIsPaid.Checked,
                    TotalAmount = _totalAmount,
                    Items = orderItems // Set the items for the receipt
                };

                // Process the order
                bool success = _orders.ProcessOrder(order, orderItems);

                if (success)
                {
                    // Ask user if they want to show/print the receipt
                    var result = MessageBox.Show("Order processed successfully! Do you want to view the receipt?",
                        "Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Show the receipt form
                        ReceiptForm receiptForm = new ReceiptForm(order);
                        receiptForm.ShowDialog();
                    }

                    ClearForm();
                    RefreshProductList();

                    MessageBox.Show("Order processed successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to process order. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing order: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBox1.SelectedItem.ToString();
            if (selectedCategory == "-- All Products --")
            {
                dgvProducts.DataSource = _products.GetAllProducts();
            }
            else
            {
                dgvProducts.DataSource = _products.GetProductsByCategory(selectedCategory);
            }
        }

        public void DisplayCategory()
        {

            Products prod = new Products();
            var categories = prod.GetCategorys();

            comboBox1.Items.Clear();

            comboBox1.Items.Add("-- All Products --");

            foreach (var category in categories)
            {
                if (!string.IsNullOrEmpty(category.Category))
                {
                    comboBox1.Items.Add(category.Category);
                }
            }
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearchProduct.Text.Trim();
            var products = _products.SearchProduct(searchTerm);
            dgvProducts.DataSource = products;
        }

        private void OnFormReturn(Form parentForm)
        {
            parentForm.Opacity = 0;
            parentForm.Visible = true;
            transition.FastFadeIn(parentForm, 60);
            parentForm.BringToFront();
            parentForm.Focus();
        }

        private async void btn_back_Click_1(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new DashboardForm(), OnFormReturn);
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotal_Click(object sender, EventArgs e)
        {

        }

        private void txt_AmountReceived_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void Calculate()
        {
            if (decimal.TryParse(txt_AmountReceived.Text.Trim(), out decimal amountReceived))
            {
                decimal change = amountReceived - _totalAmount;

                // Only show positive change, otherwise show 0.00
                if (change >= 0)
                {
                    label13.Text = change.ToString("C2");
                }
                else
                {
                    label13.Text = "0.00";
                }
            }
            else
            {
                label13.Text = "0.00";
            }
        }
    }
}
