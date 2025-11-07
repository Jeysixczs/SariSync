using Microsoft.Data.SqlClient;
using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SariSariStore.Admin.View
{
    public partial class ProductForm : Form
    {
        public int cornerRadius = 30;
        public Rounded rounded;
        public Products prod = new Products();
        private SmoothTransition transition;
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public ProductForm()
        {
            InitializeComponent();
            rounded = new Rounded();
         
            transition = new SmoothTransition();

            EnableDoubleBuffering();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw, true);

            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetWindowLong(this.Handle, -20, GetWindowLong(this.Handle, -20) | 0x02000000);
            }
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            StyleProductGrid();
            DisplayProduct();
            DisplayCategory();     
        }

        private void EnableDoubleBuffering()
        {
            this.DoubleBuffered = true;
        }

     

        private void OnFormReturn(Form parentForm)
        {
            parentForm.Opacity = 0;
            parentForm.Visible = true;
            transition.FastFadeIn(parentForm, 60);
            parentForm.BringToFront();
            parentForm.Focus();
        }


        private void StyleProductGrid()
        {
            dgv_Product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Product.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Product.ColumnHeadersHeight = 40;
            dgv_Product.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Product.MultiSelect = false;
            dgv_Product.ReadOnly = true;
            dgv_Product.AllowUserToAddRows = false;
            dgv_Product.AllowUserToDeleteRows = false;
            dgv_Product.AllowUserToResizeRows = false;
            dgv_Product.RowHeadersVisible = false;
            dgv_Product.BorderStyle = BorderStyle.None;
            dgv_Product.BackgroundColor = Color.White;
            dgv_Product.GridColor = Color.LightGray;


            dgv_Product.EnableHeadersVisualStyles = false;
            dgv_Product.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219); // Blue header
            dgv_Product.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_Product.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv_Product.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgv_Product.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv_Product.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Product.DefaultCellStyle.BackColor = Color.White;
            dgv_Product.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230); // Light blue
            dgv_Product.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_Product.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
            dgv_Product.RowTemplate.Height = 35;


            dgv_Product.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);


            dgv_Product.Location = new Point(29, 113);
            dgv_Product.Size = new Size(1068, 472);
        }

        private void ProductForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }

        private async void btn_Dashboard_Click(object sender, EventArgs e)
        {
           await transition.ShowFormSafely(this, new DashboardForm(), OnFormReturn);

        }

        private async void btn_Inventory_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new InventoryForm(), OnFormReturn);
        }

        private async void btn_History_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new HistoryF(), OnFormReturn);
        }

        private async void btn_Report_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new ReportFrom(), OnFormReturn);
        }

        public void DisplayProduct()
        {
            dgv_Product.DataSource = prod.GetAllProducts();

            dgv_Product.Columns["ProductID"].Visible = false;
            dgv_Product.Columns["DateAdded"].Visible = false;
            dgv_Product.Columns["SupplierName"].Visible = false;
            dgv_Product.Columns["DateExpired"].Visible = false;

            dgv_Product.Columns["ImagePath"].Visible = false;
            dgv_Product.Columns["SupplierID"].Visible = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddEditProductForm add = new AddEditProductForm();

            var result = add.ShowDialog();

            if (result == DialogResult.OK)
            {
                DisplayProduct();
            }

        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {

        }
        private void btn_Update_Click(object sender, EventArgs e)
        {

           
            if (dgv_Product.SelectedRows.Count > 0)
            {

                int selectedProductId = Convert.ToInt32(dgv_Product.SelectedRows[0].Cells["ProductID"].Value);
                int selectedSupplierId = Convert.ToInt32(dgv_Product.SelectedRows[0].Cells["SupplierID"].Value);

                AddEditProductForm editForm = new AddEditProductForm(selectedProductId, selectedSupplierId);
                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {

                    DisplayProduct();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_Product.SelectedRows.Count > 0)
            {
                Products prod = new Products();
                int selectedProductId = Convert.ToInt32(dgv_Product.SelectedRows[0].Cells["ProductID"].Value);

                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        prod.DeleteProduct(selectedProductId);
                        DisplayProduct();
                        MessageBox.Show("Product deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_Search_TextChanged(object sender, EventArgs e)
        {

            string searchTerm = txtbox_Search.Text.Trim();

            dgv_Product.DataSource = prod.SearchProduct(searchTerm);


        }

        private void dgv_Product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SmoothTransition smoothTransition = new SmoothTransition();
                Shutdownform shutdownForm = new Shutdownform(smoothTransition);

                this.Hide();
                shutdownForm.Show();
            }
        }

        private void cmb_Search_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedCategory = cmb_Search.SelectedItem.ToString();
            if (selectedCategory == "-- All Products --")
            {
                dgv_Product.DataSource = prod.GetAllProducts();
            }
            else
            {
                dgv_Product.DataSource = prod.GetProductsByCategory(selectedCategory);
            }
        }


        private void cmb_Search_TextChanged_1(object sender, EventArgs e)
        {

        }

        public void DisplayCategory()
        {

            Products prod = new Products();
            var categories = prod.GetCategorys();

            cmb_Search.Items.Clear();

            cmb_Search.Items.Add("-- All Products --");

            foreach (var category in categories)
            {
                if (!string.IsNullOrEmpty(category.Category))
                {
                    cmb_Search.Items.Add(category.Category);
                }
            }
            cmb_Search.SelectedIndex = 0;
            cmb_Search.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            ExpiredForm expiredForm = new ExpiredForm();
            expiredForm.Show();


        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Product_Click(object sender, EventArgs e)
        {
           
        }
    }

}

