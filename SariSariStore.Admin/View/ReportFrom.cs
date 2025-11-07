using Microsoft.Data.SqlClient;
using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SariSariStore.Core.Model.SalesReport;


namespace SariSariStore.Admin.View
{
    public partial class ReportFrom : Form
    {
        private Rounded rounded;
        public int cornerRadius = 30;

        // public Expenses exp = new Expenses();
        public string ConnectionString = ConnectionHelper.GetConnectionString();
        public SalesReport salesReports = new SalesReport();

        private SmoothTransition transition;
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public ReportFrom()
        {
            InitializeComponent();

            rounded = new Rounded();
            transition = new SmoothTransition();

            EnableDoubleBuffering();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw, true);

            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetWindowLong(this.Handle, -20, GetWindowLong(this.Handle, -20) | 0x02000000);
            }
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            rounded.MakePanelRounded(panel4, 30);

            LoadReport();
        }

        private void EnableDoubleBuffering()
        {
            this.DoubleBuffered = true;

        }
        private void OnFormReturn(Form parentForm)
        {
            parentForm.Opacity = 0;
            parentForm.Visible = true;
            transition.FastFadeIn(parentForm, 60);
            parentForm.BringToFront();
            parentForm.Focus();
        }


        private async void btn_Dashboard_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new DashboardForm(), OnFormReturn);
        }


        private async void btn_Products_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new ProductForm(), OnFormReturn);
        }

        private async void btn_Inventory_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new InventoryForm(), OnFormReturn);
        }

        private async void btn_History_Click(object sender, EventArgs e)
        {
            await transition.ShowFormSafely(this, new HistoryF(), OnFormReturn);
        }

        public void LoadReport()
        {
            dgv_report.DataSource = salesReports.DisplayReport();
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SmoothTransition smoothTransition = new SmoothTransition();
                Shutdownform shutdownForm = new Shutdownform(smoothTransition);

               
                this.Hide();

               
                shutdownForm.Show();

            }
        }

        private void ReportFrom_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }

        private void btn_Entery_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Start Date cannot be later than End Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DateRangeReportProperties dateRangeReportProperties = new DateRangeReportProperties();
            dgv_report.DataSource = dateRangeReportProperties.GetSalesReportsByDateRange(startDate, endDate);
            dgv_report.Columns["OrderDate"].DefaultCellStyle.Format = "MMM dd yyyy";
        }

        private void btn_dailyReports_Click(object sender, EventArgs e)
        {
            DailySalesReportProperties dailySalesReportProperties = new DailySalesReportProperties();
            dgv_report.DataSource = dailySalesReportProperties.DisplayReportDaily();
        }

        private void btn_MonthlyReports_Click(object sender, EventArgs e)
        {
            MonthlySalesReportProperties monthlySalesReportProperties = new MonthlySalesReportProperties();
            dgv_report.DataSource = monthlySalesReportProperties.DisplayReportMonthly();
        }

        private void btn_perform_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btn_SpecificOrder_Click(object sender, EventArgs e)
        {
            DateTime specific = dtp_SpecifiDate.Value.Date;

            DateRangeReportProperties getspecificdate = new DateRangeReportProperties();
            dgv_report.DataSource = getspecificdate.DisplaySpecificDateOrder(specific);
            dgv_report.Columns["OrderDate"].DefaultCellStyle.Format = "MMM dd yyyy";
        }
    }
}

