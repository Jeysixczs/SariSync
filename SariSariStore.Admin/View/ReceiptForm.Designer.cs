namespace SariSariStore.Admin
{
    partial class ReceiptForm
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
            receiptTextBox = new TextBox();
            btn_PrintButton = new Button();
            btn_Close = new Button();
            panelHeader = new Panel();
            labelTitle = new Label();
            pictureBoxIcon = new PictureBox();
            panelReceipt = new Panel();
            labelReceiptTitle = new Label();
            panelFooter = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            panelReceipt.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // receiptTextBox
            // 
            receiptTextBox.BackColor = Color.White;
            receiptTextBox.BorderStyle = BorderStyle.None;
            receiptTextBox.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            receiptTextBox.ForeColor = Color.FromArgb(64, 64, 64);
            receiptTextBox.Location = new Point(20, 50);
            receiptTextBox.Multiline = true;
            receiptTextBox.Name = "receiptTextBox";
            receiptTextBox.ReadOnly = true;
            receiptTextBox.ScrollBars = ScrollBars.Vertical;
            receiptTextBox.Size = new Size(610, 330);
            receiptTextBox.TabIndex = 3;
            receiptTextBox.TextChanged += receiptTextBox_TextChanged;
            // 
            // btn_PrintButton
            // 
            btn_PrintButton.BackColor = Color.FromArgb(76, 175, 80);
            btn_PrintButton.FlatAppearance.BorderSize = 0;
            btn_PrintButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 160, 73);
            btn_PrintButton.FlatStyle = FlatStyle.Flat;
            btn_PrintButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_PrintButton.ForeColor = Color.White;
            btn_PrintButton.Location = new Point(450, 20);
            btn_PrintButton.Name = "btn_PrintButton";
            btn_PrintButton.Size = new Size(110, 40);
            btn_PrintButton.TabIndex = 2;
            btn_PrintButton.Text = "🖨️ PRINT";
            btn_PrintButton.UseVisualStyleBackColor = false;
            btn_PrintButton.Click += btn_PrintButton_Click;
            // 
            // btn_Close
            // 
            btn_Close.BackColor = Color.FromArgb(108, 117, 125);
            btn_Close.FlatAppearance.BorderSize = 0;
            btn_Close.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 100, 110);
            btn_Close.FlatStyle = FlatStyle.Flat;
            btn_Close.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Close.ForeColor = Color.White;
            btn_Close.Location = new Point(580, 20);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(100, 40);
            btn_Close.TabIndex = 4;
            btn_Close.Text = "✕ CLOSE";
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(20, 20, 50);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(pictureBoxIcon);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(700, 80);
            panelHeader.TabIndex = 5;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(80, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(98, 32);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Receipt";
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Image = Properties.Resources.icons8_bill_64;
            pictureBoxIcon.Location = new Point(25, 20);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(40, 40);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // panelReceipt
            // 
            panelReceipt.BackColor = Color.FromArgb(20, 20, 50);
            panelReceipt.Controls.Add(labelReceiptTitle);
            panelReceipt.Controls.Add(receiptTextBox);
            panelReceipt.Location = new Point(25, 100);
            panelReceipt.Name = "panelReceipt";
            panelReceipt.Padding = new Padding(20);
            panelReceipt.Size = new Size(650, 400);
            panelReceipt.TabIndex = 6;
            // 
            // labelReceiptTitle
            // 
            labelReceiptTitle.AutoSize = true;
            labelReceiptTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReceiptTitle.ForeColor = Color.White;
            labelReceiptTitle.Location = new Point(20, 20);
            labelReceiptTitle.Name = "labelReceiptTitle";
            labelReceiptTitle.Size = new Size(129, 21);
            labelReceiptTitle.TabIndex = 4;
            labelReceiptTitle.Text = "ORDER RECEIPT";
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(20, 20, 50);
            panelFooter.Controls.Add(btn_Close);
            panelFooter.Controls.Add(btn_PrintButton);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 520);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(700, 80);
            panelFooter.TabIndex = 7;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(700, 600);
            Controls.Add(panelReceipt);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipt";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            panelReceipt.ResumeLayout(false);
            panelReceipt.PerformLayout();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private TextBox receiptTextBox;
        private Button btn_PrintButton;
        private Button btn_Close;
        private Panel panelHeader;
        private Panel panelFooter;
        private Label labelTitle;
        private PictureBox pictureBoxIcon;
        private Panel panelReceipt;
        private Label labelReceiptTitle;
    }
}