using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        private SmoothTransition transition;
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public InventoryForm()
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
        

            DisplaySupplier();
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
        private async void btn_Dashboard_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new DashboardForm(), OnFormReturn);
        }

        private async void btn_Products_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new ProductForm(), OnFormReturn);
        }

        private async void btn_History_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new HistoryF(), OnFormReturn);
        }

        private async void btn_Report_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new ReportFrom(), OnFormReturn);
        }

        public void DisplaySupplier()
        {
            dgv_supplier.DataSource = supplier.GetAllSuppliers();
            dgv_supplier.Columns["SupplierID"].Visible = false;
            dgv_supplier.Columns["IsActive"].Visible = false;
            dgv_supplier.Columns["CreatedDate"].Visible = false;
            dgv_supplier.Columns["Products"].Visible = false;

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

        private void btn_Inventory_Click(object sender, EventArgs e)
        {

        }
    }
}
