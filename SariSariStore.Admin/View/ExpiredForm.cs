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
    public partial class ExpiredForm : Form
    {
        Products prod = new Products();
        public ExpiredForm()
        {
            InitializeComponent();


            dgv_ExpiredProduct.DataSource = prod.GetExpiredProducts();

            dgv_ExpiredProduct.Columns["Price"].Visible = false;
            dgv_ExpiredProduct.Columns["ImagePath"].Visible = false;
            dgv_ExpiredProduct.Columns["DateAdded"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["DateExpired"].DefaultCellStyle.Format = "MM/dd/yyyy";

            labelTotalCount.Text = prod.DisplayExpiredProducts();
            labelCriticalCount.Text = prod.DisplayCriticalExpiredProducts();
            UpdateCountLabels();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgv_ExpiredProduct.SelectedRows.Count > 0)
            {
                Products prod = new Products();
                int selectedCount = dgv_ExpiredProduct.SelectedRows.Count;

                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgv_ExpiredProduct.SelectedRows)
                        {
                            int selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
                            prod.DeleteProduct(selectedProductId);
                        }

                        RefreshDataGridView();
                        MessageBox.Show($"{selectedCount} product(s) deleted successfully.");
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

        private void ExpiredForm_Load(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_ExpiredProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBoxMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_ExpiredProduct != null)
            {
                dgv_ExpiredProduct.MultiSelect = checkBoxMultiSelect.Checked;
                dgv_ExpiredProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (checkBoxMultiSelect.Checked == true)
                {
                    dgv_ExpiredProduct.MultiSelect = true;
                    dgv_ExpiredProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
                else
                {
                    dgv_ExpiredProduct.MultiSelect = false;
                    dgv_ExpiredProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }

        private void dgv_ExpiredProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelGridView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelStats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Expired_Click(object sender, EventArgs e)
        {
            dgv_ExpiredProduct.DataSource = null;
            dgv_ExpiredProduct.DataSource = prod.GetExpiredProducts();
            dgv_ExpiredProduct.Columns["DateAdded"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["DateExpired"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["Price"].Visible = false;
            dgv_ExpiredProduct.Columns["ImagePath"].Visible = false;

            UpdateCountLabels();
        }

        private void btn_Critical_Click(object sender, EventArgs e)
        {
            dgv_ExpiredProduct.DataSource = null;
            dgv_ExpiredProduct.DataSource = prod.GetCriticalExpiredProducts();
            dgv_ExpiredProduct.Columns["DateAdded"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["DateExpired"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["Price"].Visible = false;
            dgv_ExpiredProduct.Columns["ImagePath"].Visible = false;

            UpdateCountLabels();
        }

        private void dgv_ExpiredProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_ExpiredProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && checkBoxMultiSelect.Checked)
            {
                dgv_ExpiredProduct.Rows[e.RowIndex].Selected = !dgv_ExpiredProduct.Rows[e.RowIndex].Selected;
            }
        }

        private void dgv_ExpiredProduct_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void RefreshDataGridView()
        {
            dgv_ExpiredProduct.DataSource = null;
            dgv_ExpiredProduct.DataSource = prod.GetExpiredProducts();
            dgv_ExpiredProduct.Columns["DateAdded"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["DateExpired"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["Price"].Visible = false;
            dgv_ExpiredProduct.Columns["ImagePath"].Visible = false;

            UpdateCountLabels();
        }

        private void UpdateCountLabels()
        {
            labelTotalCount.Text = prod.DisplayExpiredProducts();
            labelCriticalCount.Text = prod.DisplayCriticalExpiredProducts();
        }
    }
}
