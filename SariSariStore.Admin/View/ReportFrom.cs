using Microsoft.Data.SqlClient;
using SariSariStore.Admin.Model;
using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public ReportFrom()
        {
            InitializeComponent();

            rounded = new Rounded();
            rounded.MakePanelRounded(panel1, 30);
            rounded.MakePanelRounded(panel2, 30);
            rounded.MakePanelRounded(panel3, 30);
            rounded.MakePanelRounded(panel4, 30);

            LoadReport();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }


        private void btn_Products_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
            this.Hide();
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.Show();
            this.Hide();
        }

        private void btn_History_Click(object sender, EventArgs e)
        {
            HistoryF historyF = new HistoryF();
            historyF.Show();
            this.Hide();
        }

        private void dgv_salereport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_report_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadReport()
        {

            dgv_report.DataSource = salesReports.DisplayReport();


        }

        private void btn_Report_Click(object sender, EventArgs e)
        {

        }

        private void dgv_report_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReportFrom_Load(object sender, EventArgs e)
        {

        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ReportFrom_Resize(object sender, EventArgs e)
        {
            Invalidate();
            this.Region = rounded.RoundForm(cornerRadius, this.Width, this.Height);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

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
            DateTime specific = dateTimePicker1.Value.Date;

            DateRangeReportProperties getspecificdate = new DateRangeReportProperties();
            dgv_report.DataSource = getspecificdate.DisplaySpecificDateOrder(specific);
            dgv_report.Columns["OrderDate"].DefaultCellStyle.Format = "MMM dd yyyy";
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (dgv_report.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Get the current report data and type
                string reportType = GetCurrentReportType();
                DateTime? startDate = null;
                DateTime? endDate = null;
                DateTime? specificDate = null;

                // Determine what type of report is being viewed
                if (btn_Entery.Focused || btn_Entery.ContainsFocus)
                {
                    startDate = dtpStartDate.Value.Date;
                    endDate = dtpEndDate.Value.Date;
                }
                else if (btn_SpecificOrder.Focused || btn_SpecificOrder.ContainsFocus)
                {
                    specificDate = dateTimePicker1.Value.Date;
                }

                // Get the data from DataGridView with proper column detection
                var reportData = GetReportDataFromGrid();
                decimal totalSales = CalculateTotalSales(reportData);
                int totalOrders = CalculateTotalOrders(reportData);

                // Open print form
                ReportPrint printForm = new ReportPrint(reportType, reportData, totalSales, totalOrders, startDate, endDate, specificDate);
                printForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing print: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Dictionary<string, object>> GetReportDataFromGrid()
        {
            var reportData = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow row in dgv_report.Rows)
            {
                if (!row.IsNewRow) // Removed row.Visible check to include all rows
                {
                    var rowData = new Dictionary<string, object>();
                    foreach (DataGridViewColumn column in dgv_report.Columns)
                    {
                        if (column.Visible && row.Cells[column.Index].Value != null)
                        {
                            rowData[column.HeaderText] = row.Cells[column.Index].Value;
                        }
                        else if (column.Visible)
                        {
                            rowData[column.HeaderText] = "-"; // Provide default for null values
                        }
                    }
                    reportData.Add(rowData);
                }
            }

            return reportData;
        }

        private decimal CalculateTotalSales(List<Dictionary<string, object>> reportData)
        {
            decimal total = 0;

            foreach (var row in reportData)
            {
                // Try different possible column names for total amount
                string[] possibleAmountColumns = { "TotalRevenue", "TotalAmount", "Amount", "Total", "Revenue" };

                foreach (string columnName in possibleAmountColumns)
                {
                    if (row.ContainsKey(columnName) && row[columnName] != null)
                    {
                        if (decimal.TryParse(row[columnName].ToString(), out decimal amount))
                        {
                            total += amount;
                            break;
                        }
                    }
                }
            }

            return total;
        }

        private int CalculateTotalOrders(List<Dictionary<string, object>> reportData)
        {
            // Count unique orders or use NumberOrder column if available
            int totalOrders = reportData.Count;

            // If there's a NumberOrder column, we might want to sum it instead
            foreach (var row in reportData)
            {
                if (row.ContainsKey("NumberOrder") && row["NumberOrder"] != null)
                {
                    if (int.TryParse(row["NumberOrder"].ToString(), out int orderCount))
                    {
                        // This depends on your business logic - summing or counting?
                        // For now, we'll just count rows
                    }
                }
            }

            return totalOrders;
        }

        private string GetCurrentReportType()
        {
            if (btn_dailyReports.Focused || btn_dailyReports.ContainsFocus)
                return "Daily Sales Report";
            else if (btn_MonthlyReports.Focused || btn_MonthlyReports.ContainsFocus)
                return "Monthly Sales Report";
            else if (btn_Entery.Focused || btn_Entery.ContainsFocus)
                return $"Date Range Report ({dtpStartDate.Value:MMM dd, yyyy} to {dtpEndDate.Value:MMM dd, yyyy})";
            else if (btn_SpecificOrder.Focused || btn_SpecificOrder.ContainsFocus)
                return $"Specific Date Report ({dateTimePicker1.Value:MMM dd, yyyy})";
            else
                return "Complete Sales Report";
        }
    }
}

