using SariSariStore.Admin.Model;
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
    public partial class InventoryForm : Form
    {
        private Rounded rounded;
        public int cornerRadius = 30;
        public ProductForm prod = new ProductForm();
        public Supplier supplier = new Supplier();
        public InventoryForm()
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
            //rounded.MakePanelRounded(panel10, 30);
            //rounded.MakePanelRounded(panel11, 30);
            //rounded.MakePanelRounded(panel12, 30);
            //rounded.MakePanelRounded(panel13, 30);

            DisplaySupplier();
        }



        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }

        private void btn_Products_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
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

        private void btn_StockStatus_Click(object sender, EventArgs e)
        {
            NotificationForm stock = new NotificationForm();
            stock.ShowDialog();
        }

        private void dgv_supplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void DisplaySupplier()
        {
            dgv_supplier.DataSource = supplier.GetAllSuppliers();

            //HIDE COLUMN SUPPLIERID
            dgv_supplier.Columns["SupplierID"].Visible = false;
            dgv_supplier.Columns["IsActive"].Visible = false;




        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void InventoryForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }

        private void dgv_supplier_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_AddSupplier_Click(object sender, EventArgs e)
        {
            AddEditSupplierForm addEditSupplierForm = new AddEditSupplierForm();

            addEditSupplierForm.ShowDialog();

            DisplaySupplier();
        }

        private void btn_EditSupplier_Click(object sender, EventArgs e)
        {
            if (dgv_supplier.SelectedRows.Count > 0)
            {

                int selectedProductId = Convert.ToInt32(dgv_supplier.SelectedRows[0].Cells["SupplierID"].Value);
                MessageBox.Show(selectedProductId.ToString());
                AddEditSupplierForm editForm = new AddEditSupplierForm(selectedProductId);
                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {

                    DisplaySupplier();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_DeleteSupplier_Click(object sender, EventArgs e)
        {

            int selectedProductId = Convert.ToInt32(dgv_supplier.SelectedRows[0].Cells["SupplierID"].Value);
            supplier.DeleteSupplier(selectedProductId);
            DisplaySupplier();
        }
    }
}
