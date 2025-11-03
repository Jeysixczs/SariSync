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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            



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


        }

        private void btn_Critical_Click(object sender, EventArgs e)
        {
            dgv_ExpiredProduct.DataSource = null;
            dgv_ExpiredProduct.DataSource = prod.GetCriticalExpiredProducts();
            dgv_ExpiredProduct.Columns["DateAdded"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["DateExpired"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv_ExpiredProduct.Columns["Price"].Visible = false;
            dgv_ExpiredProduct.Columns["ImagePath"].Visible = false;
        }

        private void dgv_ExpiredProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgv_ExpiredProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgv_ExpiredProduct_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
    }
}
