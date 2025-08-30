namespace SariSariStore.Admin
{
    partial class HistoryForm
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
            printReceiptButton = new Button();
            dgvOrders = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            cmbYear = new ComboBox();
            cmbMonth = new ComboBox();
            lblOrderCount = new Label();
            dgvMonthlyComparison = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            lblMonthlyIncome = new Label();
            btnFilter = new Button();
            btnCalculateIncome = new Button();
            btnCompareMonths = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyComparison).BeginInit();
            SuspendLayout();
            // 
            // printReceiptButton
            // 
            printReceiptButton.Location = new Point(636, 10);
            printReceiptButton.Name = "printReceiptButton";
            printReceiptButton.Size = new Size(140, 31);
            printReceiptButton.TabIndex = 3;
            printReceiptButton.Text = "Print Receipt";
            printReceiptButton.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvOrders.Location = new Point(11, 173);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(692, 391);
            dgvOrders.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Order ID";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Order Date";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Total Amount";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Status";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Items Count";
            Column5.Name = "Column5";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(12, 12);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(271, 12);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 5;
            // 
            // cmbYear
            // 
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(12, 72);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(121, 23);
            cmbYear.TabIndex = 6;
            // 
            // cmbMonth
            // 
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(183, 72);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(121, 23);
            cmbMonth.TabIndex = 7;
            // 
            // lblOrderCount
            // 
            lblOrderCount.AutoSize = true;
            lblOrderCount.Location = new Point(11, 137);
            lblOrderCount.Name = "lblOrderCount";
            lblOrderCount.Size = new Size(38, 15);
            lblOrderCount.TabIndex = 8;
            lblOrderCount.Text = "label1";
            // 
            // dgvMonthlyComparison
            // 
            dgvMonthlyComparison.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonthlyComparison.Columns.AddRange(new DataGridViewColumn[] { Column6, Column7 });
            dgvMonthlyComparison.Location = new Point(745, 173);
            dgvMonthlyComparison.Name = "dgvMonthlyComparison";
            dgvMonthlyComparison.Size = new Size(242, 392);
            dgvMonthlyComparison.TabIndex = 9;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.HeaderText = "Month";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "Income";
            Column7.Name = "Column7";
            // 
            // lblMonthlyIncome
            // 
            lblMonthlyIncome.AutoSize = true;
            lblMonthlyIncome.Location = new Point(478, 137);
            lblMonthlyIncome.Name = "lblMonthlyIncome";
            lblMonthlyIncome.Size = new Size(38, 15);
            lblMonthlyIncome.TabIndex = 8;
            lblMonthlyIncome.Text = "label1";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(361, 70);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 10;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // btnCalculateIncome
            // 
            btnCalculateIncome.Location = new Point(455, 72);
            btnCalculateIncome.Name = "btnCalculateIncome";
            btnCalculateIncome.Size = new Size(135, 23);
            btnCalculateIncome.TabIndex = 11;
            btnCalculateIncome.Text = "Calculate Income";
            btnCalculateIncome.UseVisualStyleBackColor = true;
            // 
            // btnCompareMonths
            // 
            btnCompareMonths.Location = new Point(397, 591);
            btnCompareMonths.Name = "btnCompareMonths";
            btnCompareMonths.Size = new Size(136, 23);
            btnCompareMonths.TabIndex = 12;
            btnCompareMonths.Text = "Compare Months";
            btnCompareMonths.UseVisualStyleBackColor = true;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 628);
            Controls.Add(btnCompareMonths);
            Controls.Add(btnCalculateIncome);
            Controls.Add(btnFilter);
            Controls.Add(dgvMonthlyComparison);
            Controls.Add(lblMonthlyIncome);
            Controls.Add(lblOrderCount);
            Controls.Add(cmbMonth);
            Controls.Add(cmbYear);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(printReceiptButton);
            Controls.Add(dgvOrders);
            Name = "HistoryForm";
            Text = "HistoryForm";
            Load += HistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyComparison).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button printReceiptButton;
        private DataGridView dgvOrders;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbYear;
        private ComboBox cmbMonth;
        private Label lblOrderCount;
        private DataGridView dgvMonthlyComparison;
        private Label lblMonthlyIncome;
        private Button btnFilter;
        private Button btnCalculateIncome;
        private Button btnCompareMonths;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
    }
}