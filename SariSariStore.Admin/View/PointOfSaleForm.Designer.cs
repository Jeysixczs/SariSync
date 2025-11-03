namespace SariSariStore.Admin.View
{
    partial class PointOfSaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointOfSaleForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btn_back = new Button();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            dgvProducts = new DataGridView();
            label2 = new Label();
            txtSearchProduct = new TextBox();
            label12 = new Label();
            panel3 = new Panel();
            dgvCart = new DataGridView();
            panel4 = new Panel();
            label10 = new Label();
            chkIsPaid = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            txtRemarks = new TextBox();
            label4 = new Label();
            txtNotes = new TextBox();
            label3 = new Label();
            txtCustomerName = new TextBox();
            label1 = new Label();
            panel5 = new Panel();
            txtTotal = new Label();
            btnProcessOrder = new Button();
            btnRemovefromCart = new Button();
            label8 = new Label();
            panel6 = new Panel();
            btnAddtoCart = new Button();
            numericQuantity = new NumericUpDown();
            label9 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 20, 50);
            panel1.Controls.Add(btn_back);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(pictureBox6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 80);
            panel1.TabIndex = 8;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(28, 28, 65);
            btn_back.FlatAppearance.BorderSize = 0;
          
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(1180, 20);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(170, 40);
            btn_back.TabIndex = 4;
            btn_back.Text = "BACK";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(120, 20);
            label7.Name = "label7";
            label7.Size = new Size(145, 45);
            label7.TabIndex = 2;
            label7.Text = "SariSync";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(30, 5);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(80, 70);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 3;
            pictureBox6.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 50);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(dgvProducts);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtSearchProduct);
            panel2.Controls.Add(label12);
            panel2.Location = new Point(30, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(650, 500);
            panel2.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Snacks", "Drinks", "Beverages", "Instant Noodles", "Canned Goods", "Household", "Toiletries", "Groceries", "Condiments", "Candies", "Bread", "Frozen Goods", "Miscellaneous" });
            comboBox1.Location = new Point(494, 87);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 29;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(74, 107, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(74, 107, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.ColumnHeadersHeight = 45;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.GridColor = Color.FromArgb(240, 240, 240);
            dgvProducts.Location = new Point(25, 125);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowTemplate.Height = 40;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(600, 350);
            dgvProducts.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(25, 62);
            label2.Name = "label2";
            label2.Size = new Size(107, 19);
            label2.TabIndex = 12;
            label2.Text = "Search Products";
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.BorderStyle = BorderStyle.FixedSingle;
            txtSearchProduct.Font = new Font("Segoe UI", 11F);
            txtSearchProduct.Location = new Point(25, 85);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.Size = new Size(458, 27);
            txtSearchProduct.TabIndex = 10;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(25, 20);
            label12.Name = "label12";
            label12.Size = new Size(178, 30);
            label12.TabIndex = 11;
            label12.Text = "Product Section";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(20, 20, 50);
            panel3.Controls.Add(dgvCart);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(700, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(650, 500);
            panel3.TabIndex = 10;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(250, 250, 250);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(74, 107, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(74, 107, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvCart.ColumnHeadersHeight = 45;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle6;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.GridColor = Color.FromArgb(240, 240, 240);
            dgvCart.Location = new Point(25, 135);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 40;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(600, 340);
            dgvCart.TabIndex = 30;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(28, 28, 65);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(chkIsPaid);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtRemarks);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtNotes);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txtCustomerName);
            panel4.Location = new Point(25, 60);
            panel4.Name = "panel4";
            panel4.Size = new Size(600, 60);
            panel4.TabIndex = 29;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(427, 32);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 25;
            label10.Text = "label10";
            // 
            // chkIsPaid
            // 
            chkIsPaid.AutoSize = true;
            chkIsPaid.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkIsPaid.ForeColor = Color.White;
            chkIsPaid.Location = new Point(536, 26);
            chkIsPaid.Name = "chkIsPaid";
            chkIsPaid.Size = new Size(49, 19);
            chkIsPaid.TabIndex = 20;
            chkIsPaid.Text = "Paid";
            chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(430, 10);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 24;
            label6.Text = "Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(285, 10);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 23;
            label5.Text = "Remarks";
            // 
            // txtRemarks
            // 
            txtRemarks.BorderStyle = BorderStyle.None;
            txtRemarks.Font = new Font("Segoe UI", 10F);
            txtRemarks.Location = new Point(285, 30);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.PlaceholderText = " ";
            txtRemarks.Size = new Size(120, 18);
            txtRemarks.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(150, 10);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 22;
            label4.Text = "Notes";
            // 
            // txtNotes
            // 
            txtNotes.BorderStyle = BorderStyle.None;
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(150, 30);
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = " ";
            txtNotes.Size = new Size(120, 18);
            txtNotes.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 10);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 21;
            label3.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            txtCustomerName.BorderStyle = BorderStyle.None;
            txtCustomerName.Font = new Font("Segoe UI", 10F);
            txtCustomerName.Location = new Point(15, 30);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = " ";
            txtCustomerName.Size = new Size(120, 18);
            txtCustomerName.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(140, 30);
            label1.TabIndex = 11;
            label1.Text = "Cart Section";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(28, 28, 65);
            panel5.Controls.Add(txtTotal);
            panel5.Controls.Add(btnProcessOrder);
            panel5.Controls.Add(btnRemovefromCart);
            panel5.Controls.Add(label8);
            panel5.Location = new Point(700, 620);
            panel5.Name = "panel5";
            panel5.Size = new Size(650, 80);
            panel5.TabIndex = 11;
            // 
            // txtTotal
            // 
            txtTotal.AutoSize = true;
            txtTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotal.ForeColor = Color.White;
            txtTotal.Location = new Point(113, 25);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(76, 25);
            txtTotal.TabIndex = 27;
            txtTotal.Text = "label11";
            // 
            // btnProcessOrder
            // 
            btnProcessOrder.BackColor = Color.FromArgb(76, 175, 80);
            btnProcessOrder.FlatAppearance.BorderSize = 0;
            btnProcessOrder.FlatStyle = FlatStyle.Flat;
            btnProcessOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProcessOrder.ForeColor = Color.White;
            btnProcessOrder.Location = new Point(440, 20);
            btnProcessOrder.Name = "btnProcessOrder";
            btnProcessOrder.Size = new Size(185, 40);
            btnProcessOrder.TabIndex = 26;
            btnProcessOrder.Text = "✅ Process Order";
            btnProcessOrder.UseVisualStyleBackColor = false;
            btnProcessOrder.Click += btnProcessOrder_Click;
            // 
            // btnRemovefromCart
            // 
            btnRemovefromCart.BackColor = Color.FromArgb(255, 87, 87);
            btnRemovefromCart.FlatAppearance.BorderSize = 0;
            btnRemovefromCart.FlatStyle = FlatStyle.Flat;
            btnRemovefromCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemovefromCart.ForeColor = Color.White;
            btnRemovefromCart.Location = new Point(270, 20);
            btnRemovefromCart.Name = "btnRemovefromCart";
            btnRemovefromCart.Size = new Size(150, 40);
            btnRemovefromCart.TabIndex = 26;
            btnRemovefromCart.Text = "🗑️ Remove Item";
            btnRemovefromCart.UseVisualStyleBackColor = false;
            btnRemovefromCart.Click += btnRemovefromCart_Click_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(25, 25);
            label8.Name = "label8";
            label8.Size = new Size(60, 25);
            label8.TabIndex = 25;
            label8.Text = "Total:";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(28, 28, 65);
            panel6.Controls.Add(btnAddtoCart);
            panel6.Controls.Add(numericQuantity);
            panel6.Controls.Add(label9);
            panel6.Location = new Point(30, 620);
            panel6.Name = "panel6";
            panel6.Size = new Size(650, 80);
            panel6.TabIndex = 12;
            // 
            // btnAddtoCart
            // 
            btnAddtoCart.BackColor = Color.FromArgb(74, 107, 255);
            btnAddtoCart.FlatAppearance.BorderSize = 0;
            btnAddtoCart.FlatStyle = FlatStyle.Flat;
            btnAddtoCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddtoCart.ForeColor = Color.White;
            btnAddtoCart.Location = new Point(250, 20);
            btnAddtoCart.Name = "btnAddtoCart";
            btnAddtoCart.Size = new Size(375, 40);
            btnAddtoCart.TabIndex = 14;
            btnAddtoCart.Text = "\U0001f6d2 Add to Cart";
            btnAddtoCart.UseVisualStyleBackColor = false;
            btnAddtoCart.Click += btnAddtoCart_Click_1;
            // 
            // numericQuantity
            // 
            numericQuantity.BorderStyle = BorderStyle.None;
            numericQuantity.Font = new Font("Segoe UI", 12F);
            numericQuantity.Location = new Point(105, 27);
            numericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(120, 25);
            numericQuantity.TabIndex = 13;
            numericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(25, 28);
            label9.Name = "label9";
            label9.Size = new Size(74, 20);
            label9.TabIndex = 13;
            label9.Text = "Quantity:";
            // 
            // PointOfSaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(1400, 720);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PointOfSaleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Point of Sale";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Panel panel1;
        private Label label7;
        private PictureBox pictureBox6;
        private DataGridView dgvProducts;
        private TextBox txtSearchProduct;
        private Label label12;
        private Label label1;
        private Label label2;
        private NumericUpDown numericQuantity;
        private Button btnAddtoCart;
        private DataGridView dgvCart;
        private TextBox txtCustomerName;
        private TextBox txtNotes;
        private TextBox txtRemarks;
        private CheckBox chkIsPaid;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Button btnRemovefromCart;
        private Button btnProcessOrder;
        private Button btn_back;
        private Label label9;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private ComboBox comboBox1;
        private Label label10;
        private Label txtTotal;
    }
}