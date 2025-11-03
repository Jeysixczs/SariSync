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
            panelHeader = new Panel();
            labelSubtitle = new Label();
            labelTitle = new Label();
            panelFilterButtons = new Panel();
            btn_highstock = new Button();
            btn_mediumstock = new Button();
            btn_lowstock = new Button();
            panelGridView = new Panel();
            dgv_stock = new DataGridView();
            panelHeader.SuspendLayout();
            panelFilterButtons.SuspendLayout();
            panelGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_stock).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(28, 28, 65);
            panelHeader.Controls.Add(labelSubtitle);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(600, 80);
            panelHeader.TabIndex = 4;
            // 
            // labelSubtitle
            // 
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitle.ForeColor = Color.LightGray;
            labelSubtitle.Location = new Point(23, 50);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(250, 15);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Monitor your inventory levels and stock status";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(20, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(151, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Stock Status";
            // 
            // panelFilterButtons
            // 
            panelFilterButtons.BackColor = Color.FromArgb(28, 28, 65);
            panelFilterButtons.Controls.Add(btn_highstock);
            panelFilterButtons.Controls.Add(btn_mediumstock);
            panelFilterButtons.Controls.Add(btn_lowstock);
            panelFilterButtons.Dock = DockStyle.Top;
            panelFilterButtons.Location = new Point(0, 80);
            panelFilterButtons.Name = "panelFilterButtons";
            panelFilterButtons.Padding = new Padding(15, 10, 15, 10);
            panelFilterButtons.Size = new Size(600, 60);
            panelFilterButtons.TabIndex = 5;
            // 
            // btn_highstock
            // 
            btn_highstock.BackColor = Color.FromArgb(40, 167, 69);
            btn_highstock.Cursor = Cursors.Hand;
            btn_highstock.Dock = DockStyle.Left;
            btn_highstock.FlatAppearance.BorderSize = 0;
            btn_highstock.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 136, 56);
            btn_highstock.FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 136, 56);
            btn_highstock.FlatStyle = FlatStyle.Flat;
            btn_highstock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_highstock.ForeColor = Color.White;
            btn_highstock.Location = new Point(396, 10);
            btn_highstock.Margin = new Padding(0, 0, 10, 0);
            btn_highstock.Name = "btn_highstock";
            btn_highstock.Size = new Size(184, 40);
            btn_highstock.TabIndex = 3;
            btn_highstock.Text = "\U0001f7e2 High Stock";
            btn_highstock.UseVisualStyleBackColor = false;
            btn_highstock.Click += btn_highstock_Click;
            // 
            // btn_mediumstock
            // 
            btn_mediumstock.BackColor = Color.FromArgb(255, 193, 7);
            btn_mediumstock.Cursor = Cursors.Hand;
            btn_mediumstock.Dock = DockStyle.Left;
            btn_mediumstock.FlatAppearance.BorderSize = 0;
            btn_mediumstock.FlatAppearance.MouseDownBackColor = Color.FromArgb(230, 173, 0);
            btn_mediumstock.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 173, 0);
            btn_mediumstock.FlatStyle = FlatStyle.Flat;
            btn_mediumstock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_mediumstock.ForeColor = Color.FromArgb(64, 64, 64);
            btn_mediumstock.Location = new Point(204, 10);
            btn_mediumstock.Margin = new Padding(0, 0, 10, 0);
            btn_mediumstock.Name = "btn_mediumstock";
            btn_mediumstock.Size = new Size(192, 40);
            btn_mediumstock.TabIndex = 2;
            btn_mediumstock.Text = "\U0001f7e1 Medium Stock";
            btn_mediumstock.UseVisualStyleBackColor = false;
            btn_mediumstock.Click += btn_mediumstock_Click;
            // 
            // btn_lowstock
            // 
            btn_lowstock.BackColor = Color.FromArgb(220, 53, 69);
            btn_lowstock.Cursor = Cursors.Hand;
            btn_lowstock.Dock = DockStyle.Left;
            btn_lowstock.FlatAppearance.BorderSize = 0;
            btn_lowstock.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 35, 51);
            btn_lowstock.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btn_lowstock.FlatStyle = FlatStyle.Flat;
            btn_lowstock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_lowstock.ForeColor = Color.White;
            btn_lowstock.Location = new Point(15, 10);
            btn_lowstock.Margin = new Padding(0, 0, 10, 0);
            btn_lowstock.Name = "btn_lowstock";
            btn_lowstock.Size = new Size(189, 40);
            btn_lowstock.TabIndex = 1;
            btn_lowstock.Text = "🔴 Low Stock";
            btn_lowstock.UseVisualStyleBackColor = false;
            btn_lowstock.Click += btn_lowstock_Click;
            // 
            // panelGridView
            // 
            panelGridView.BackColor = Color.FromArgb(20, 20, 50);
            panelGridView.Controls.Add(dgv_stock);
            panelGridView.Dock = DockStyle.Fill;
            panelGridView.Location = new Point(0, 140);
            panelGridView.Name = "panelGridView";
            panelGridView.Padding = new Padding(15);
            panelGridView.Size = new Size(600, 535);
            panelGridView.TabIndex = 6;
            // 
            // dgv_stock
            // 
            dgv_stock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_stock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_stock.ColumnHeadersHeight = 40;
            dgv_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_stock.MultiSelect = false;
            dgv_stock.ReadOnly = true;
            dgv_stock.AllowUserToAddRows = false;
            dgv_stock.AllowUserToDeleteRows = false;
            dgv_stock.AllowUserToResizeRows = false;
            dgv_stock.RowHeadersVisible = false;
            dgv_stock.BorderStyle = BorderStyle.None;
            dgv_stock.BackgroundColor = Color.White;
            dgv_stock.GridColor = Color.LightGray;


            dgv_stock.EnableHeadersVisualStyles = false;
            dgv_stock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219); // Blue header
            dgv_stock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_stock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv_stock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgv_stock.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv_stock.DefaultCellStyle.ForeColor = Color.Black;
            dgv_stock.DefaultCellStyle.BackColor = Color.White;
            dgv_stock.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230); // Light blue
            dgv_stock.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_stock.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
            dgv_stock.RowTemplate.Height = 35;


            dgv_stock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);


            dgv_stock.Location = new Point(15, 15);
            
            dgv_stock.Size = new Size(570, 505);
            
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 50);
            ClientSize = new Size(600, 675);
            Controls.Add(panelGridView);
            Controls.Add(panelFilterButtons);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NotificationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock Status Monitor";
            Load += NotificationForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilterButtons.ResumeLayout(false);
            panelGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_stock).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DataGridView dgv_stock;
        private Button btn_lowstock;
        private Button btn_mediumstock;
        private Button btn_highstock;
        private Panel panelHeader;
        private Panel panelFilterButtons;
        private Panel panelGridView;
        private Label labelTitle;
        private Label labelSubtitle;
    }
}