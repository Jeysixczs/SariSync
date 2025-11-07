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
            checkBox1 = new CheckBox();
            btn_Delete = new Button();
            btn_Update = new Button();
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
            panelGridView.Controls.Add(checkBox1);
            panelGridView.Controls.Add(btn_Delete);
            panelGridView.Controls.Add(btn_Update);
            panelGridView.Controls.Add(dgv_stock);
            panelGridView.Dock = DockStyle.Fill;
            panelGridView.Location = new Point(0, 140);
            panelGridView.Name = "panelGridView";
            panelGridView.Padding = new Padding(15);
            panelGridView.Size = new Size(600, 603);
            panelGridView.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(376, 561);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Multiple Select";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btn_Delete
            // 
            btn_Delete.ForeColor = Color.Black;
            btn_Delete.Location = new Point(273, 550);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(75, 35);
            btn_Delete.TabIndex = 2;
            btn_Delete.Text = "DELETE";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.BackColor = Color.FromArgb(220, 53, 69); // Bootstrap danger red
            btn_Delete.FlatStyle = FlatStyle.Flat;
            btn_Delete.FlatAppearance.BorderSize = 0;
            btn_Delete.ForeColor = Color.White;
            btn_Delete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_Delete.Size = new Size(90, 35);
            btn_Delete.Location = new Point(273, 550);
            // Hover effects
            btn_Delete.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btn_Delete.Cursor = Cursors.Hand;

            btn_Delete.Click += btn_Delete_Click;
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.FromArgb(13, 110, 253); // Bootstrap primary blue
            btn_Update.FlatStyle = FlatStyle.Flat;
            btn_Update.FlatAppearance.BorderSize = 0;
            btn_Update.ForeColor = Color.White;
            btn_Update.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_Update.Size = new Size(90, 35);
            btn_Update.Location = new Point(158, 550);
            // Hover effects
            btn_Update.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 94, 215);
            btn_Update.Cursor = Cursors.Hand;
            btn_Update.ForeColor = Color.Black;
            btn_Update.Location = new Point(158, 550);
            btn_Update.Name = "btn_Update";
            
            btn_Update.TabIndex = 1;
            btn_Update.Text = "UPDATE";
            btn_Update.UseVisualStyleBackColor = true;
            btn_Update.Click += btn_Update_Click;
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
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(173, 216, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_stock.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_stock.EnableHeadersVisualStyles = false;
            dgv_stock.GridColor = Color.LightGray;
            dgv_stock.Location = new Point(15, 15);
            dgv_stock.MultiSelect = false;
            dgv_stock.Name = "dgv_stock";
            dgv_stock.ReadOnly = true;
            dgv_stock.RowHeadersVisible = false;
            dgv_stock.RowTemplate.Height = 35;
            dgv_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_stock.Size = new Size(570, 508);
            dgv_stock.TabIndex = 0;
            dgv_stock.CellContentClick += dgv_stock_CellContentClick_2;
            dgv_stock.CellMouseClick += dgv_stock_CellMouseClick;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 50);
            ClientSize = new Size(600, 743);
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
            panelGridView.PerformLayout();
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
        private Button btn_Delete;
        private Button btn_Update;
        private CheckBox checkBox1;
    }
}