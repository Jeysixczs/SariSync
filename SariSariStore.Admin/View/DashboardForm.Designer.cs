namespace SariSariStore.Admin.View
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            panel1 = new Panel();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            panel2 = new Panel();
            label12 = new Label();
            panel11 = new Panel();
            label1 = new Label();
            pictureBox9 = new PictureBox();
            panel13 = new Panel();
            label14 = new Label();
            pictureBox11 = new PictureBox();
            panel12 = new Panel();
            label13 = new Label();
            pictureBox10 = new PictureBox();
            panel10 = new Panel();
            pictureBox8 = new PictureBox();
            label9 = new Label();
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
            txt_bestcat = new Label();
            txt_inventorysum = new Label();
            txt_bestprod = new Label();
            txt_totalsales = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
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
            panel1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Symbol", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(114, 11);
            label7.Name = "label7";
            label7.Size = new Size(123, 37);
            label7.TabIndex = 2;
            label7.Text = "SariSync";
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
            panel2.Controls.Add(label12);
            panel2.Controls.Add(panel11);
            panel2.Controls.Add(panel13);
            panel2.Controls.Add(panel12);
            panel2.Controls.Add(panel10);
            panel2.Location = new Point(254, 72);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(100);
            panel2.Size = new Size(1127, 724);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Transparent;
            label12.Location = new Point(28, 35);
            label12.Name = "label12";
            label12.Size = new Size(130, 25);
            label12.TabIndex = 2;
            label12.Text = "DASHBOARD";
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(28, 28, 65);
            panel11.Controls.Add(txt_bestcat);
            panel11.Controls.Add(label1);
            panel11.Controls.Add(pictureBox9);
            panel11.Location = new Point(28, 191);
            panel11.Name = "panel11";
            panel11.Size = new Size(411, 224);
            panel11.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(124, 33);
            label1.Name = "label1";
            label1.Size = new Size(247, 25);
            label1.TabIndex = 2;
            label1.Text = "BEST SELLING CATEGORY";
            label1.Click += label1_Click;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Image = Properties.Resources.icons8_category_64;
            pictureBox9.Location = new Point(21, 22);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(78, 49);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 3;
            pictureBox9.TabStop = false;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(28, 28, 65);
            panel13.Controls.Add(txt_totalsales);
            panel13.Controls.Add(label14);
            panel13.Controls.Add(pictureBox11);
            panel13.Location = new Point(472, 438);
            panel13.Name = "panel13";
            panel13.Size = new Size(411, 224);
            panel13.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(122, 30);
            label14.Name = "label14";
            label14.Size = new Size(134, 25);
            label14.TabIndex = 2;
            label14.Text = "TOTAL SALES";
            // 
            // pictureBox11
            // 
            pictureBox11.Image = Properties.Resources.icons8_bill_64;
            pictureBox11.Location = new Point(21, 21);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(78, 49);
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox11.TabIndex = 3;
            pictureBox11.TabStop = false;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(28, 28, 65);
            panel12.Controls.Add(txt_bestprod);
            panel12.Controls.Add(label13);
            panel12.Controls.Add(pictureBox10);
            panel12.Location = new Point(28, 438);
            panel12.Name = "panel12";
            panel12.Size = new Size(411, 224);
            panel12.TabIndex = 0;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(124, 30);
            label13.Name = "label13";
            label13.Size = new Size(237, 25);
            label13.TabIndex = 2;
            label13.Text = "BEST SELLING PRODUCT";
            // 
            // pictureBox10
            // 
            pictureBox10.Image = Properties.Resources.icons8_best_seller_64;
            pictureBox10.Location = new Point(21, 21);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(78, 49);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 3;
            pictureBox10.TabStop = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(28, 28, 65);
            panel10.Controls.Add(txt_inventorysum);
            panel10.Controls.Add(pictureBox8);
            panel10.Controls.Add(label9);
            panel10.Location = new Point(472, 191);
            panel10.Name = "panel10";
            panel10.Size = new Size(411, 224);
            panel10.TabIndex = 0;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(18, 9);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(78, 49);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 3;
            pictureBox8.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(122, 22);
            label9.Name = "label9";
            label9.Size = new Size(226, 25);
            label9.TabIndex = 2;
            label9.Text = "INVENTORY SUMMARY";
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
            panel3.TabIndex = 10;
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
            pictureBox2.BackColor = Color.FromArgb(28, 28, 65);
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
            pictureBox1.BackColor = Color.FromArgb(40, 40, 65);
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
            btn_Inventory.Text = "Inventory";
            btn_Inventory.UseVisualStyleBackColor = false;
            btn_Inventory.Click += btn_Inventory_Click;
            // 
            // btn_Products
            // 
            btn_Products.BackColor = Color.FromArgb(28, 28, 65);
            btn_Products.FlatStyle = FlatStyle.Flat;
            btn_Products.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold);
            btn_Products.ForeColor = Color.Transparent;
            btn_Products.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Products.Location = new Point(19, 155);
            btn_Products.Name = "btn_Products";
            btn_Products.Padding = new Padding(33, 14, 14, 14);
            btn_Products.Size = new Size(192, 68);
            btn_Products.TabIndex = 3;
            btn_Products.Text = "Products";
            btn_Products.UseVisualStyleBackColor = false;
            btn_Products.Click += btn_Products_Click;
            // 
            // btn_Dashboard
            // 
            btn_Dashboard.BackColor = Color.FromArgb(40, 40, 65);
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
            // 
            // txt_bestcat
            // 
            txt_bestcat.AutoSize = true;
            txt_bestcat.Font = new Font("Elephant", 15.7499981F, FontStyle.Bold);
            txt_bestcat.ForeColor = Color.White;
            txt_bestcat.Location = new Point(57, 109);
            txt_bestcat.Name = "txt_bestcat";
            txt_bestcat.Size = new Size(83, 27);
            txt_bestcat.TabIndex = 4;
            txt_bestcat.Text = "label2";
            // 
            // txt_inventorysum
            // 
            txt_inventorysum.AutoSize = true;
            txt_inventorysum.Font = new Font("Elephant", 15.7499981F, FontStyle.Bold);
            txt_inventorysum.ForeColor = Color.White;
            txt_inventorysum.Location = new Point(41, 113);
            txt_inventorysum.Name = "txt_inventorysum";
            txt_inventorysum.Size = new Size(83, 27);
            txt_inventorysum.TabIndex = 4;
            txt_inventorysum.Text = "label2";
            // 
            // txt_bestprod
            // 
            txt_bestprod.AutoSize = true;
            txt_bestprod.Font = new Font("Elephant", 15.7499981F, FontStyle.Bold);
            txt_bestprod.ForeColor = Color.White;
            txt_bestprod.Location = new Point(57, 138);
            txt_bestprod.Name = "txt_bestprod";
            txt_bestprod.Size = new Size(83, 27);
            txt_bestprod.TabIndex = 4;
            txt_bestprod.Text = "label2";
            // 
            // txt_totalsales
            // 
            txt_totalsales.AutoSize = true;
            txt_totalsales.Font = new Font("Elephant", 15.7499981F, FontStyle.Bold);
            txt_totalsales.ForeColor = Color.White;
            txt_totalsales.Location = new Point(41, 138);
            txt_totalsales.Name = "txt_totalsales";
            txt_totalsales.Size = new Size(83, 27);
            txt_totalsales.TabIndex = 4;
            txt_totalsales.Text = "label2";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(1397, 820);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Resize += Dashboard_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
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
        private PictureBox pictureBox6;
        private Label label7;
        private Panel panel2;
        private Panel panel10;
        private PictureBox pictureBox8;
        private Label label9;
        private Label label12;
        private Panel panel12;
        private Label label13;
        private Panel panel11;
        private Label label1;
        private PictureBox pictureBox9;
        private Panel panel13;
        private Label label14;
        private PictureBox pictureBox11;
        private PictureBox pictureBox10;
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
        private Label txt_bestcat;
        private Label txt_totalsales;
        private Label txt_bestprod;
        private Label txt_inventorysum;
    }
}