using Microsoft.Data.SqlClient;
using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SariSariStore.Admin.View
{
    public partial class DashboardForm : Form
    {
        private Rounded rounded;
        
        public int cornerRadius = 30;
        public Products products = new Products();
        public string connectionstring = ConnectionHelper.GetConnectionString();
        private SmoothTransition transition;
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public DashboardForm()
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

            rounded = new Rounded();
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            rounded.MakePanelRounded(panel10, 30);
            rounded.MakePanelRounded(panel11, 30);
            rounded.MakePanelRounded(panel12, 30);
            rounded.MakePanelRounded(panel13, 30);

            LoadDisplay();
            DisplayLatestProducts();
        }

        private void EnableDoubleBuffering()
        {
            this.DoubleBuffered = true;
           
        }


        private async void btn_Products_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new ProductForm(), OnFormReturn);

        }

        private async void btn_Inventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            await transition.ShowFormSafely(this, new InventoryForm(), OnFormReturn);
            this.Hide();
        }

        private async void btn_History_Click(object sender, EventArgs e)
        {
            this.Hide();
            await transition.ShowFormSafely(this, new HistoryF(), OnFormReturn);
            this.Hide();
        }

        private async void btn_Report_Click(object sender, EventArgs e)
        {
            this.Hide();
            await transition.ShowFormSafely(this, new ReportFrom(), OnFormReturn);
            this.Hide();
        }

        private void btn_notification_Click(object sender, EventArgs e)
        {
           
            NotificationForm notificationForm = new NotificationForm();
            notificationForm.ShowDialog();

        }

        private async void btnWalkins_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new PointOfSaleForm(), OnFormReturn);

        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();

        }
        private void OnFormReturn(Form parentForm)
        {
            parentForm.Opacity = 0;
            parentForm.Visible = true;
            transition.FastFadeIn(parentForm, 60);
            parentForm.BringToFront();
            parentForm.Focus();
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SmoothTransition smoothTransition = new SmoothTransition();
                Shutdownform shutdownForm = new Shutdownform(smoothTransition);

                this.Hide();
                shutdownForm.Show();

            }
        }
        private void Dashboard_Resize(object sender, EventArgs e)
        {
            Invalidate();

            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);

        }

        public void LoadDisplay()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();

                using (SqlCommand loadCategory = new SqlCommand("SELECT * FROM vw_BestSellingCategory", con))
                using (SqlDataReader readCategory = loadCategory.ExecuteReader())
                {
                    if (readCategory.Read())
                    {
                        txt_bestcat.Text = readCategory["Category"].ToString();
                    }
                }

                using (SqlCommand loadProduct = new SqlCommand("SELECT * FROM vw_BestSellingProduct", con))
                using (SqlDataReader readProduct = loadProduct.ExecuteReader())
                {
                    if (readProduct.Read())
                    {
                        txt_bestprod.Text = readProduct["Name"].ToString();
                    }
                }

                using (SqlCommand loadInventorySummary = new SqlCommand("SELECT COUNT(ProductID) AS TotalProducts FROM tbl_Product", con))
                using (SqlDataReader readInventorySummary = loadInventorySummary.ExecuteReader())
                {
                    if (readInventorySummary.Read())
                    {
                        txt_inventorysum.Text = readInventorySummary["TotalProducts"].ToString();
                    }
                }

                using (SqlCommand loadTotalSales = new SqlCommand("SELECT * FROM vw_TotalSales", con))
                using (SqlDataReader readTotalSales = loadTotalSales.ExecuteReader())
                {
                    if (readTotalSales.Read())
                    {
                        txt_totalsales.Text = readTotalSales["TotalSales"].ToString();
                    }
                }
            }
        }

        private void DisplayLatestProducts()
        {
            dgv_LatestProduct.DataSource = products.Gettop10Products();

            dgv_LatestProduct.Columns["ProductID"].Visible = false;
            dgv_LatestProduct.Columns["ImagePath"].Visible = false;
            dgv_LatestProduct.Columns["DateExpired"].Visible = false;
            dgv_LatestProduct.Columns["SupplierName"].Visible = false;
            dgv_LatestProduct.Columns["SupplierID"].Visible = false;
            dgv_LatestProduct.Columns["Payment_Supplier"].Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel5_Click(object sender, EventArgs e) { }
        private void btn_Dashboard_Click(object sender, EventArgs e) { }
        private void dgv_LatestProduct_CellContentClick(object sender, DataGridViewCellEventArgs e) { }



    }

}