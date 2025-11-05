namespace SariSariStore.Admin.View
{
    partial class AddEditSupplierForm
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
            components = new System.ComponentModel.Container();
            cancelButton = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtboxContactPerson = new TextBox();
            label1 = new Label();
            txtboxSupplierName = new TextBox();
            labelTitle = new Label();
            panelHeader = new Panel();
            panelFooter = new Panel();
            saveButton = new Button();
            panelMain = new Panel();
            panelFormSection = new Panel();
            txtAddress = new TextBox();
            txtboxContactNumber = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            panelMain.SuspendLayout();
            panelFormSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
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
            cancelButton.Location = new Point(376, 12);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(130, 40);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "✕ CANCEL";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LightGray;
            label4.Location = new Point(37, 217);
            label4.Name = "label4";
            label4.Size = new Size(63, 19);
            label4.TabIndex = 4;
            label4.Text = "Address";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(37, 155);
            label3.Name = "label3";
            label3.Size = new Size(119, 19);
            label3.TabIndex = 4;
            label3.Text = "Contact Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(31, 85);
            label2.Name = "label2";
            label2.Size = new Size(110, 19);
            label2.TabIndex = 3;
            label2.Text = "Contact Person";
            // 
            // txtboxContactPerson
            // 
            txtboxContactPerson.BackColor = Color.FromArgb(40, 40, 80);
            txtboxContactPerson.BorderStyle = BorderStyle.FixedSingle;
            txtboxContactPerson.Font = new Font("Segoe UI", 10F);
            txtboxContactPerson.ForeColor = Color.White;
            txtboxContactPerson.Location = new Point(25, 115);
            txtboxContactPerson.Name = "txtboxContactPerson";
            txtboxContactPerson.Size = new Size(335, 25);
            txtboxContactPerson.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(31, 20);
            label1.Name = "label1";
            label1.Size = new Size(109, 19);
            label1.TabIndex = 2;
            label1.Text = "Supplier Name";
            // 
            // txtboxSupplierName
            // 
            txtboxSupplierName.BackColor = Color.FromArgb(40, 40, 80);
            txtboxSupplierName.BorderStyle = BorderStyle.FixedSingle;
            txtboxSupplierName.Font = new Font("Segoe UI", 10F);
            txtboxSupplierName.ForeColor = Color.White;
            txtboxSupplierName.Location = new Point(25, 50);
            txtboxSupplierName.Name = "txtboxSupplierName";
            txtboxSupplierName.Size = new Size(335, 25);
            txtboxSupplierName.TabIndex = 6;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(25, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(163, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Add Supplier";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(28, 28, 65);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(564, 70);
            panelHeader.TabIndex = 3;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(28, 28, 65);
            panelFooter.Controls.Add(cancelButton);
            panelFooter.Controls.Add(saveButton);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 449);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(564, 80);
            panelFooter.TabIndex = 5;
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
            saveButton.Location = new Point(228, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(130, 40);
            saveButton.TabIndex = 12;
            saveButton.Text = "💾 SAVE";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(20, 20, 50);
            panelMain.Controls.Add(panelFormSection);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(25);
            panelMain.Size = new Size(564, 529);
            panelMain.TabIndex = 4;
            panelMain.Paint += panelMain_Paint;
            // 
            // panelFormSection
            // 
            panelFormSection.BackColor = Color.FromArgb(28, 28, 65);
            panelFormSection.Controls.Add(txtAddress);
            panelFormSection.Controls.Add(txtboxContactNumber);
            panelFormSection.Controls.Add(label4);
            panelFormSection.Controls.Add(label3);
            panelFormSection.Controls.Add(label2);
            panelFormSection.Controls.Add(txtboxContactPerson);
            panelFormSection.Controls.Add(label1);
            panelFormSection.Controls.Add(txtboxSupplierName);
            panelFormSection.Location = new Point(91, 76);
            panelFormSection.Name = "panelFormSection";
            panelFormSection.Padding = new Padding(25);
            panelFormSection.Size = new Size(389, 353);
            panelFormSection.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.FromArgb(40, 40, 80);
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.ForeColor = Color.White;
            txtAddress.Location = new Point(27, 253);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(335, 58);
            txtAddress.TabIndex = 13;
            // 
            // txtboxContactNumber
            // 
            txtboxContactNumber.BackColor = Color.FromArgb(40, 40, 80);
            txtboxContactNumber.BorderStyle = BorderStyle.FixedSingle;
            txtboxContactNumber.Font = new Font("Segoe UI", 10F);
            txtboxContactNumber.ForeColor = Color.White;
            txtboxContactNumber.Location = new Point(25, 177);
            txtboxContactNumber.Name = "txtboxContactNumber";
            txtboxContactNumber.Size = new Size(335, 25);
            txtboxContactNumber.TabIndex = 12;
            txtboxContactNumber.TextChanged += txtboxContactNumber_TextChanged;
            txtboxContactNumber.KeyPress += txtboxContactNumber_KeyPress;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AddEditSupplierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 529);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Controls.Add(panelMain);
            Name = "AddEditSupplierForm";
            Text = "AddEditSupplierForm";
            Load += AddEditSupplierForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelFormSection.ResumeLayout(false);
            panelFormSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button cancelButton;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtboxContactPerson;
        private Label label1;
        private TextBox txtboxSupplierName;
        private Label labelTitle;
        private Panel panelHeader;
        private Panel panelFooter;
        private Button saveButton;
        private Panel panelMain;
        private Panel panelFormSection;
        private TextBox txtAddress;
        private TextBox txtboxContactNumber;
        private ErrorProvider errorProvider1;
    }
}