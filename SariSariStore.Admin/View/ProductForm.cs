using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
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

namespace SariSariStore.Admin.View
{
    public partial class ProductForm : Form
    {
        public int cornerRadius = 30;
        public Rounded rounded;
        public ProductForm()
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

            DisplayProduct();
        }

        private void ProductForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }

        private void panel4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
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

        public void DisplayProduct()
        {
            Products prod = new Products();

            List<Products> productlist = prod.GetAllProducts();

            dgv_Product.DataSource = productlist;
        }
    }
}
