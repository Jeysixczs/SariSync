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
            panel1 = new Panel();
            button2 = new Button();
            label5 = new Label();
            checkBoxShowPassword = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(50, 154);
            textBox2.Margin = new Padding(3, 10, 3, 10);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 25);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(50, 224);
            textBox3.Margin = new Padding(3, 10, 3, 10);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '•';
            textBox3.Size = new Size(280, 25);
            textBox3.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(74, 107, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(50, 319);
            button1.Name = "button1";
            button1.Size = new Size(280, 35);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(28, 28, 65);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(checkBoxShowPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(350, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 500);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(136, 384);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(28, 28, 65);
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(125, 50);
            label5.Name = "label5";
            label5.Size = new Size(145, 45);
            label5.TabIndex = 0;
            label5.Text = "SariSync";
            label5.Click += label5_Click;
            // 
            // checkBoxShowPassword
            // 
            checkBoxShowPassword.AutoSize = true;
            checkBoxShowPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxShowPassword.ForeColor = Color.White;
            checkBoxShowPassword.Location = new Point(50, 264);
            checkBoxShowPassword.Name = "checkBoxShowPassword";
            checkBoxShowPassword.Size = new Size(108, 19);
            checkBoxShowPassword.TabIndex = 3;
            checkBoxShowPassword.Text = "Show password";
            checkBoxShowPassword.UseVisualStyleBackColor = true;
            checkBoxShowPassword.CheckedChanged += checkBoxShowPassword_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(28, 28, 65);
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(47, 199);
            label2.Name = "label2";
            label2.Size = new Size(67, 19);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(28, 28, 65);
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(47, 129);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 50);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 500);
            panel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(50, 330);
            label4.Name = "label4";
            label4.Size = new Size(218, 42);
            label4.TabIndex = 2;
            label4.Text = "Sign in to access your account\r\nand continue your work";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(50, 80);
            label3.Name = "label3";
            label3.Size = new Size(212, 37);
            label3.TabIndex = 1;
            label3.Text = "Welcome Back!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_store_64;
            pictureBox1.Location = new Point(100, 150);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(750, 500);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login to System";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Panel panel1;
        private Button printReceiptButton;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Button button3;
        private Label label5;
        private Label label4;
        private Label label3;
        private CheckBox checkBoxShowPassword;
        private PictureBox pictureBox1;
        private Button button2;
    }
}