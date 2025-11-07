namespace SariSariStore.Admin.View
{
    partial class HistoryF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryF));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btn_printreceipt = new Button();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            panel2 = new Panel();
            txtSearch = new TextBox();
            label12 = new Label();
            dgv_orderhistory = new DataGridView();
            panel14 = new Panel();
            panel3 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btn_Report = new Button();
            btn_shutdown = new Button();
            btn_History = new Button();
            btn_Inventory = new Button();
            btn_Products = new Button();
            btn_Dashboard = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_orderhistory).BeginInit();
            panel14.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 65);
            panel1.Controls.Add(btn_printreceipt);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(pictureBox6);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            panel1.Paint += panel1_Paint;
            // 
            // btn_printreceipt
            // 
            btn_printreceipt.BackColor = Color.FromArgb(40, 40, 65);
            btn_printreceipt.ForeColor = Color.White;
            resources.ApplyResources(btn_printreceipt, "btn_printreceipt");
            btn_printreceipt.Name = "btn_printreceipt";
            btn_printreceipt.UseVisualStyleBackColor = false;
            btn_printreceipt.Click += btn_printreceipt_Click;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.BackColor = Color.Transparent;
            label7.ForeColor = Color.Transparent;
            label7.Name = "label7";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            resources.ApplyResources(pictureBox6, "pictureBox6");
            pictureBox6.Name = "pictureBox6";
            pictureBox6.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 50);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(dgv_orderhistory);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.ForeColor = Color.Transparent;
            label12.Name = "label12";
            // 
            // dgv_orderhistory
            // 
            dgv_orderhistory.AllowUserToAddRows = false;
            dgv_orderhistory.AllowUserToDeleteRows = false;
            dgv_orderhistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgv_orderhistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_orderhistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_orderhistory.BackgroundColor = Color.White;
            dgv_orderhistory.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_orderhistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(dgv_orderhistory, "dgv_orderhistory");
            dgv_orderhistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(173, 216, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_orderhistory.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_orderhistory.EnableHeadersVisualStyles = false;
            dgv_orderhistory.GridColor = Color.LightGray;
            dgv_orderhistory.MultiSelect = false;
            dgv_orderhistory.Name = "dgv_orderhistory";
            dgv_orderhistory.ReadOnly = true;
            dgv_orderhistory.RowHeadersVisible = false;
            dgv_orderhistory.RowTemplate.Height = 35;
            dgv_orderhistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_orderhistory.CellContentClick += dgv_orderhistory_CellContentClick;
            dgv_orderhistory.CellDoubleClick += dgv_orderhistory_CellDoubleClick;
            // 
            // panel14
            // 
            panel14.Controls.Add(panel3);
            resources.ApplyResources(panel14, "panel14");
            panel14.Name = "panel14";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(20, 20, 50);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox7);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(btn_Report);
            panel3.Controls.Add(btn_shutdown);
            panel3.Controls.Add(btn_History);
            panel3.Controls.Add(btn_Inventory);
            panel3.Controls.Add(btn_Products);
            panel3.Controls.Add(btn_Dashboard);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(28, 28, 65);
            resources.ApplyResources(pictureBox5, "pictureBox5");
            pictureBox5.Name = "pictureBox5";
            pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox7.Image = Properties.Resources.icons8_reports_64;
            resources.ApplyResources(pictureBox7, "pictureBox7");
            pictureBox7.Name = "pictureBox7";
            pictureBox7.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(40, 40, 65);
            pictureBox4.Image = Properties.Resources.icons8_history_64;
            resources.ApplyResources(pictureBox4, "pictureBox4");
            pictureBox4.Name = "pictureBox4";
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox3.Image = Properties.Resources.icons8_inventory_64;
            resources.ApplyResources(pictureBox3, "pictureBox3");
            pictureBox3.Name = "pictureBox3";
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox2.Image = Properties.Resources.icons8_product_64;
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(28, 28, 65);
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.icons8_dashboard_64;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // btn_Report
            // 
            btn_Report.BackColor = Color.FromArgb(28, 28, 65);
            resources.ApplyResources(btn_Report, "btn_Report");
            btn_Report.ForeColor = Color.Transparent;
            btn_Report.Name = "btn_Report";
            btn_Report.UseVisualStyleBackColor = false;
            btn_Report.Click += btn_Report_Click;
            // 
            // btn_shutdown
            // 
            btn_shutdown.BackColor = Color.FromArgb(28, 28, 65);
            resources.ApplyResources(btn_shutdown, "btn_shutdown");
            btn_shutdown.ForeColor = Color.Transparent;
            btn_shutdown.Name = "btn_shutdown";
            btn_shutdown.UseVisualStyleBackColor = false;
            btn_shutdown.Click += btn_shutdown_Click;
            // 
            // btn_History
            // 
            btn_History.BackColor = Color.FromArgb(40, 40, 65);
            resources.ApplyResources(btn_History, "btn_History");
            btn_History.ForeColor = Color.Transparent;
            btn_History.Name = "btn_History";
            btn_History.UseVisualStyleBackColor = false;
            btn_History.Click += btn_History_Click;
            // 
            // btn_Inventory
            // 
            btn_Inventory.BackColor = Color.FromArgb(28, 28, 65);
            resources.ApplyResources(btn_Inventory, "btn_Inventory");
            btn_Inventory.ForeColor = Color.Transparent;
            btn_Inventory.Name = "btn_Inventory";
            btn_Inventory.UseVisualStyleBackColor = false;
            btn_Inventory.Click += btn_Inventory_Click;
            // 
            // btn_Products
            // 
            btn_Products.BackColor = Color.FromArgb(28, 28, 65);
            resources.ApplyResources(btn_Products, "btn_Products");
            btn_Products.ForeColor = Color.Transparent;
            btn_Products.Name = "btn_Products";
            btn_Products.UseVisualStyleBackColor = false;
            btn_Products.Click += btn_Products_Click;
            // 
            // btn_Dashboard
            // 
            btn_Dashboard.BackColor = Color.FromArgb(28, 28, 65);
            resources.ApplyResources(btn_Dashboard, "btn_Dashboard");
            btn_Dashboard.ForeColor = Color.Transparent;
            btn_Dashboard.Name = "btn_Dashboard";
            btn_Dashboard.UseVisualStyleBackColor = false;
            btn_Dashboard.Click += btn_Dashboard_Click;
            // 
            // HistoryF
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel14);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "HistoryF";
            Resize += HistoryF_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_orderhistory).EndInit();
            panel14.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label7;
        private PictureBox pictureBox6;
        private Panel panel2;
        private Panel panel14;
        private Panel panel3;
        private PictureBox pictureBox5;
        private PictureBox pictureBox7;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btn_Report;
        private Button btn_shutdown;
        private Button btn_History;
        private Button btn_Inventory;
        private Button btn_Products;
        private Button btn_Dashboard;
        private Button printReceiptButton;
        private DataGridView dgv_orderhistory;
        private Label label12;
        private Button btn_printreceipt;
        private TextBox txtSearch;
    }
}