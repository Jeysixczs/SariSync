namespace SariSariStore.Admin.View
{
    partial class NotificationForm
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
            dgv_stock = new DataGridView();
            btn_lowstock = new Button();
            btn_mediumstock = new Button();
            btn_highstock = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_stock).BeginInit();
            SuspendLayout();
            // 
            // dgv_stock
            // 
            dgv_stock.AllowUserToAddRows = false;
            dgv_stock.AllowUserToDeleteRows = false;
            dgv_stock.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgv_stock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_stock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_stock.BackgroundColor = Color.White;
            dgv_stock.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_stock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_stock.ColumnHeadersHeight = 40;
            dgv_stock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(173, 216, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_stock.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_stock.EnableHeadersVisualStyles = false;
            dgv_stock.GridColor = Color.LightGray;
            dgv_stock.Location = new Point(12, 52);
            dgv_stock.MultiSelect = false;
            dgv_stock.Name = "dgv_stock";
            dgv_stock.ReadOnly = true;
            dgv_stock.RowHeadersVisible = false;
            dgv_stock.RowTemplate.Height = 35;
            dgv_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_stock.Size = new Size(493, 611);
            dgv_stock.TabIndex = 0;
            // 
            // btn_lowstock
            // 
            btn_lowstock.BackColor = Color.WhiteSmoke;
            btn_lowstock.Cursor = Cursors.Hand;
            btn_lowstock.FlatAppearance.BorderSize = 0;
            btn_lowstock.FlatAppearance.MouseDownBackColor = Color.LightGray;
            btn_lowstock.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            btn_lowstock.FlatStyle = FlatStyle.Flat;
            btn_lowstock.Font = new Font("Segoe UI", 10F);
            btn_lowstock.ForeColor = Color.Black;
            btn_lowstock.Location = new Point(20, 8);
            btn_lowstock.Name = "btn_lowstock";
            btn_lowstock.Size = new Size(130, 35);
            btn_lowstock.TabIndex = 1;
            btn_lowstock.Text = "Low Stock";
            btn_lowstock.UseVisualStyleBackColor = false;
            btn_lowstock.Click += btn_lowstock_Click;
            // 
            // btn_mediumstock
            // 
            btn_mediumstock.BackColor = Color.WhiteSmoke;
            btn_mediumstock.Cursor = Cursors.Hand;
            btn_mediumstock.FlatAppearance.BorderSize = 0;
            btn_mediumstock.FlatAppearance.MouseDownBackColor = Color.LightGray;
            btn_mediumstock.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            btn_mediumstock.FlatStyle = FlatStyle.Flat;
            btn_mediumstock.Font = new Font("Segoe UI", 10F);
            btn_mediumstock.ForeColor = Color.Black;
            btn_mediumstock.Location = new Point(191, 8);
            btn_mediumstock.Name = "btn_mediumstock";
            btn_mediumstock.Size = new Size(130, 35);
            btn_mediumstock.TabIndex = 2;
            btn_mediumstock.Text = "Medium Stock";
            btn_mediumstock.UseVisualStyleBackColor = false;
            btn_mediumstock.Click += btn_mediumstock_Click;
            // 
            // btn_highstock
            // 
            btn_highstock.BackColor = Color.WhiteSmoke;
            btn_highstock.Cursor = Cursors.Hand;
            btn_highstock.FlatAppearance.BorderSize = 0;
            btn_highstock.FlatAppearance.MouseDownBackColor = Color.LightGray;
            btn_highstock.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            btn_highstock.FlatStyle = FlatStyle.Flat;
            btn_highstock.Font = new Font("Segoe UI", 10F);
            btn_highstock.ForeColor = Color.Black;
            btn_highstock.Location = new Point(356, 8);
            btn_highstock.Name = "btn_highstock";
            btn_highstock.Size = new Size(130, 35);
            btn_highstock.TabIndex = 3;
            btn_highstock.Text = "High Stock";
            btn_highstock.UseVisualStyleBackColor = false;
            btn_highstock.Click += btn_highstock_Click;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(517, 675);
            Controls.Add(btn_highstock);
            Controls.Add(btn_mediumstock);
            Controls.Add(btn_lowstock);
            Controls.Add(dgv_stock);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NotificationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock Status";
            Load += NotificationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_stock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_stock;
        private Button btn_lowstock;
        private Button btn_mediumstock;
        private Button btn_highstock;
    }
}