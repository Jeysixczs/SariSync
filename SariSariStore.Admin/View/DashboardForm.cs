using Microsoft.Data.SqlClient;
using SariSariStore.Admin.Model;
using SariSariStore.Admin.View.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        public string connectionstring = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public DashboardForm()
        {
            InitializeComponent();
            rounded = new Rounded();
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            //rounded.MakePanelRounded(panel4, 30);
            //rounded.MakePanelRounded(panel5, 30);
            //rounded.MakePanelRounded(panel6, 30);
            //rounded.MakePanelRounded(panel7, 30);
            //rounded.MakePanelRounded(panel8, 30);
            //rounded.MakePanelRounded(panel9, 30);
            rounded.MakePanelRounded(panel10, 30);
            rounded.MakePanelRounded(panel11, 30);
            rounded.MakePanelRounded(panel12, 30);
            rounded.MakePanelRounded(panel13, 30);

            LoadDisplay();
        }


        private void Dashboard_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {


        }

        private void btn_Products_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
            this.Hide();
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.Show();
            this.Hide();
        }

        private void btn_History_Click(object sender, EventArgs e)
        {
            HistoryF historyF = new HistoryF();
            historyF.Show();
            this.Hide();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            ReportFrom reportFrom = new ReportFrom();
            reportFrom.Show();
            this.Hide();
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

        private void btn_Order_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
            this.Hide();
        }

        private void btn_notification_Click(object sender, EventArgs e)
        {
            NotificationForm notificationForm = new NotificationForm();
            notificationForm.ShowDialog();


        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {

        }
    }
}
