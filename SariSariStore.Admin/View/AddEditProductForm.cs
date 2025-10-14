using Microsoft.Data.SqlClient;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using SariSariStore.Core.Model;

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

        // Constructor for adding new product
        public AddEditProductForm()
        {
            InitializeComponent();
            products = new Products();
            _isEditMode = false;
            EnsureImagesDirectoryExists();
        }

        // Constructor for editing an existing product
        public AddEditProductForm(int productId)
        {
            InitializeComponent();
            products = new Products();
            _productId = productId;
            _isEditMode = true;
            this.Text = "Edit Product";
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
            if (_isEditMode)
            {
                LoadProductData();
            }
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

                txtboxProductName.Text = product.Name;
                txtboxDescription.Text = product.Description ?? string.Empty;
                cmbCategory.Text = product.Category;
                numericPrice.Value = product.Price;
                NumericStock.Value = product.Stock;
                dtp_ExpirationDate.Value = product.DateExpired ?? DateTime.Now;


                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    selectedImagePath = product.ImagePath;
                   
                    DisplayImageInPanel(selectedImagePath);
                }
                else
                {
                    
                    panel1.BackgroundImage = null;
                    panel1.BackColor = Color.LightGray;
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

                var product = new Products
                {
                    Name = txtboxProductName.Text.Trim(),
                    Description = txtboxDescription.Text.Trim(),
                    Category = cmbCategory.Text.Trim(),
                    Price = numericPrice.Value,
                    Stock = (int)NumericStock.Value,
                    DateAdded = DateTime.Now,
                    DateExpired = dtp_ExpirationDate.Value
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


        private void Btn_UploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    temporaryImagePath = openFileDialog.FileName;
                    
                    DisplayImageInPanel(temporaryImagePath);
                }
            }
        }

        private void DisplayImageInPanel(string imagePath)
        {
            try
            {
                if (panel1.BackgroundImage != null)
                {
                    panel1.BackgroundImage.Dispose();
                }

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    panel1.BackgroundImage = Image.FromFile(imagePath);
                    panel1.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    panel1.BackgroundImage = null;
                    panel1.BackColor = Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                panel1.BackgroundImage = null;
                panel1.BackColor = Color.LightGray;
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            temporaryImagePath = string.Empty;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
