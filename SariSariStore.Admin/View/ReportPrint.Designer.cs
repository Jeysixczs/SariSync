namespace SariSariStore.Admin.View
{
    partial class ReportPrint
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
            txtbox_ReportPrint = new TextBox();
            btn_PrintPreview = new Button();
            btn_Print = new Button();
            btn_Close = new Button();
            SuspendLayout();
            // 
            // txtbox_ReportPrint
            // 
            txtbox_ReportPrint.Location = new Point(12, 12);
            txtbox_ReportPrint.Multiline = true;
            txtbox_ReportPrint.Name = "txtbox_ReportPrint";
            txtbox_ReportPrint.Size = new Size(566, 441);
            txtbox_ReportPrint.TabIndex = 0;
            // 
            // btn_PrintPreview
            // 
            btn_PrintPreview.BackColor = Color.FromArgb(108, 117, 125);
            btn_PrintPreview.FlatStyle = FlatStyle.Flat;
            btn_PrintPreview.Font = new Font("Segoe UI", 9.75F);
            btn_PrintPreview.ForeColor = Color.White;
            btn_PrintPreview.Location = new Point(102, 483);
            btn_PrintPreview.Name = "btn_PrintPreview";
            btn_PrintPreview.Size = new Size(120, 35);
            btn_PrintPreview.TabIndex = 1;
            btn_PrintPreview.Text = "👁️ Preview";
            btn_PrintPreview.UseVisualStyleBackColor = false;
            btn_PrintPreview.Click += btn_PrintPreview_Click;
            // 
            // btn_Print
            // 
            btn_Print.BackColor = Color.FromArgb(76, 175, 80);
            btn_Print.FlatStyle = FlatStyle.Flat;
            btn_Print.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_Print.ForeColor = Color.White;
            btn_Print.Location = new Point(228, 483);
            btn_Print.Name = "btn_Print";
            btn_Print.Size = new Size(120, 35);
            btn_Print.TabIndex = 2;
            btn_Print.Text = "🖨️ Print";
            btn_Print.UseVisualStyleBackColor = false;
            btn_Print.Click += btn_Print_Click;
            // 
            // btn_Close
            // 
            btn_Close.BackColor = Color.FromArgb(220, 53, 69);
            btn_Close.FlatStyle = FlatStyle.Flat;
            btn_Close.Font = new Font("Segoe UI", 9.75F);
            btn_Close.ForeColor = Color.White;
            btn_Close.Location = new Point(354, 483);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(120, 35);
            btn_Close.TabIndex = 3;
            btn_Close.Text = "❌ Close";
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // ReportPrint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(600, 561);
            Controls.Add(btn_Close);
            Controls.Add(btn_Print);
            Controls.Add(btn_PrintPreview);
            Controls.Add(txtbox_ReportPrint);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ReportPrint";
            Text = "ReportPrint";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbox_ReportPrint;
        private Button btn_PrintPreview;
        private Button btn_Print;
        private Button btn_Close;
    }
}