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
            panel1 = new Panel();
            dtp_ExpirationDate = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel2 = new Panel();
            numericSellingPrice = new NumericUpDown();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)NumericStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericSellingPrice).BeginInit();
            SuspendLayout();
            // 
            // Btn_UploadImage
            // 
            Btn_UploadImage.BackColor = Color.FromArgb(52, 86, 139);
            Btn_UploadImage.Cursor = Cursors.Hand;
            Btn_UploadImage.FlatAppearance.BorderSize = 0;
            Btn_UploadImage.FlatStyle = FlatStyle.Flat;
            Btn_UploadImage.ForeColor = Color.White;
            Btn_UploadImage.Location = new Point(240, 160);
            Btn_UploadImage.Name = "Btn_UploadImage";
            Btn_UploadImage.Size = new Size(160, 32);
            Btn_UploadImage.TabIndex = 1;
            Btn_UploadImage.Text = "Upload Image";
            Btn_UploadImage.UseVisualStyleBackColor = false;
            Btn_UploadImage.Click += Btn_UploadImage_Click;
            // 
            // NumericStock
            // 
            NumericStock.BackColor = Color.FromArgb(50, 65, 85);
            NumericStock.BorderStyle = BorderStyle.FixedSingle;
            NumericStock.ForeColor = Color.White;
            NumericStock.Location = new Point(91, 577);
            NumericStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericStock.Name = "NumericStock";
            NumericStock.Size = new Size(330, 25);
            NumericStock.TabIndex = 10;
            // 
            // numericPrice
            // 
            numericPrice.BackColor = Color.FromArgb(50, 65, 85);
            numericPrice.BorderStyle = BorderStyle.FixedSingle;
            numericPrice.ForeColor = Color.White;
            numericPrice.Location = new Point(160, 455);
            numericPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(330, 25);
            numericPrice.TabIndex = 9;
            // 
            // txtboxDescription
            // 
            txtboxDescription.BackColor = Color.FromArgb(50, 65, 85);
            txtboxDescription.BorderStyle = BorderStyle.FixedSingle;
            txtboxDescription.ForeColor = Color.White;
            txtboxDescription.Location = new Point(159, 301);
            txtboxDescription.Multiline = true;
            txtboxDescription.Name = "txtboxDescription";
            txtboxDescription.Size = new Size(330, 60);
            txtboxDescription.TabIndex = 7;
            // 
            // txtboxProductName
            // 
            txtboxProductName.BackColor = Color.FromArgb(50, 65, 85);
            txtboxProductName.BorderStyle = BorderStyle.FixedSingle;
            txtboxProductName.ForeColor = Color.White;
            txtboxProductName.Location = new Point(160, 236);
            txtboxProductName.Name = "txtboxProductName";
            txtboxProductName.Size = new Size(330, 25);
            txtboxProductName.TabIndex = 6;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(70, 80, 100);
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(277, 674);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(120, 36);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(52, 86, 139);
            saveButton.Cursor = Cursors.Hand;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(110, 674);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(120, 36);
            saveButton.TabIndex = 12;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(35, 35, 65);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(155, 210);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 2;
            label1.Text = "Product Name";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(35, 35, 65);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(154, 275);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 3;
            label2.Text = "Description";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(50, 65, 85);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.ForeColor = Color.White;
            cmbCategory.Items.AddRange(new object[] { "Snacks", "Drinks", "Toiletries", "Household", "Medicine", "School & Office" });
            cmbCategory.Location = new Point(159, 392);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(330, 25);
            cmbCategory.TabIndex = 8;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(35, 35, 65);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(155, 366);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Category";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 60, 80);
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(220, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 130);
            panel1.TabIndex = 0;
            // 
            // dtp_ExpirationDate
            // 
            dtp_ExpirationDate.CalendarForeColor = Color.FromArgb(20, 20, 50);
            dtp_ExpirationDate.CalendarMonthBackground = Color.FromArgb(50, 65, 85);
            dtp_ExpirationDate.CalendarTitleBackColor = Color.FromArgb(52, 86, 139);
            dtp_ExpirationDate.CalendarTitleForeColor = Color.FromArgb(20, 20, 50);
            dtp_ExpirationDate.CalendarTrailingForeColor = Color.FromArgb(50, 65, 85);
            dtp_ExpirationDate.Location = new Point(91, 631);
            dtp_ExpirationDate.Name = "dtp_ExpirationDate";
            dtp_ExpirationDate.Size = new Size(330, 25);
            dtp_ExpirationDate.TabIndex = 11;
            dtp_ExpirationDate.ValueChanged += dtp_ExpirationDate_ValueChanged;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(35, 35, 65);
            label4.ForeColor = Color.LightGray;
            label4.Location = new Point(156, 429);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 4;
            label4.Text = "Price";
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(35, 35, 65);
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(87, 551);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 4;
            label5.Text = "Quantity";
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(35, 35, 65);
            label6.ForeColor = Color.LightGray;
            label6.Location = new Point(87, 605);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 4;
            label6.Text = "Date Expired";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(35, 35, 65);
            panel2.Controls.Add(cancelButton);
            panel2.Controls.Add(saveButton);
            panel2.Controls.Add(dtp_ExpirationDate);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(NumericStock);
            panel2.Controls.Add(numericSellingPrice);
            panel2.Location = new Point(69, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(509, 740);
            panel2.TabIndex = 14;
            // 
            // numericSellingPrice
            // 
            numericSellingPrice.BackColor = Color.FromArgb(50, 65, 85);
            numericSellingPrice.BorderStyle = BorderStyle.FixedSingle;
            numericSellingPrice.ForeColor = Color.White;
            numericSellingPrice.Location = new Point(91, 513);
            numericSellingPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericSellingPrice.Name = "numericSellingPrice";
            numericSellingPrice.Size = new Size(330, 25);
            numericSellingPrice.TabIndex = 9;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(35, 35, 65);
            label7.ForeColor = Color.LightGray;
            label7.Location = new Point(87, 487);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 4;
            label7.Text = "Selling Price";
            // 
            // AddEditProductForm
            // 
            BackColor = Color.FromArgb(20, 20, 50);
            ClientSize = new Size(640, 772);
            Controls.Add(panel1);
            Controls.Add(Btn_UploadImage);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtboxProductName);
            Controls.Add(txtboxDescription);
            Controls.Add(cmbCategory);
            Controls.Add(numericPrice);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddEditProductForm";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add / Edit Product";
            Load += AddEditProductForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)NumericStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericSellingPrice).EndInit();
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
        private Panel panel1;
        private DateTimePicker dtp_ExpirationDate;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel2;
        private Label label7;
        private NumericUpDown numericSellingPrice;
    }
}