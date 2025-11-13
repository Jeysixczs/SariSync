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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            label12 = new Label();
            panelOrderInfo = new Panel();
            lblRemarks = new Label();
            label7 = new Label();
            lblNotes = new Label();
            label6 = new Label();
            lblPaymentStatus = new Label();
            label5 = new Label();
            lblTotalAmount = new Label();
            label4 = new Label();
            lblOrderDate = new Label();
            label3 = new Label();
            lblCustomerName = new Label();
            label2 = new Label();
            lblOrderID = new Label();
            label1 = new Label();
            panelOrderItems = new Panel();
            dgvOrderItems = new DataGridView();
            label8 = new Label();
            panelFooter = new Panel();
            printButton = new Button();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            panelOrderInfo.SuspendLayout();
            panelOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(20, 20, 50);
            panelHeader.Controls.Add(label12);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 70);
            panelHeader.TabIndex = 16;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(25, 18);
            label12.Name = "label12";
            label12.Size = new Size(187, 37);
            label12.TabIndex = 12;
            label12.Text = "Order Details";
            // 
            // panelOrderInfo
            // 
            panelOrderInfo.BackColor = Color.FromArgb(20, 20, 50);
            panelOrderInfo.Controls.Add(lblRemarks);
            panelOrderInfo.Controls.Add(label7);
            panelOrderInfo.Controls.Add(lblNotes);
            panelOrderInfo.Controls.Add(label6);
            panelOrderInfo.Controls.Add(lblPaymentStatus);
            panelOrderInfo.Controls.Add(label5);
            panelOrderInfo.Controls.Add(lblTotalAmount);
            panelOrderInfo.Controls.Add(label4);
            panelOrderInfo.Controls.Add(lblOrderDate);
            panelOrderInfo.Controls.Add(label3);
            panelOrderInfo.Controls.Add(lblCustomerName);
            panelOrderInfo.Controls.Add(label2);
            panelOrderInfo.Controls.Add(lblOrderID);
            panelOrderInfo.Controls.Add(label1);
            panelOrderInfo.Location = new Point(25, 90);
            panelOrderInfo.Name = "panelOrderInfo";
            panelOrderInfo.Padding = new Padding(20);
            panelOrderInfo.Size = new Size(750, 250);
            panelOrderInfo.TabIndex = 17;
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRemarks.ForeColor = Color.White;
            lblRemarks.Location = new Point(480, 55);
            lblRemarks.MaximumSize = new Size(250, 0);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(131, 20);
            lblRemarks.TabIndex = 13;
            lblRemarks.Text = "Customer satisfied";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(400, 55);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 13;
            label7.Text = "Remarks:";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNotes.ForeColor = Color.White;
            lblNotes.Location = new Point(480, 25);
            lblNotes.MaximumSize = new Size(250, 0);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(192, 20);
            lblNotes.TabIndex = 13;
            lblNotes.Text = "Special delivery instructions";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(400, 25);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 13;
            label6.Text = "Notes:";
            // 
            // lblPaymentStatus
            // 
            lblPaymentStatus.AutoSize = true;
            lblPaymentStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPaymentStatus.ForeColor = Color.FromArgb(76, 175, 80);
            lblPaymentStatus.Location = new Point(180, 145);
            lblPaymentStatus.Name = "lblPaymentStatus";
            lblPaymentStatus.Size = new Size(39, 20);
            lblPaymentStatus.TabIndex = 13;
            lblPaymentStatus.Text = "Paid";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(25, 145);
            label5.Name = "label5";
            label5.Size = new Size(123, 20);
            label5.TabIndex = 13;
            label5.Text = "Payment Status:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.FromArgb(74, 107, 255);
            lblTotalAmount.Location = new Point(180, 115);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(81, 20);
            lblTotalAmount.TabIndex = 13;
            lblTotalAmount.Text = "₱1,250.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(25, 115);
            label4.Name = "label4";
            label4.Size = new Size(110, 20);
            label4.TabIndex = 13;
            label4.Text = "Total Amount:";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderDate.ForeColor = Color.White;
            lblOrderDate.Location = new Point(180, 85);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(94, 20);
            lblOrderDate.TabIndex = 13;
            lblOrderDate.Text = "Dec 25, 2024";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 85);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 13;
            label3.Text = "Order Date:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.White;
            lblCustomerName.Location = new Point(180, 55);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(71, 20);
            lblCustomerName.TabIndex = 13;
            lblCustomerName.Text = "John Doe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(25, 55);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 13;
            label2.Text = "Customer Name:";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderID.ForeColor = Color.White;
            lblOrderID.Location = new Point(180, 25);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(49, 20);
            lblOrderID.TabIndex = 13;
            lblOrderID.Text = "00001";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 13;
            label1.Text = "Order ID:";
            // 
            // panelOrderItems
            // 
            panelOrderItems.BackColor = Color.FromArgb(20, 20, 50);
            panelOrderItems.Controls.Add(dgvOrderItems);
            panelOrderItems.Controls.Add(label8);
            panelOrderItems.Location = new Point(25, 360);
            panelOrderItems.Name = "panelOrderItems";
            panelOrderItems.Padding = new Padding(20, 10, 20, 20);
            panelOrderItems.Size = new Size(750, 350);
            panelOrderItems.TabIndex = 18;
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.AllowUserToDeleteRows = false;
            dgvOrderItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvOrderItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderItems.BackgroundColor = Color.White;
            dgvOrderItems.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOrderItems.ColumnHeadersHeight = 40;
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(173, 216, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOrderItems.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOrderItems.EnableHeadersVisualStyles = false;
            dgvOrderItems.GridColor = Color.LightGray;
            dgvOrderItems.Location = new Point(20, 50);
            dgvOrderItems.MultiSelect = false;
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.RowHeadersVisible = false;
            dgvOrderItems.RowTemplate.Height = 35;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.Size = new Size(710, 280);
            dgvOrderItems.TabIndex = 0;
            dgvOrderItems.CellContentClick += dgvOrderItems_CellContentClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(20, 15);
            label8.Name = "label8";
            label8.Size = new Size(117, 25);
            label8.TabIndex = 12;
            label8.Text = "Order Items";
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(248, 250, 252);
            panelFooter.Controls.Add(printButton);
            panelFooter.Controls.Add(btnClose);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 730);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(800, 70);
            panelFooter.TabIndex = 19;
            // 
            // printButton
            // 
            printButton.BackColor = Color.FromArgb(76, 175, 80);
            printButton.Cursor = Cursors.Hand;
            printButton.FlatAppearance.BorderSize = 0;
            printButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 160, 73);
            printButton.FlatStyle = FlatStyle.Flat;
            printButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            printButton.ForeColor = Color.White;
            printButton.Location = new Point(491, 15);
            printButton.Name = "printButton";
            printButton.Size = new Size(130, 40);
            printButton.TabIndex = 16;
            printButton.Text = "💾 PRINT";
            printButton.UseVisualStyleBackColor = false;
            printButton.Click += printButton_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 100, 110);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(650, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 40);
            btnClose.TabIndex = 15;
            btnClose.Text = "✕ CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // OrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(800, 800);
            Controls.Add(panelOrderItems);
            Controls.Add(panelOrderInfo);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order Details";
            Load += OrderDetailsForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelOrderInfo.ResumeLayout(false);
            panelOrderInfo.PerformLayout();
            panelOrderItems.ResumeLayout(false);
            panelOrderItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
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
        private Panel panelHeader;
        private Panel panelOrderInfo;
        private Panel panelOrderItems;
        private Panel panelFooter;
        private Button printButton;
    }
}