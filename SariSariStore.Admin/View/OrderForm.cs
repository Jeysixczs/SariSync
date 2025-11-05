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

namespace SariSariStore.Admin.View.Interface
{
    public partial class OrderForm : Form
    {
        public int cornerRadius = 30;
        public Rounded rounded;
        public OrderForm()
        {
            InitializeComponent();
            rounded = new Rounded();
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            displayorder();
            StyleProductGrid();
        }

        private void StyleProductGrid()
        {
            dgv_Orders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Orders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Orders.ColumnHeadersHeight = 40;
            dgv_Orders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Orders.MultiSelect = false;
            dgv_Orders.ReadOnly = true;
            dgv_Orders.AllowUserToAddRows = false;
            dgv_Orders.AllowUserToDeleteRows = false;
            dgv_Orders.AllowUserToResizeRows = false;
            dgv_Orders.RowHeadersVisible = false;
            dgv_Orders.BorderStyle = BorderStyle.None;
            dgv_Orders.BackgroundColor = Color.White;
            dgv_Orders.GridColor = Color.LightGray;


            dgv_Orders.EnableHeadersVisualStyles = false;
            dgv_Orders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219); // Blue header
            dgv_Orders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_Orders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv_Orders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgv_Orders.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv_Orders.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Orders.DefaultCellStyle.BackColor = Color.White;
            dgv_Orders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230); // Light blue
            dgv_Orders.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_Orders.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
            dgv_Orders.RowTemplate.Height = 35;


            dgv_Orders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);


            dgv_Orders.Location = new Point(65, 103);
            dgv_Orders.Size = new Size(1032, 472);
        }

        private void OrderForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);

        }

        private void displayorder()
        {
            Orders orders = new Orders();
            dgv_Orders.DataSource = orders.GetAllOrders();

        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgv_Orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
