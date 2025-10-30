namespace SariSariStore.Admin.View
{
    partial class LoginForm
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
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            printReceiptButton = new Button();
            panel2 = new Panel();
            button3 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(210, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(176, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(210, 133);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(176, 23);
            textBox3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(210, 226);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(311, 226);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 65);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(printReceiptButton);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox3);
            panel1.Location = new Point(-51, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(594, 320);
            panel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(210, 109);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 13;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(210, 52);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 13;
            label1.Text = "Username";
            // 
            // printReceiptButton
            // 
            printReceiptButton.ImeMode = ImeMode.NoControl;
            printReceiptButton.Location = new Point(1139, 17);
            printReceiptButton.Name = "printReceiptButton";
            printReceiptButton.Size = new Size(140, 31);
            printReceiptButton.TabIndex = 12;
            printReceiptButton.Text = "Print Receipt";
            printReceiptButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(52, 86, 139);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(95, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 508);
            panel2.TabIndex = 15;
            // 
            // button3
            // 
            button3.ImeMode = ImeMode.NoControl;
            button3.Location = new Point(1139, 17);
            button3.Name = "button3";
            button3.Size = new Size(140, 31);
            button3.TabIndex = 12;
            button3.Text = "Print Receipt";
            button3.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(492, 505);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Button printReceiptButton;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Button button3;
    }
}