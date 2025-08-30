using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SariSariStore.Admin.View.Interface;
using SariSariStore.Core.Model;
using SariSariStore.Core.Services;
using SariSariStore.Core.Services.Interface;
using System;
using System.Windows.Forms;

namespace SariSariStore.Admin
{
    public partial class MainForm : Form, IMainForm
    {
        public Products products;
        private readonly IOrderService _orderService;
        public MainForm(IOrderService orderService)
        {
            InitializeComponent();
            products = new Products();
            LoadProducts(); // Load products when form loads
            _orderService = orderService;
        }

      

        private void addProductButton_Click(object sender, EventArgs e)
        {
            AddEditProductForm addProductForm = new AddEditProductForm();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (productsDataGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            var selectedProductId = productsDataGrid.CurrentRow.Cells["Product_ID"].Value;
            if (selectedProductId == null)
            {
                MessageBox.Show("Please select a valid product.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    products.DeleteProduct(Convert.ToInt32(selectedProductId));
                    LoadProducts(); // Refresh the grid after deleting
                    MessageBox.Show("Product deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}");
                }
            }
        }



        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            if (productsDataGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            var selectedProductId = productsDataGrid.CurrentRow.Cells["Product_ID"].Value;
            if (selectedProductId == null)
            {
                MessageBox.Show("Please select a valid product.");
                return;
            }

            try
            {
                int productId = Convert.ToInt32(selectedProductId);
                AddEditProductForm editProductForm = new AddEditProductForm(productId);

                if (editProductForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts(); // Refresh the grid after editing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit form: {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void LoadProducts()
        {
            try
            {
                // Store current selection by Product_ID (more reliable than index)
                object selectedProductId = 0;
                if (productsDataGrid.CurrentRow != null &&
                    productsDataGrid.CurrentRow.Cells["Product_ID"].Value != null)
                {
                    selectedProductId = productsDataGrid.CurrentRow.Cells["Product_ID"].Value;
                }

                // Clear and reload data
                productsDataGrid.Rows.Clear();
                var allProducts = products.GetAllProducts();

                foreach (var product in allProducts)
                {
                    int rowIndex = productsDataGrid.Rows.Add(
                        product.Id,
                        product.Name,
                        product.Description,
                        product.Category,
                        product.Price,
                        product.Stock,
                        product.Image
                    );
                }

                // Restore selection by Product_ID
                if (selectedProductId != null)
                {
                    bool found = false;
                    foreach (DataGridViewRow row in productsDataGrid.Rows)
                    {
                        if (row.Cells["Product_ID"].Value != null &&
                            row.Cells["Product_ID"].Value.ToString() == selectedProductId.ToString())
                        {
                            row.Selected = true;
                            productsDataGrid.CurrentCell = row.Cells[0];
                            productsDataGrid.FirstDisplayedScrollingRowIndex = row.Index; // Scroll to row
                            found = true;
                            break;
                        }
                    }

                    // If not found, select the first row
                    if (!found && productsDataGrid.Rows.Count > 0)
                    {
                        productsDataGrid.Rows[0].Selected = true;
                        productsDataGrid.CurrentCell = productsDataGrid.Rows[0].Cells[0];
                    }
                }
                else if (productsDataGrid.Rows.Count > 0)
                {
                    // If no previous selection, select the first row
                    productsDataGrid.Rows[0].Selected = true;
                    productsDataGrid.CurrentCell = productsDataGrid.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        public void LoadOrders()
        {
            throw new NotImplementedException();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(_orderService);
            historyForm.ShowDialog();
        }
    }
}