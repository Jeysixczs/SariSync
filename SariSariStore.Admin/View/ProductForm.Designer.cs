namespace SariSariStore.Admin.View
{
    partial class ProductForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            panel1 = new Panel();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            panel2 = new Panel();
            txtbox_Search = new TextBox();
            pictureBox10 = new PictureBox();
            btn_Delete = new Button();
            pictureBox9 = new PictureBox();
            btn_Update = new Button();
            pictureBox8 = new PictureBox();
            dgv_Product = new DataGridView();
            btn_Add = new Button();
            label12 = new Label();
            panel3 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btn_Report = new Button();
            button6 = new Button();
            btn_History = new Button();
            btn_Inventory = new Button();
            btn_Products = new Button();
            btn_Dashboard = new Button();
            RefreshTimer = new System.Windows.Forms.Timer(components);
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Product).BeginInit();
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
            panel1.Controls.Add(label7);
            panel1.Controls.Add(pictureBox6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1397, 66);
            panel1.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Symbol", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(114, 11);
            label7.Name = "label7";
            label7.Size = new Size(123, 37);
            label7.TabIndex = 2;
            label7.Text = "SariSync";
            label7.Click += label7_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(12, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(131, 70);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 3;
            pictureBox6.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 50);
            panel2.Controls.Add(txtbox_Search);
            panel2.Controls.Add(pictureBox10);
            panel2.Controls.Add(btn_Delete);
            panel2.Controls.Add(pictureBox9);
            panel2.Controls.Add(btn_Update);
            panel2.Controls.Add(pictureBox8);
            panel2.Controls.Add(dgv_Product);
            panel2.Controls.Add(btn_Add);
            panel2.Controls.Add(label12);
            panel2.Location = new Point(254, 72);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(100);
            panel2.Size = new Size(1127, 724);
            panel2.TabIndex = 7;
            // 
            // txtbox_Search
            // 
            txtbox_Search.Location = new Point(64, 69);
            txtbox_Search.Name = "txtbox_Search";
            txtbox_Search.Size = new Size(1033, 23);
            txtbox_Search.TabIndex = 16;
            txtbox_Search.TextChanged += txtbox_Search_TextChanged;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox10.Image = Properties.Resources.icons8_reports_64;
            pictureBox10.Location = new Point(570, 644);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(45, 39);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 15;
            pictureBox10.TabStop = false;
            // 
            // btn_Delete
            // 
            btn_Delete.BackColor = Color.FromArgb(28, 28, 65);
            btn_Delete.FlatStyle = FlatStyle.Flat;
            btn_Delete.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Delete.ForeColor = Color.Transparent;
            btn_Delete.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Delete.Location = new Point(557, 633);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Padding = new Padding(19, 14, 14, 14);
            btn_Delete.Size = new Size(192, 68);
            btn_Delete.TabIndex = 14;
            btn_Delete.Text = "DELETE";
            btn_Delete.UseVisualStyleBackColor = false;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox9.Image = Properties.Resources.icons8_reports_64;
            pictureBox9.Location = new Point(332, 644);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(45, 39);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 13;
            pictureBox9.TabStop = false;
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.FromArgb(28, 28, 65);
            btn_Update.FlatStyle = FlatStyle.Flat;
            btn_Update.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Update.ForeColor = Color.Transparent;
            btn_Update.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Update.Location = new Point(319, 633);
            btn_Update.Name = "btn_Update";
            btn_Update.Padding = new Padding(19, 14, 14, 14);
            btn_Update.Size = new Size(192, 68);
            btn_Update.TabIndex = 12;
            btn_Update.Text = "UPDATE";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox8.Image = Properties.Resources.icons8_reports_64;
            pictureBox8.Location = new Point(80, 644);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(45, 39);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 11;
            pictureBox8.TabStop = false;
            // 
            // dgv_Product
            // 
            dgv_Product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Product.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Product.Location = new Point(65, 139);
            dgv_Product.Name = "dgv_Product";
            dgv_Product.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Product.Size = new Size(1032, 472);
            dgv_Product.TabIndex = 4;
            dgv_Product.CellContentClick += dgv_Product_CellContentClick;
            // 
            // btn_Add
            // 
            btn_Add.BackColor = Color.FromArgb(28, 28, 65);
            btn_Add.FlatStyle = FlatStyle.Flat;
            btn_Add.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Add.ForeColor = Color.Transparent;
            btn_Add.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Add.Location = new Point(67, 633);
            btn_Add.Name = "btn_Add";
            btn_Add.Padding = new Padding(19, 14, 14, 14);
            btn_Add.Size = new Size(192, 68);
            btn_Add.TabIndex = 10;
            btn_Add.Text = "ADD";
            btn_Add.UseVisualStyleBackColor = false;
            btn_Add.Click += btn_Add_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Transparent;
            label12.Location = new Point(79, 37);
            label12.Name = "label12";
            label12.Size = new Size(114, 25);
            label12.TabIndex = 2;
            label12.Text = "PRODUCTS";
            label12.Click += label12_Click;
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
            panel3.Controls.Add(button6);
            panel3.Controls.Add(btn_History);
            panel3.Controls.Add(btn_Inventory);
            panel3.Controls.Add(btn_Products);
            panel3.Controls.Add(btn_Dashboard);
            panel3.Location = new Point(12, 72);
            panel3.Name = "panel3";
            panel3.Size = new Size(225, 724);
            panel3.TabIndex = 11;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(32, 646);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(36, 28);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 9;
            pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox7.Image = Properties.Resources.icons8_reports_64;
            pictureBox7.Location = new Point(32, 459);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(45, 39);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 7;
            pictureBox7.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox4.Image = Properties.Resources.icons8_history_64;
            pictureBox4.Location = new Point(32, 365);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(45, 39);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox3.Image = Properties.Resources.icons8_inventory_64;
            pictureBox3.Location = new Point(32, 265);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 39);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(40, 40, 65);
            pictureBox2.Image = Properties.Resources.icons8_product_64;
            pictureBox2.Location = new Point(32, 170);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(28, 28, 65);
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources.icons8_dashboard_64;
            pictureBox1.Location = new Point(32, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btn_Report
            // 
            btn_Report.BackColor = Color.FromArgb(28, 28, 65);
            btn_Report.FlatStyle = FlatStyle.Flat;
            btn_Report.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Report.ForeColor = Color.Transparent;
            btn_Report.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Report.Location = new Point(19, 448);
            btn_Report.Name = "btn_Report";
            btn_Report.Padding = new Padding(19, 14, 14, 14);
            btn_Report.Size = new Size(192, 68);
            btn_Report.TabIndex = 3;
            btn_Report.Text = "Report";
            btn_Report.UseVisualStyleBackColor = false;
            btn_Report.Click += btn_Report_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(28, 28, 65);
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            button6.ForeColor = Color.Transparent;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(19, 624);
            button6.Name = "button6";
            button6.Padding = new Padding(14);
            button6.Size = new Size(192, 68);
            button6.TabIndex = 3;
            button6.Text = "Shutdown";
            button6.TextAlign = ContentAlignment.MiddleRight;
            button6.UseVisualStyleBackColor = false;
            // 
            // btn_History
            // 
            btn_History.BackColor = Color.FromArgb(28, 28, 65);
            btn_History.FlatStyle = FlatStyle.Flat;
            btn_History.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_History.ForeColor = Color.Transparent;
            btn_History.ImageAlign = ContentAlignment.MiddleLeft;
            btn_History.Location = new Point(19, 347);
            btn_History.Name = "btn_History";
            btn_History.Padding = new Padding(20, 14, 14, 14);
            btn_History.Size = new Size(192, 68);
            btn_History.TabIndex = 3;
            btn_History.Text = "History";
            btn_History.UseVisualStyleBackColor = false;
            btn_History.Click += btn_History_Click;
            // 
            // btn_Inventory
            // 
            btn_Inventory.BackColor = Color.FromArgb(28, 28, 65);
            btn_Inventory.FlatStyle = FlatStyle.Flat;
            btn_Inventory.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Inventory.ForeColor = Color.Transparent;
            btn_Inventory.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Inventory.Location = new Point(19, 251);
            btn_Inventory.Name = "btn_Inventory";
            btn_Inventory.Padding = new Padding(33, 14, 14, 14);
            btn_Inventory.Size = new Size(192, 68);
            btn_Inventory.TabIndex = 3;
            btn_Inventory.Text = "Suppliers";
            btn_Inventory.UseVisualStyleBackColor = false;
            btn_Inventory.Click += btn_Inventory_Click;
            // 
            // btn_Products
            // 
            btn_Products.BackColor = Color.FromArgb(40, 40, 65);
            btn_Products.FlatStyle = FlatStyle.Flat;
            btn_Products.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Products.ForeColor = Color.Transparent;
            btn_Products.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Products.Location = new Point(19, 155);
            btn_Products.Name = "btn_Products";
            btn_Products.Padding = new Padding(33, 14, 14, 14);
            btn_Products.Size = new Size(192, 68);
            btn_Products.TabIndex = 3;
            btn_Products.Text = "Inventory";
            btn_Products.UseVisualStyleBackColor = false;
            // 
            // btn_Dashboard
            // 
            btn_Dashboard.BackColor = Color.FromArgb(28, 28, 65);
            btn_Dashboard.FlatStyle = FlatStyle.Flat;
            btn_Dashboard.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Dashboard.ForeColor = Color.Transparent;
            btn_Dashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Dashboard.Location = new Point(19, 58);
            btn_Dashboard.Name = "btn_Dashboard";
            btn_Dashboard.Padding = new Padding(50, 14, 14, 14);
            btn_Dashboard.Size = new Size(192, 68);
            btn_Dashboard.TabIndex = 3;
            btn_Dashboard.Text = "Dashboard";
            btn_Dashboard.UseVisualStyleBackColor = false;
            btn_Dashboard.Click += btn_Dashboard_Click;
            // 
            // RefreshTimer
            // 
            RefreshTimer.Enabled = true;
            RefreshTimer.Tick += RefreshTimer_Tick;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1397, 820);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductForm";
            Resize += ProductForm_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Product).EndInit();
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
        private Label label12;
        private Panel panel3;
        private PictureBox pictureBox5;
        private PictureBox pictureBox7;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btn_Report;
        private Button button6;
        private Button btn_History;
        private Button btn_Inventory;
        private Button btn_Products;
        private Button btn_Dashboard;
        private DataGridView dgv_Product;
        private PictureBox pictureBox8;
        private Button btn_Add;
        private System.Windows.Forms.Timer RefreshTimer;
        private PictureBox pictureBox10;
        private Button btn_Delete;
        private PictureBox pictureBox9;
        private Button btn_Update;
        private TextBox txtbox_Search;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}