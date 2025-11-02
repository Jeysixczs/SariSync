namespace SariSariStore.Admin.View
{
    partial class OrderDetailsForm
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
            label12 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dgvOrderItems = new DataGridView();
            btnClose = new Button();
            lblOrderID = new Label();
            lblCustomerName = new Label();
            lblOrderDate = new Label();
            lblTotalAmount = new Label();
            lblPaymentStatus = new Label();
            lblNotes = new Label();
            lblRemarks = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Transparent;
            label12.Location = new Point(12, 9);
            label12.Name = "label12";
            label12.Size = new Size(187, 25);
            label12.TabIndex = 12;
            label12.Text = "Order Information:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(48, 56);
            label1.Name = "label1";
            label1.Size = new Size(82, 21);
            label1.TabIndex = 13;
            label1.Text = "Order ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(48, 90);
            label2.Name = "label2";
            label2.Size = new Size(141, 21);
            label2.TabIndex = 13;
            label2.Text = "Customer Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(48, 123);
            label3.Name = "label3";
            label3.Size = new Size(101, 21);
            label3.TabIndex = 13;
            label3.Text = "Order Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(48, 157);
            label4.Name = "label4";
            label4.Size = new Size(120, 21);
            label4.TabIndex = 13;
            label4.Text = "Total Amount:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Transparent;
            label5.Location = new Point(48, 191);
            label5.Name = "label5";
            label5.Size = new Size(136, 21);
            label5.TabIndex = 13;
            label5.Text = "Payment Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(48, 226);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 13;
            label6.Text = "Notes:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(48, 264);
            label7.Name = "label7";
            label7.Size = new Size(82, 21);
            label7.TabIndex = 13;
            label7.Text = "Remarks:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Transparent;
            label8.Location = new Point(12, 333);
            label8.Name = "label8";
            label8.Size = new Size(144, 25);
            label8.TabIndex = 12;
            label8.Text = "ORDER ITEMS:";
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.BackgroundColor = Color.White;
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(12, 372);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.Size = new Size(640, 384);
            dgvOrderItems.TabIndex = 14;
            dgvOrderItems.SelectionChanged += dgvOrderItems_SelectionChanged;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(290, 777);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(79, 27);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderID.ForeColor = Color.Transparent;
            lblOrderID.Location = new Point(229, 57);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(56, 20);
            lblOrderID.TabIndex = 13;
            lblOrderID.Text = "Lorem";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.Transparent;
            lblCustomerName.Location = new Point(229, 90);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(56, 20);
            lblCustomerName.TabIndex = 13;
            lblCustomerName.Text = "Lorem";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderDate.ForeColor = Color.Transparent;
            lblOrderDate.Location = new Point(229, 123);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(56, 20);
            lblOrderDate.TabIndex = 13;
            lblOrderDate.Text = "Lorem";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.Transparent;
            lblTotalAmount.Location = new Point(229, 157);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(56, 20);
            lblTotalAmount.TabIndex = 13;
            lblTotalAmount.Text = "Lorem";
            // 
            // lblPaymentStatus
            // 
            lblPaymentStatus.AutoSize = true;
            lblPaymentStatus.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPaymentStatus.ForeColor = Color.Transparent;
            lblPaymentStatus.Location = new Point(229, 191);
            lblPaymentStatus.Name = "lblPaymentStatus";
            lblPaymentStatus.Size = new Size(56, 20);
            lblPaymentStatus.TabIndex = 13;
            lblPaymentStatus.Text = "Lorem";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotes.ForeColor = Color.Transparent;
            lblNotes.Location = new Point(229, 226);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(56, 20);
            lblNotes.TabIndex = 13;
            lblNotes.Text = "Lorem";
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRemarks.ForeColor = Color.Transparent;
            lblRemarks.Location = new Point(229, 264);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(56, 20);
            lblRemarks.TabIndex = 13;
            lblRemarks.Text = "Lorem";
            // 
            // OrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(664, 825);
            Controls.Add(btnClose);
            Controls.Add(dgvOrderItems);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblRemarks);
            Controls.Add(lblNotes);
            Controls.Add(lblPaymentStatus);
            Controls.Add(lblTotalAmount);
            Controls.Add(lblOrderDate);
            Controls.Add(lblCustomerName);
            Controls.Add(lblOrderID);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label12);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "OrderDetailsForm";
            Text = "Order Details";
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label12;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DataGridView dgvOrderItems;
        private Button btnClose;
        private Label lblOrderID;
        private Label lblCustomerName;
        private Label lblOrderDate;
        private Label lblTotalAmount;
        private Label lblPaymentStatus;
        private Label lblNotes;
        private Label lblRemarks;
    }
}