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
    public partial class NotificationForm : Form
    {

        public Products prod = new Products();
        public NotificationForm()
        {
            InitializeComponent();
            dgv_stock.ForeColor = Color.Black;
        }


        private void NotificationForm_Load(object sender, EventArgs e)
        {
            dgv_stock.DataSource = prod.GetStockProducts("low");
            disabledcolumn();
        }

        private void btn_lowstock_Click(object sender, EventArgs e)
        {
            dgv_stock.DataSource = prod.GetStockProducts("low");
            disabledcolumn();
        }

        private void btn_mediumstock_Click(object sender, EventArgs e)
        {
            dgv_stock.DataSource = prod.GetStockProducts("medium");
            disabledcolumn();
        }

        private void btn_highstock_Click(object sender, EventArgs e)
        {
            dgv_stock.DataSource = prod.GetStockProducts("high");

            disabledcolumn();
        }

        private void disabledcolumn()
        {

            dgv_stock.Columns["Description"].Visible = false;
            dgv_stock.Columns["Price"].Visible = false;
            dgv_stock.Columns["DateAdded"].Visible = false;
            dgv_stock.Columns["ImagePath"].Visible = false;
            dgv_stock.Columns["DateExpired"].Visible = false;
            dgv_stock.Columns["SellingPrice"].Visible = false;
            dgv_stock.Columns["SupplierID"].Visible = false;
            dgv_stock.Columns["SupplierName"].Visible = false;
            dgv_stock.Columns["Payment_Supplier"].Visible = false;
        }

        private void dgv_stock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_stock_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_stock_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dgv_stock.SelectedRows.Count > 0)
            {

                int selectedProductId = Convert.ToInt32(dgv_stock.SelectedRows[0].Cells["ProductID"].Value);
                int selectedSupplierId = Convert.ToInt32(dgv_stock.SelectedRows[0].Cells["SupplierID"].Value);

                AddEditProductForm editForm = new AddEditProductForm(selectedProductId, selectedSupplierId);
                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {

                    dgv_stock.DataSource = prod.GetStockProducts("low");
                    disabledcolumn();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_stock.SelectedRows.Count > 0)
            {
                Products prod = new Products();
                int selectedCount = dgv_stock.SelectedRows.Count;

                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgv_stock.SelectedRows)
                        {
                            int selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
                            prod.DeleteProduct(selectedProductId);
                        }


                        dgv_stock.DataSource = prod.GetStockProducts("low");
                        disabledcolumn();

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv_stock != null)
            {
                dgv_stock.MultiSelect = checkBox1.Checked;
                dgv_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (checkBox1.Checked == true)
                {
                    dgv_stock.MultiSelect = true;
                    dgv_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
                else
                {
                    dgv_stock.MultiSelect = false;
                    dgv_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }

        private void dgv_stock_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && checkBox1.Checked)
            {
                dgv_stock.Rows[e.RowIndex].Selected = !dgv_stock.Rows[e.RowIndex].Selected;
            }
        }
    }
}
