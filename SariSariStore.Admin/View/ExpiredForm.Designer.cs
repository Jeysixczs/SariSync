namespace SariSariStore.Admin.View
{
    partial class ExpiredForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            pictureBoxIcon = new PictureBox();
            labelSubtitle = new Label();
            labelTitle = new Label();
            panelStats = new Panel();
            labelCriticalCount = new Label();
            labelCriticalItems = new Label();
            labelTotalCount = new Label();
            labelTotalExpired = new Label();
            panelGridView = new Panel();
            dgv_ExpiredProduct = new DataGridView();
            panelActions = new Panel();
            btn_Critical = new Button();
            btn_Expired = new Button();
            checkBoxMultiSelect = new CheckBox();
            btnDeleteSelected = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            panelStats.SuspendLayout();
            panelGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ExpiredProduct).BeginInit();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(28, 28, 65);
            panelHeader.Controls.Add(pictureBoxIcon);
            panelHeader.Controls.Add(labelSubtitle);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1102, 100);
            panelHeader.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Image = Properties.Resources.icons8_reports_64;
            pictureBoxIcon.Location = new Point(25, 25);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(40, 40);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 2;
            pictureBoxIcon.TabStop = false;
            // 
            // labelSubtitle
            // 
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitle.ForeColor = Color.LightGray;
            labelSubtitle.Location = new Point(73, 65);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(354, 19);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Monitor and manage expired products in your inventory";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(70, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(235, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Expired Products";
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.FromArgb(28, 28, 65);
            panelStats.Controls.Add(labelCriticalCount);
            panelStats.Controls.Add(labelCriticalItems);
            panelStats.Controls.Add(labelTotalCount);
            panelStats.Controls.Add(labelTotalExpired);
            panelStats.Dock = DockStyle.Top;
            panelStats.Location = new Point(0, 100);
            panelStats.Name = "panelStats";
            panelStats.Padding = new Padding(25, 15, 25, 15);
            panelStats.Size = new Size(1102, 80);
            panelStats.TabIndex = 1;
            panelStats.Paint += panelStats_Paint;
            // 
            // labelCriticalCount
            // 
            labelCriticalCount.AutoSize = true;
            labelCriticalCount.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCriticalCount.ForeColor = Color.FromArgb(255, 193, 7);
            labelCriticalCount.Location = new Point(200, 35);
            labelCriticalCount.Name = "labelCriticalCount";
            labelCriticalCount.Size = new Size(26, 30);
            labelCriticalCount.TabIndex = 1;
            labelCriticalCount.Text = "0";
            // 
            // labelCriticalItems
            // 
            labelCriticalItems.AutoSize = true;
            labelCriticalItems.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCriticalItems.ForeColor = Color.LightGray;
            labelCriticalItems.Location = new Point(200, 15);
            labelCriticalItems.Name = "labelCriticalItems";
            labelCriticalItems.Size = new Size(105, 20);
            labelCriticalItems.TabIndex = 0;
            labelCriticalItems.Text = "Critical Items:";
            // 
            // labelTotalCount
            // 
            labelTotalCount.AutoSize = true;
            labelTotalCount.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalCount.ForeColor = Color.FromArgb(220, 53, 69);
            labelTotalCount.Location = new Point(25, 35);
            labelTotalCount.Name = "labelTotalCount";
            labelTotalCount.Size = new Size(26, 30);
            labelTotalCount.TabIndex = 1;
            labelTotalCount.Text = "0";
            // 
            // labelTotalExpired
            // 
            labelTotalExpired.AutoSize = true;
            labelTotalExpired.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalExpired.ForeColor = Color.LightGray;
            labelTotalExpired.Location = new Point(25, 15);
            labelTotalExpired.Name = "labelTotalExpired";
            labelTotalExpired.Size = new Size(104, 20);
            labelTotalExpired.TabIndex = 0;
            labelTotalExpired.Text = "Total Expired:";
            // 
            // panelGridView
            // 
            panelGridView.BackColor = Color.FromArgb(20, 20, 50);
            panelGridView.Controls.Add(dgv_ExpiredProduct);
            panelGridView.Dock = DockStyle.Fill;
            panelGridView.Location = new Point(0, 180);
            panelGridView.Name = "panelGridView";
            panelGridView.Padding = new Padding(25);
            panelGridView.Size = new Size(1102, 470);
            panelGridView.TabIndex = 2;
            panelGridView.Paint += panelGridView_Paint;
            // 
            // dgv_ExpiredProduct
            // 
            dgv_ExpiredProduct.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgv_ExpiredProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_ExpiredProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ExpiredProduct.BackgroundColor = Color.White;
            dgv_ExpiredProduct.BorderStyle = BorderStyle.None;
            dgv_ExpiredProduct.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_ExpiredProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_ExpiredProduct.ColumnHeadersHeight = 40;
            dgv_ExpiredProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(173, 216, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_ExpiredProduct.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_ExpiredProduct.Dock = DockStyle.Fill;
            dgv_ExpiredProduct.EnableHeadersVisualStyles = false;
            dgv_ExpiredProduct.GridColor = Color.LightGray;
            dgv_ExpiredProduct.Location = new Point(25, 25);
            dgv_ExpiredProduct.MultiSelect = false;
            dgv_ExpiredProduct.Name = "dgv_ExpiredProduct";
            dgv_ExpiredProduct.ReadOnly = true;
            dgv_ExpiredProduct.RowHeadersVisible = false;
            dgv_ExpiredProduct.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dgv_ExpiredProduct.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgv_ExpiredProduct.RowTemplate.Height = 35;
            dgv_ExpiredProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ExpiredProduct.Size = new Size(1052, 420);
            dgv_ExpiredProduct.TabIndex = 0;
            dgv_ExpiredProduct.CellClick += dgv_ExpiredProduct_CellClick;
            dgv_ExpiredProduct.CellContentClick += dgv_ExpiredProduct_CellContentClick_1;
            dgv_ExpiredProduct.CellMouseClick += dgv_ExpiredProduct_CellMouseClick;
            dgv_ExpiredProduct.CellMouseDown += dgv_ExpiredProduct_CellMouseDown;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(28, 28, 65);
            panelActions.Controls.Add(btn_Critical);
            panelActions.Controls.Add(btn_Expired);
            panelActions.Controls.Add(checkBoxMultiSelect);
            panelActions.Controls.Add(btnDeleteSelected);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 650);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(25, 10, 25, 10);
            panelActions.Size = new Size(1102, 70);
            panelActions.TabIndex = 3;
            // 
            // btn_Critical
            // 
            btn_Critical.BackColor = Color.FromArgb(255, 193, 7);
            btn_Critical.Cursor = Cursors.Hand;
            btn_Critical.FlatAppearance.BorderSize = 0;
            btn_Critical.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 35, 51);
            btn_Critical.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btn_Critical.FlatStyle = FlatStyle.Flat;
            btn_Critical.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_Critical.ForeColor = Color.White;
            btn_Critical.Location = new Point(459, 20);
            btn_Critical.Name = "btn_Critical";
            btn_Critical.Size = new Size(143, 33);
            btn_Critical.TabIndex = 0;
            btn_Critical.Text = "Critical Items";
            btn_Critical.UseVisualStyleBackColor = false;
            btn_Critical.Click += btn_Critical_Click;
            // 
            // btn_Expired
            // 
            btn_Expired.BackColor = Color.Red;
            btn_Expired.Cursor = Cursors.Hand;
            btn_Expired.FlatAppearance.BorderSize = 0;
            btn_Expired.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 35, 51);
            btn_Expired.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btn_Expired.FlatStyle = FlatStyle.Flat;
            btn_Expired.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_Expired.ForeColor = Color.White;
            btn_Expired.Location = new Point(608, 20);
            btn_Expired.Name = "btn_Expired";
            btn_Expired.Size = new Size(151, 33);
            btn_Expired.TabIndex = 0;
            btn_Expired.Text = "Expired Products";
            btn_Expired.UseVisualStyleBackColor = false;
            btn_Expired.Click += btn_Expired_Click;
            // 
            // checkBoxMultiSelect
            // 
            checkBoxMultiSelect.AutoSize = true;
            checkBoxMultiSelect.ForeColor = Color.White;
            checkBoxMultiSelect.Location = new Point(791, 26);
            checkBoxMultiSelect.Name = "checkBoxMultiSelect";
            checkBoxMultiSelect.Size = new Size(104, 19);
            checkBoxMultiSelect.TabIndex = 1;
            checkBoxMultiSelect.Text = "Multiple Select";
            checkBoxMultiSelect.UseVisualStyleBackColor = true;
            checkBoxMultiSelect.CheckedChanged += checkBoxMultiSelect_CheckedChanged;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.BackColor = Color.FromArgb(220, 53, 69);
            btnDeleteSelected.Cursor = Cursors.Hand;
            btnDeleteSelected.FlatAppearance.BorderSize = 0;
            btnDeleteSelected.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 35, 51);
            btnDeleteSelected.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btnDeleteSelected.FlatStyle = FlatStyle.Flat;
            btnDeleteSelected.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteSelected.ForeColor = Color.White;
            btnDeleteSelected.Location = new Point(910, 13);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(180, 40);
            btnDeleteSelected.TabIndex = 0;
            btnDeleteSelected.Text = "🗑️ Delete Selected";
            btnDeleteSelected.UseVisualStyleBackColor = false;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // ExpiredForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 50);
            ClientSize = new Size(1102, 720);
            Controls.Add(panelGridView);
            Controls.Add(panelStats);
            Controls.Add(panelHeader);
            Controls.Add(panelActions);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExpiredForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Expired Products Management";
            Load += ExpiredForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            panelGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ExpiredProduct).EndInit();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private Panel panelHeader;
        private Panel panelStats;
        private Panel panelGridView;
        private Panel panelActions;
        private Label labelTitle;
        private Label labelSubtitle;
        private Label labelTotalExpired;
        private Label labelTotalCount;
        private Label labelCriticalItems;
        private Label labelCriticalCount;
        private Button btnDeleteSelected;
        private PictureBox pictureBoxIcon;
        private DataGridView dgv_ExpiredProduct;
        private CheckBox checkBoxMultiSelect;
        private Button btn_Expired;
        private Button btn_Critical;
    }
}