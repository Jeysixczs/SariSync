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
            btn_Print = new Button();
            btn_Close = new Button();
            btn_PrintPreview = new Button();
            SuspendLayout();
            // 
            // txtbox_ReportPrint
            // 
            txtbox_ReportPrint.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtbox_ReportPrint.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_ReportPrint.Location = new Point(12, 12);
            txtbox_ReportPrint.Multiline = true;
            txtbox_ReportPrint.Name = "txtbox_ReportPrint";
            txtbox_ReportPrint.ReadOnly = true;
            txtbox_ReportPrint.Size = new Size(760, 400);
            txtbox_ReportPrint.TabIndex = 0;
            // 
            // btn_Print
            // 
            btn_Print.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Print.BackColor = Color.FromArgb(0, 123, 255);
            btn_Print.FlatStyle = FlatStyle.Flat;
            btn_Print.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Print.ForeColor = Color.White;
            btn_Print.Location = new Point(532, 418);
            btn_Print.Name = "btn_Print";
            btn_Print.Size = new Size(120, 35);
            btn_Print.TabIndex = 1;
            btn_Print.Text = "🖨️ Print";
            btn_Print.UseVisualStyleBackColor = false;
            btn_Print.Click += btn_Print_Click;
            // 
            // btn_Close
            // 
            btn_Close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Close.BackColor = Color.FromArgb(220, 53, 69);
            btn_Close.FlatStyle = FlatStyle.Flat;
            btn_Close.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Close.ForeColor = Color.White;
            btn_Close.Location = new Point(658, 418);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(120, 35);
            btn_Close.TabIndex = 3;
            btn_Close.Text = "❌ Close";
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // btn_PrintPreview
            // 
            btn_PrintPreview.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_PrintPreview.BackColor = Color.FromArgb(108, 117, 125);
            btn_PrintPreview.FlatStyle = FlatStyle.Flat;
            btn_PrintPreview.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_PrintPreview.ForeColor = Color.White;
            btn_PrintPreview.Location = new Point(406, 418);
            btn_PrintPreview.Name = "btn_PrintPreview";
            btn_PrintPreview.Size = new Size(120, 35);
            btn_PrintPreview.TabIndex = 2;
            btn_PrintPreview.Text = "👁️ Preview";
            btn_PrintPreview.UseVisualStyleBackColor = false;
            btn_PrintPreview.Click += btn_PrintPreview_Click;
            // 
            // ReportPrint
            // 
            BackColor = Color.FromArgb(28, 28, 65);
            ClientSize = new Size(784, 461);
            Controls.Add(btn_PrintPreview);
            Controls.Add(btn_Close);
            Controls.Add(btn_Print);
            Controls.Add(txtbox_ReportPrint);
            ForeColor = Color.FromArgb(28, 28, 65);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "ReportPrint";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Print Report - SariSync";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbox_ReportPrint;
        private Button btn_Print;
        private Button btn_Close;
        private Button btn_PrintPreview;

        


    }
}