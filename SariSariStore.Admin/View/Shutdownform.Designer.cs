namespace SariSariStore.Admin.View
{
    partial class Shutdownform
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
            lblTitle = new Label();
            progressBar = new ProgressBar();
            lblLoading = new Label();
            lblProgress = new Label();
            circularProgress = new Label();
            timer = new System.Windows.Forms.Timer(components);
            coundowntimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(475, 314);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Shutting Down...";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.FromArgb(62, 62, 66);
            progressBar.ForeColor = Color.FromArgb(0, 122, 204);
            progressBar.Location = new Point(475, 384);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(400, 20);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 1;
            // 
            // lblLoading
            // 
            lblLoading.Font = new Font("Segoe UI", 10F);
            lblLoading.ForeColor = Color.LightGray;
            lblLoading.Location = new Point(475, 414);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(400, 25);
            lblLoading.TabIndex = 2;
            lblLoading.Text = "Please wait while the system shuts down";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProgress
            // 
            lblProgress.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProgress.ForeColor = Color.White;
            lblProgress.Location = new Point(625, 354);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(100, 25);
            lblProgress.TabIndex = 3;
            lblProgress.Text = "0%";
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // circularProgress
            // 
            circularProgress.Font = new Font("Arial", 24F);
            circularProgress.ForeColor = Color.FromArgb(0, 122, 204);
            circularProgress.Location = new Point(650, 444);
            circularProgress.Name = "circularProgress";
            circularProgress.Size = new Size(50, 50);
            circularProgress.TabIndex = 4;
            circularProgress.Text = "●";
            circularProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 50;
            timer.Tick += timer_Tick;
            // 
            // coundowntimer
            // 
            coundowntimer.Enabled = true;
            coundowntimer.Interval = 350;
            coundowntimer.Tick += coundowntimer_Tick;
            // 
            // Shutdownform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(1397, 820);
            Controls.Add(lblTitle);
            Controls.Add(progressBar);
            Controls.Add(lblLoading);
            Controls.Add(lblProgress);
            Controls.Add(circularProgress);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Shutdownform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shutdown";
            Load += Shutdownform_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private ProgressBar progressBar;
        private Label lblLoading;
        private Label lblProgress;
        private Label circularProgress;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer coundowntimer;
    }
}