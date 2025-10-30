namespace SariSariStore.Admin.View
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            panel1 = new Panel();
            Loadingbar = new ProgressBar();
            label7 = new Label();
            printReceiptButton = new Button();
            pictureBox6 = new PictureBox();
            panel2 = new Panel();
            button1 = new Button();
            timer_Loading = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 35, 65);
            panel1.Controls.Add(Loadingbar);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(printReceiptButton);
            panel1.Controls.Add(pictureBox6);
            panel1.Location = new Point(84, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(594, 320);
            panel1.TabIndex = 7;
            // 
            // Loadingbar
            // 
            Loadingbar.BackColor = Color.FromArgb(52, 86, 139);
            Loadingbar.ForeColor = Color.FromArgb(52, 86, 139);
            Loadingbar.Location = new Point(133, 261);
            Loadingbar.Name = "Loadingbar";
            Loadingbar.Size = new Size(317, 10);
            Loadingbar.TabIndex = 13;
            Loadingbar.Click += Loadingbar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Symbol", 20.25F, FontStyle.Bold);
            label7.ForeColor = Color.Transparent;
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(228, 197);
            label7.Name = "label7";
            label7.Size = new Size(123, 37);
            label7.TabIndex = 2;
            label7.Text = "SariSync";
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
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.ImeMode = ImeMode.NoControl;
            pictureBox6.Location = new Point(181, 39);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(221, 155);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 3;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(52, 86, 139);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(-1, 144);
            panel2.Name = "panel2";
            panel2.Size = new Size(851, 164);
            panel2.TabIndex = 14;
            // 
            // button1
            // 
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(1139, 17);
            button1.Name = "button1";
            button1.Size = new Size(140, 31);
            button1.TabIndex = 12;
            button1.Text = "Print Receipt";
            button1.UseVisualStyleBackColor = true;
            // 
            // timer_Loading
            // 
            timer_Loading.Enabled = true;
            timer_Loading.Interval = 50;
            timer_Loading.Tick += timer_Loading_Tick;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(771, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SariSync";
            Load += LoadingForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label7;
        private Button printReceiptButton;
        private PictureBox pictureBox6;
        private ProgressBar Loadingbar;
        private Panel panel2;
        private Button button1;
        private System.Windows.Forms.Timer timer_Loading;
    }
}