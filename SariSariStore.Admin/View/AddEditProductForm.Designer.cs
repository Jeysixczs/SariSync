namespace SariSariStore.Admin
{
    partial class AddEditProductForm
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
            Btn_UploadImage = new Button();
            NumericStock = new NumericUpDown();
            numericPrice = new NumericUpDown();
            txtboxDescription = new TextBox();
            txtboxProductName = new TextBox();
            cancelButton = new Button();
            saveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            cmbCategory = new ComboBox();
            label3 = new Label();
            lblStatus = new Label();
            panel1 = new Panel();
            dtp_ExpirationDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)NumericStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            SuspendLayout();
            // 
            // Btn_UploadImage
            // 
            Btn_UploadImage.Location = new Point(238, 161);
            Btn_UploadImage.Name = "Btn_UploadImage";
            Btn_UploadImage.Size = new Size(135, 23);
            Btn_UploadImage.TabIndex = 16;
            Btn_UploadImage.Text = "Upload Image";
            Btn_UploadImage.UseVisualStyleBackColor = true;
            Btn_UploadImage.Click += Btn_UploadImage_Click;
            // 
            // NumericStock
            // 
            NumericStock.Location = new Point(152, 467);
            NumericStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericStock.Name = "NumericStock";
            NumericStock.Size = new Size(321, 23);
            NumericStock.TabIndex = 14;
            // 
            // numericPrice
            // 
            numericPrice.Location = new Point(152, 416);
            numericPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(321, 23);
            numericPrice.TabIndex = 13;
            // 
            // txtboxDescription
            // 
            txtboxDescription.Location = new Point(150, 286);
            txtboxDescription.Multiline = true;
            txtboxDescription.Name = "txtboxDescription";
            txtboxDescription.Size = new Size(321, 56);
            txtboxDescription.TabIndex = 12;
            // 
            // txtboxProductName
            // 
            txtboxProductName.Location = new Point(150, 238);
            txtboxProductName.Name = "txtboxProductName";
            txtboxProductName.Size = new Size(321, 23);
            txtboxProductName.TabIndex = 11;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(343, 564);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "CANCEL";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(189, 564);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 9;
            saveButton.Text = "SAVE";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 214);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 18;
            label1.Text = "Product Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 268);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 18;
            label2.Text = "Product Description";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "Snacks", "Drinks", "Toiletries", "Household", "Medicine", "School & Office" });
            cmbCategory.Location = new Point(150, 369);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(321, 23);
            cmbCategory.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 351);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 18;
            label3.Text = "Product Category";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(24, 33);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "label4";
            // 
            // panel1
            // 
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(207, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 133);
            panel1.TabIndex = 21;
            // 
            // dtp_ExpirationDate
            // 
            dtp_ExpirationDate.Location = new Point(154, 523);
            dtp_ExpirationDate.Name = "dtp_ExpirationDate";
            dtp_ExpirationDate.Size = new Size(319, 23);
            dtp_ExpirationDate.TabIndex = 22;
            // 
            // AddEditProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 644);
            Controls.Add(dtp_ExpirationDate);
            Controls.Add(panel1);
            Controls.Add(lblStatus);
            Controls.Add(cmbCategory);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Btn_UploadImage);
            Controls.Add(NumericStock);
            Controls.Add(numericPrice);
            Controls.Add(txtboxDescription);
            Controls.Add(txtboxProductName);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Name = "AddEditProductForm";
            Text = "AddEditProductForm";
            Load += AddEditProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)NumericStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Btn_UploadImage;
        private NumericUpDown NumericStock;
        private NumericUpDown numericPrice;
        private TextBox txtboxDescription;
        private TextBox txtboxProductName;
        private Button cancelButton;
        private Button saveButton;
        private Label label1;
        private Label label2;
        private ComboBox cmbCategory;
        private Label label3;
        private Label lblStatus;
        private Panel panel1;
        private DateTimePicker dtp_ExpirationDate;
    }
}