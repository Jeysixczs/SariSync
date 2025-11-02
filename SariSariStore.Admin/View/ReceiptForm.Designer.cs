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
            SuspendLayout();
            // 
            // receiptTextBox
            // 
            receiptTextBox.Location = new Point(98, 29);
            receiptTextBox.Multiline = true;
            receiptTextBox.Name = "receiptTextBox";
            receiptTextBox.Size = new Size(473, 340);
            receiptTextBox.TabIndex = 3;
            // 
            // btn_PrintButton
            // 
            btn_PrintButton.BackColor = Color.FromArgb(40, 40, 65);
            btn_PrintButton.ForeColor = Color.White;
            btn_PrintButton.Location = new Point(365, 390);
            btn_PrintButton.Name = "btn_PrintButton";
            btn_PrintButton.Size = new Size(75, 33);
            btn_PrintButton.TabIndex = 2;
            btn_PrintButton.Text = "PRINT";
            btn_PrintButton.UseVisualStyleBackColor = false;
            btn_PrintButton.Click += btn_PrintButton_Click;
            // 
            // btn_Close
            // 
            btn_Close.BackColor = Color.FromArgb(40, 40, 65);
            btn_Close.ForeColor = Color.White;
            btn_Close.Location = new Point(225, 390);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(75, 33);
            btn_Close.TabIndex = 4;
            btn_Close.Text = "CLOSE";
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(698, 450);
            Controls.Add(btn_Close);
            Controls.Add(receiptTextBox);
            Controls.Add(btn_PrintButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ReceiptForm";
            Text = "ReceiptForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox receiptTextBox;
        private Button btn_PrintButton;
        private Button btn_Close;
    }
}