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
            panelHeader = new Panel();
            labelTitle = new Label();
            panelMain = new Panel();
            panelFormSection = new Panel();
            label7 = new Label();
            numericSellingPrice = new NumericUpDown();
            label6 = new Label();
            dtp_ExpirationDate = new DateTimePicker();
            label5 = new Label();
            NumericStock = new NumericUpDown();
            label4 = new Label();
            numericPrice = new NumericUpDown();
            label3 = new Label();
            cmbCategory = new ComboBox();
            label2 = new Label();
            txtboxDescription = new TextBox();
            label1 = new Label();
            txtboxProductName = new TextBox();
            panelImageSection = new Panel();
            Btn_UploadImage = new Button();
            panel1 = new Panel();
            panelFooter = new Panel();
            cancelButton = new Button();
            saveButton = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelFormSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericSellingPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            panelImageSection.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(28, 28, 65);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(700, 70);
            panelHeader.TabIndex = 0;
            panelHeader.Paint += panelHeader_Paint;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(25, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(159, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Add Product";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(20, 20, 50);
            panelMain.Controls.Add(panelFormSection);
            panelMain.Controls.Add(panelImageSection);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 70);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(25);
            panelMain.Size = new Size(700, 580);
            panelMain.TabIndex = 1;
            // 
            // panelFormSection
            // 
            panelFormSection.BackColor = Color.FromArgb(28, 28, 65);
            panelFormSection.Controls.Add(label7);
            panelFormSection.Controls.Add(numericSellingPrice);
            panelFormSection.Controls.Add(label6);
            panelFormSection.Controls.Add(dtp_ExpirationDate);
            panelFormSection.Controls.Add(label5);
            panelFormSection.Controls.Add(NumericStock);
            panelFormSection.Controls.Add(label4);
            panelFormSection.Controls.Add(numericPrice);
            panelFormSection.Controls.Add(label3);
            panelFormSection.Controls.Add(cmbCategory);
            panelFormSection.Controls.Add(label2);
            panelFormSection.Controls.Add(txtboxDescription);
            panelFormSection.Controls.Add(label1);
            panelFormSection.Controls.Add(txtboxProductName);
            panelFormSection.Location = new Point(290, 25);
            panelFormSection.Name = "panelFormSection";
            panelFormSection.Padding = new Padding(25);
            panelFormSection.Size = new Size(385, 530);
            panelFormSection.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.LightGray;
            label7.Location = new Point(25, 470);
            label7.Name = "label7";
            label7.Size = new Size(92, 19);
            label7.TabIndex = 4;
            label7.Text = "Selling Price";
            // 
            // numericSellingPrice
            // 
            numericSellingPrice.BackColor = Color.FromArgb(40, 40, 80);
            numericSellingPrice.BorderStyle = BorderStyle.FixedSingle;
            numericSellingPrice.Font = new Font("Segoe UI", 10F);
            numericSellingPrice.ForeColor = Color.White;
            numericSellingPrice.Location = new Point(25, 495);
            numericSellingPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericSellingPrice.Name = "numericSellingPrice";
            numericSellingPrice.Size = new Size(335, 25);
            numericSellingPrice.TabIndex = 9;
            numericSellingPrice.ValueChanged += numericSellingPrice_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LightGray;
            label6.Location = new Point(25, 405);
            label6.Name = "label6";
            label6.Size = new Size(112, 19);
            label6.TabIndex = 4;
            label6.Text = "Expiration Date";
            // 
            // dtp_ExpirationDate
            // 
            dtp_ExpirationDate.CalendarForeColor = Color.White;
            dtp_ExpirationDate.CalendarMonthBackground = Color.FromArgb(40, 40, 80);
            dtp_ExpirationDate.CalendarTitleBackColor = Color.FromArgb(74, 107, 255);
            dtp_ExpirationDate.CalendarTitleForeColor = Color.White;
            dtp_ExpirationDate.CalendarTrailingForeColor = Color.FromArgb(100, 100, 120);
            dtp_ExpirationDate.Font = new Font("Segoe UI", 10F);
            dtp_ExpirationDate.Location = new Point(25, 430);
            dtp_ExpirationDate.Name = "dtp_ExpirationDate";
            dtp_ExpirationDate.Size = new Size(335, 25);
            dtp_ExpirationDate.TabIndex = 11;
            dtp_ExpirationDate.ValueChanged += dtp_ExpirationDate_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(25, 340);
            label5.Name = "label5";
            label5.Size = new Size(107, 19);
            label5.TabIndex = 4;
            label5.Text = "Stock Quantity";
            // 
            // NumericStock
            // 
            NumericStock.BackColor = Color.FromArgb(40, 40, 80);
            NumericStock.BorderStyle = BorderStyle.FixedSingle;
            NumericStock.Font = new Font("Segoe UI", 10F);
            NumericStock.ForeColor = Color.White;
            NumericStock.Location = new Point(25, 365);
            NumericStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumericStock.Name = "NumericStock";
            NumericStock.Size = new Size(335, 25);
            NumericStock.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LightGray;
            label4.Location = new Point(25, 275);
            label4.Name = "label4";
            label4.Size = new Size(78, 19);
            label4.TabIndex = 4;
            label4.Text = "Base Price";
            // 
            // numericPrice
            // 
            numericPrice.BackColor = Color.FromArgb(40, 40, 80);
            numericPrice.BorderStyle = BorderStyle.FixedSingle;
            numericPrice.Font = new Font("Segoe UI", 10F);
            numericPrice.ForeColor = Color.White;
            numericPrice.Location = new Point(25, 300);
            numericPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.Size = new Size(335, 25);
            numericPrice.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(25, 210);
            label3.Name = "label3";
            label3.Size = new Size(72, 19);
            label3.TabIndex = 4;
            label3.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(40, 40, 80);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.ForeColor = Color.White;
            cmbCategory.Items.AddRange(new object[] { "" });
            cmbCategory.Location = new Point(25, 235);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(335, 25);
            cmbCategory.TabIndex = 8;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(25, 90);
            label2.Name = "label2";
            label2.Size = new Size(85, 19);
            label2.TabIndex = 3;
            label2.Text = "Description";
            // 
            // txtboxDescription
            // 
            txtboxDescription.BackColor = Color.FromArgb(40, 40, 80);
            txtboxDescription.BorderStyle = BorderStyle.FixedSingle;
            txtboxDescription.Font = new Font("Segoe UI", 10F);
            txtboxDescription.ForeColor = Color.White;
            txtboxDescription.Location = new Point(25, 115);
            txtboxDescription.Multiline = true;
            txtboxDescription.Name = "txtboxDescription";
            txtboxDescription.Size = new Size(335, 80);
            txtboxDescription.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(106, 19);
            label1.TabIndex = 2;
            label1.Text = "Product Name";
            // 
            // txtboxProductName
            // 
            txtboxProductName.BackColor = Color.FromArgb(40, 40, 80);
            txtboxProductName.BorderStyle = BorderStyle.FixedSingle;
            txtboxProductName.Font = new Font("Segoe UI", 10F);
            txtboxProductName.ForeColor = Color.White;
            txtboxProductName.Location = new Point(25, 50);
            txtboxProductName.Name = "txtboxProductName";
            txtboxProductName.Size = new Size(335, 25);
            txtboxProductName.TabIndex = 6;
            // 
            // panelImageSection
            // 
            panelImageSection.BackColor = Color.FromArgb(28, 28, 65);
            panelImageSection.Controls.Add(Btn_UploadImage);
            panelImageSection.Controls.Add(panel1);
            panelImageSection.Location = new Point(25, 25);
            panelImageSection.Name = "panelImageSection";
            panelImageSection.Padding = new Padding(15);
            panelImageSection.Size = new Size(250, 530);
            panelImageSection.TabIndex = 0;
            // 
            // Btn_UploadImage
            // 
            Btn_UploadImage.BackColor = Color.FromArgb(74, 107, 255);
            Btn_UploadImage.Cursor = Cursors.Hand;
            Btn_UploadImage.FlatAppearance.BorderSize = 0;
            Btn_UploadImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 95, 230);
            Btn_UploadImage.FlatStyle = FlatStyle.Flat;
            Btn_UploadImage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Btn_UploadImage.ForeColor = Color.White;
            Btn_UploadImage.Location = new Point(25, 250);
            Btn_UploadImage.Name = "Btn_UploadImage";
            Btn_UploadImage.Size = new Size(200, 40);
            Btn_UploadImage.TabIndex = 1;
            Btn_UploadImage.Text = "📷 Upload Image";
            Btn_UploadImage.UseVisualStyleBackColor = false;
            Btn_UploadImage.Click += Btn_UploadImage_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 40, 80);
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(25, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 200);
            panel1.TabIndex = 0;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(28, 28, 65);
            panelFooter.Controls.Add(cancelButton);
            panelFooter.Controls.Add(saveButton);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 650);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(700, 80);
            panelFooter.TabIndex = 2;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(108, 117, 125);
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 100, 110);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(545, 20);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(130, 40);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "✕ CANCEL";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(76, 175, 80);
            saveButton.Cursor = Cursors.Hand;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 160, 73);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(400, 20);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(130, 40);
            saveButton.TabIndex = 12;
            saveButton.Text = "💾 SAVE";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // AddEditProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 50);
            ClientSize = new Size(700, 730);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add / Edit Product";
            Load += AddEditProductForm_Load_1;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelFormSection.ResumeLayout(false);
            panelFormSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericSellingPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            panelImageSection.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
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
        private Panel panelFooter;
        private Panel panelFormSection;
        private Panel panelImageSection;
        private Panel panelMain;
        private Label labelTitle;
        private Panel panelHeader;
    }
}