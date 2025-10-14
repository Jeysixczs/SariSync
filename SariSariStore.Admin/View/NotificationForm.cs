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
        }
    }
}
