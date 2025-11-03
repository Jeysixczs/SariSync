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
            dataGridView1 = new DataGridView();
            panelActions = new Panel();
            btnRefresh = new Button();
            btnExport = new Button();
            btnDeleteSelected = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            panelStats.SuspendLayout();
            panelGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            panelHeader.Size = new Size(900, 100);
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
            panelStats.Size = new Size(900, 80);
            panelStats.TabIndex = 1;
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
            panelGridView.Controls.Add(dataGridView1);
            panelGridView.Dock = DockStyle.Fill;
            panelGridView.Location = new Point(0, 180);
            panelGridView.Name = "panelGridView";
            panelGridView.Padding = new Padding(25);
            panelGridView.Size = new Size(900, 470);
            panelGridView.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.GridColor = Color.LightGray;


            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219); // Blue header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230); // Light blue
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
            dataGridView1.RowTemplate.Height = 35;


            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);



            dataGridView1.Location = new Point(25, 25);
            
            dataGridView1.Size = new Size(850, 420);
           
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(28, 28, 65);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Controls.Add(btnExport);
            panelActions.Controls.Add(btnDeleteSelected);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 650);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(25, 10, 25, 10);
            panelActions.Size = new Size(900, 70);
            panelActions.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(74, 107, 255);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseDownBackColor = Color.FromArgb(65, 95, 230);
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 95, 230);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(695, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(180, 40);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Refresh Data";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(108, 117, 125);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatAppearance.MouseDownBackColor = Color.FromArgb(90, 100, 110);
            btnExport.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 100, 110);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(220, 15);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(150, 40);
            btnExport.TabIndex = 1;
            btnExport.Text = "📤 Export Report";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
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
            btnDeleteSelected.Location = new Point(25, 15);
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
            ClientSize = new Size(900, 720);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
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
        private Button btnExport;
        private Button btnRefresh;
        private PictureBox pictureBoxIcon;
    }
}