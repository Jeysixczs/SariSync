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
            panel1 = new Panel();
            btn_back = new Button();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            dgvProducts = new DataGridView();
            txtSearchProduct = new TextBox();
            label12 = new Label();
            label1 = new Label();
            label2 = new Label();
            numericQuantity = new NumericUpDown();
            btnAddtoCart = new Button();
            dgvCart = new DataGridView();
            txtCustomerName = new TextBox();
            txtNotes = new TextBox();
            txtRemarks = new TextBox();
            dtpOrderDate = new DateTimePicker();
            chkIsPaid = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            btnRemovefromCart = new Button();
            btnProcessOrder = new Button();
            txtTotal = new TextBox();
            btnSearch = new Button();
            btn_OrderDetails = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 65);
            panel1.Controls.Add(btn_OrderDetails);
            panel1.Controls.Add(btn_back);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(pictureBox6);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1397, 66);
            panel1.TabIndex = 8;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(40, 40, 65);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(1230, 10);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(154, 46);
            btn_back.TabIndex = 4;
            btn_back.Text = "BACK";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
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
            // dgvProducts
            // 
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(34, 222);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(580, 391);
            dgvProducts.TabIndex = 9;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(35, 171);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.Size = new Size(439, 23);
            txtSearchProduct.TabIndex = 10;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Transparent;
            label12.Location = new Point(13, 75);
            label12.Name = "label12";
            label12.Size = new Size(160, 25);
            label12.TabIndex = 11;
            label12.Text = "Product Section";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(761, 75);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 11;
            label1.Text = "Cart Section";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(34, 148);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 12;
            label2.Text = "Search";
            // 
            // numericQuantity
            // 
            numericQuantity.Location = new Point(95, 634);
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(173, 23);
            numericQuantity.TabIndex = 13;
            // 
            // btnAddtoCart
            // 
            btnAddtoCart.Location = new Point(314, 634);
            btnAddtoCart.Name = "btnAddtoCart";
            btnAddtoCart.Size = new Size(116, 23);
            btnAddtoCart.TabIndex = 14;
            btnAddtoCart.Text = "Add to Cart";
            btnAddtoCart.UseVisualStyleBackColor = true;
            btnAddtoCart.Click += btnAddtoCart_Click;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(761, 222);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(580, 391);
            dgvCart.TabIndex = 15;
            dgvCart.CellClick += dgvCart_CellClick;
            dgvCart.SelectionChanged += dgvCart_SelectionChanged;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(761, 143);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(137, 23);
            txtCustomerName.TabIndex = 16;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(761, 193);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(137, 23);
            txtNotes.TabIndex = 17;
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(1044, 143);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(137, 23);
            txtRemarks.TabIndex = 18;
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Location = new Point(1044, 190);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(203, 23);
            dtpOrderDate.TabIndex = 19;
            // 
            // chkIsPaid
            // 
            chkIsPaid.AutoSize = true;
            chkIsPaid.ForeColor = Color.White;
            chkIsPaid.Location = new Point(1259, 143);
            chkIsPaid.Name = "chkIsPaid";
            chkIsPaid.Size = new Size(60, 19);
            chkIsPaid.TabIndex = 20;
            chkIsPaid.Text = "Is Paid";
            chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(761, 125);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 21;
            label3.Text = "Customer Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(761, 175);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 22;
            label4.Text = "Notes";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(1044, 125);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 23;
            label5.Text = "Remarks";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(1044, 175);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 24;
            label6.Text = "Date";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Transparent;
            label8.Location = new Point(899, 634);
            label8.Name = "label8";
            label8.Size = new Size(64, 25);
            label8.TabIndex = 25;
            label8.Text = "Total:";
            // 
            // btnRemovefromCart
            // 
            btnRemovefromCart.Location = new Point(891, 698);
            btnRemovefromCart.Name = "btnRemovefromCart";
            btnRemovefromCart.Size = new Size(119, 27);
            btnRemovefromCart.TabIndex = 26;
            btnRemovefromCart.Text = "Remove from Cart";
            btnRemovefromCart.UseVisualStyleBackColor = true;
            btnRemovefromCart.Click += btnRemovefromCart_Click;
            // 
            // btnProcessOrder
            // 
            btnProcessOrder.Location = new Point(1093, 698);
            btnProcessOrder.Name = "btnProcessOrder";
            btnProcessOrder.Size = new Size(119, 27);
            btnProcessOrder.TabIndex = 26;
            btnProcessOrder.Text = "Process Order";
            btnProcessOrder.UseVisualStyleBackColor = true;
            btnProcessOrder.Click += btnProcessOrder_Click;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(970, 634);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(195, 23);
            txtTotal.TabIndex = 27;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(539, 171);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 28;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btn_OrderDetails
            // 
            btn_OrderDetails.BackColor = Color.FromArgb(40, 40, 65);
            btn_OrderDetails.ForeColor = Color.White;
            btn_OrderDetails.Location = new Point(1057, 10);
            btn_OrderDetails.Name = "btn_OrderDetails";
            btn_OrderDetails.Size = new Size(154, 46);
            btn_OrderDetails.TabIndex = 5;
            btn_OrderDetails.Text = "Order Details";
            btn_OrderDetails.UseVisualStyleBackColor = false;
            btn_OrderDetails.Click += btn_OrderDetails_Click;
            // 
            // PointOfSaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(1397, 820);
            Controls.Add(btnSearch);
            Controls.Add(txtTotal);
            Controls.Add(btnProcessOrder);
            Controls.Add(btnRemovefromCart);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(chkIsPaid);
            Controls.Add(dtpOrderDate);
            Controls.Add(txtRemarks);
            Controls.Add(txtNotes);
            Controls.Add(txtCustomerName);
            Controls.Add(dgvCart);
            Controls.Add(btnAddtoCart);
            Controls.Add(numericQuantity);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label12);
            Controls.Add(txtSearchProduct);
            Controls.Add(dgvProducts);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "PointOfSaleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PointOfSaleForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DateTimePicker dtpOrderDate;
        private CheckBox chkIsPaid;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Button btnRemovefromCart;
        private Button btnProcessOrder;
        private TextBox txtTotal;
        private Button btnSearch;
        private Button btn_back;
        private Button btn_OrderDetails;
    }
}