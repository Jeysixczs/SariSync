namespace SariSariStore.Admin.View
{
    partial class Register
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            errorProvider1 = new ErrorProvider(components);
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(26, 48);
            textBox1.Margin = new Padding(3, 10, 3, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(368, 25);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(26, 118);
            textBox2.Margin = new Padding(3, 10, 3, 10);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(368, 25);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(26, 188);
            textBox3.Margin = new Padding(3, 10, 3, 10);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '•';
            textBox3.Size = new Size(368, 25);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(74, 107, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(26, 270);
            button1.Name = "button1";
            button1.Size = new Size(368, 35);
            button1.TabIndex = 6;
            button1.Text = "Create Account";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(74, 107, 255);
            button2.Location = new Point(26, 320);
            button2.Name = "button2";
            button2.Size = new Size(368, 30);
            button2.TabIndex = 7;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 65);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(40, 140);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(420, 380);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(23, 170);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(23, 100);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 30);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(20, 20, 50);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 120);
            panel2.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(43, 70);
            label5.Name = "label5";
            label5.Size = new Size(206, 15);
            label5.TabIndex = 1;
            label5.Text = "Join us today and get started instantly";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(40, 30);
            label4.Name = "label4";
            label4.Size = new Size(189, 32);
            label4.TabIndex = 0;
            label4.Text = "Create Account";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(500, 550);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Account";
            Load += Register_Load_1;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private ErrorProvider errorProvider1;
        private Panel panel1;
        private Button printReceiptButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Button button3;
        private Label label5;
        private Label label4;
    }
}