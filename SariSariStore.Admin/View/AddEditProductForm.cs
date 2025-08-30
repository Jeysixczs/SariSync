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
        public string ConnectionString = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=db_SariSync;Integrated Security=True;Trust Server Certificate=True";
        private string selectedImagePath = string.Empty;
        private string temporaryImagePath = string.Empty;
        public Products products;
        private int _productId = 0;
        private bool _isEditMode = false;

        private static readonly string ImagesDirectory = Path.Combine(Environment.CurrentDirectory, "ProductImages");

        public AddEditProductForm()
        {
            InitializeComponent();
            products = new Products();
            EnsureImagesDirectoryExists();
        }

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
                MessageBox.Show($"Error creating images directory: {ex.Message}");
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
                if (product != null)
                {
                    txtboxProductName.Text = product.Name;
                    txtboxDescription.Text = product.Description ?? string.Empty;
                    cmbCategory.Text = product.Category;
                    numericPrice.Value = product.Price;
                    NumericStock.Value = product.Stock;

                    if (!string.IsNullOrEmpty(product.Image))
                    {
                        selectedImagePath = product.Image;
                        lblStatus.Text = "Current image: " + Path.GetFileName(product.Image);
                        DisplayImageInPanel(selectedImagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product: {ex.Message}");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtboxProductName.Text) || string.IsNullOrEmpty(cmbCategory.Text))
                {
                    MessageBox.Show("Please fill in required fields (Product Name and Category)");
                    return;
                }

                Products productManager = new Products();
                Products product = new Products
                {
                    Name = txtboxProductName.Text,
                    Description = txtboxDescription.Text,
                    Category = cmbCategory.Text,
                    Price = numericPrice.Value,
                    Stock = (int)NumericStock.Value
                };

                string imagePathToSave = selectedImagePath;

                if (!string.IsNullOrEmpty(temporaryImagePath))
                {
                    imagePathToSave = temporaryImagePath;
                }

                if (_isEditMode)
                {
                    product.Id = _productId;
                    productManager.UpdateProduct(product, imagePathToSave);
                    MessageBox.Show("Product updated successfully!");
                }
                else
                {
                    int newId = productManager.AddProduct(product, imagePathToSave);
                    MessageBox.Show($"Product added successfully with ID: {newId}");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Price and Stock");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
                    lblStatus.Text = "Selected: " + Path.GetFileName(temporaryImagePath);
                    DisplayImageInPanel(temporaryImagePath);
                }
            }
        }



        private void DisplayImageInPanel(string imagePath)
        {
            try
            {
                panel1.BackgroundImage = null;

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