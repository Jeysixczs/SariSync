using Microsoft.Data.SqlClient;
using SariSariStore.Core.Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SariSariStore.Admin
{
    public partial class AddEditProductForm : Form
    {

        private string selectedImagePath = string.Empty;
        private string temporaryImagePath = string.Empty;
        private readonly Products products;
        private readonly int _productId;
        private readonly bool _isEditMode;

        private static readonly string ImagesDirectory =
            Path.Combine(Environment.CurrentDirectory, "ProductImages");

       
        public AddEditProductForm()
        {
            InitializeComponent();
            products = new Products();
            _isEditMode = false;
            EnsureImagesDirectoryExists();
            DisplayCategory();
            DisplaySupplierName();
        }

       
        public AddEditProductForm(int productId, int supplierId)
        {
            InitializeComponent();
            products = new Products();
            _productId = productId;
            _isEditMode = true;
            DisplayCategory();
            DisplaySupplierName();
            labelTitle.Text = "Edit Product";
            EnsureImagesDirectoryExists();
        }

        private void EnsureImagesDirectoryExists()
        {
            try
            {
                if (!Directory.Exists(ImagesDirectory))
                {
                    Directory.CreateDirectory(ImagesDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating images directory: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEditProductForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadProductData()
        {
            try
            {
                var product = products.GetProductById(_productId);

                if (product == null)
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Populate the textboxes with actual data
                txtboxProductName.Text = product.Name;
                txtboxDescription.Text = product.Description ?? string.Empty;
                cmbCategory.Text = product.Category;
                numericPrice.Value = product.Price;
                NumericStock.Value = product.Stock;
                numericPaymenttosupplier.Value = product.supplier_payment;
                numericSellingPrice.Value = product.SellingPrice;

                if (product.SupplierID > 0)
                {
               
                    foreach (Supplier item in cmbSupplier.Items)
                    {
                        if (item.SupplierID == product.SupplierID)
                        {
                            cmbSupplier.SelectedItem = item;
                            break;
                        }
                    }
                }
                if (product.DateExpired == null)
                {
                    checkBox1.Checked = true;
                    dtp_ExpirationDate.Enabled = false;
                }
                else
                {
                    checkBox1.Checked = false;
                    dtp_ExpirationDate.Enabled = true;
                    dtp_ExpirationDate.Value = product.DateExpired.Value;
                }

               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtboxProductName.Text) ||
                    string.IsNullOrWhiteSpace(cmbCategory.Text))
                {
                    MessageBox.Show("Please fill in required fields (Product Name and Category).",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int supplierId = 0;
                if (cmbSupplier.SelectedValue != null)
                {
                    supplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
                }

                DateTime? dateExpired = checkBox1.Checked ? null : dtp_ExpirationDate.Value;


                var product = new Products
                {
                    Name = txtboxProductName.Text.Trim(),
                    Description = txtboxDescription.Text.Trim(),
                    Category = cmbCategory.Text.Trim(),
                    Price = numericPrice.Value,
                    Stock = (int)NumericStock.Value,
                    DateAdded = DateTime.Now,
                    supplier_payment = numericPaymenttosupplier.Value,
                    DateExpired = dateExpired,
                    SellingPrice = numericSellingPrice.Value,
                    SupplierID = supplierId,
                  
                };

              
                string imagePathToSave = selectedImagePath;

                if (!string.IsNullOrEmpty(temporaryImagePath))
                {
                    string fileName = Path.GetFileName(temporaryImagePath);
                    string destinationPath = Path.Combine(ImagesDirectory, fileName);
                    File.Copy(temporaryImagePath, destinationPath, true);
                    imagePathToSave = destinationPath;
                }

                if (_isEditMode)
                {
                    product.ProductID = _productId;
                    products.UpdateProduct(product, imagePathToSave);
                    MessageBox.Show("✅ Product updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int newId = products.AddProduct(product, imagePathToSave);
                    MessageBox.Show($"✅ Product added successfully! (ID: {newId})", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Price and Stock.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

       

        private void cancelButton_Click(object sender, EventArgs e)
        {
            temporaryImagePath = string.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddEditProductForm_Load_1(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                LoadProductData();
            }
        }

        private void dtp_ExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtp_ExpirationDate.Value;
            DateTime currentYear = new DateTime(DateTime.Now.Year, 1, 1);

            if (selectedDate < currentYear)
            {
                MessageBox.Show("Expiration date cannot be earlier than the current year.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_ExpirationDate.Value = DateTime.Today;
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void DisplayCategory()
        {

            Products prod = new Products();
            var categories = prod.GetCategorys();

            cmbCategory.Items.Clear();

            foreach (var category in categories)
            {

                cmbCategory.Items.Add(category.Category);

            }

        }

        private void numericSellingPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        public void DisplaySupplierName()
        {
            try
            {
                Supplier suppliers = new Supplier();
                var sup = suppliers.GetAllSuppliers();

                // Make sure to include only active suppliers
                cmbSupplier.DataSource = sup.Where(s => s.IsActive).ToList();
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierID";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dtp_ExpirationDate.Enabled = !checkBox1.Checked;

            // Optional: Clear the date when enabling if it's a default/min value
            if (!checkBox1.Checked && (dtp_ExpirationDate.Value == DateTime.MinValue || dtp_ExpirationDate.Value < DateTime.Now))
            {
                dtp_ExpirationDate.Value = DateTime.Now.AddMonths(6); // Only set when user explicitly wants to set a date
            }
        }
    }
}
