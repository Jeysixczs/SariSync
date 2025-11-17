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
            btn_Print.Enabled = false;
            btn_Print.Visible = false;
        }

        private void btn_MonthlyReports_Click(object sender, EventArgs e)
        {
            MonthlySalesReportProperties monthlySalesReportProperties = new MonthlySalesReportProperties();
            dgv_report.DataSource = monthlySalesReportProperties.DisplayReportMonthly();
            btn_Print.Enabled = false;
            btn_Print.Visible = false;
        }

        private void btn_perform_Click(object sender, EventArgs e)
        {
            LoadReport();
            btn_Print.Enabled = true;
            btn_Print.Visible = true;

        }

        private void btn_SpecificOrder_Click(object sender, EventArgs e)
        {
            DateTime specific = dtp_SpecifiDate.Value.Date;

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
                // To get the current report data and type
                string reportType = GetCurrentReportType();
                DateTime? startDate = null;
                DateTime? endDate = null;
                DateTime? specificDate = null;

                if (btn_Entery.Focused || btn_Entery.ContainsFocus)
                {
                    startDate = dtpStartDate.Value.Date;
                    endDate = dtpEndDate.Value.Date;
                }
                else if (btn_SpecificOrder.Focused || btn_SpecificOrder.ContainsFocus)
                {
                    specificDate = dtp_SpecifiDate.Value.Date;
                }

                // Get the data from DataGridView with proper column detection
                var reportData = GetReportDataFromGrid();
                decimal totalSales = CalculateTotalSales(reportData);
                int totalOrders = CalculateTotalOrders(reportData);


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
                if (!row.IsNewRow)
                {
                    var rowData = new Dictionary<string, object>();

                    foreach (DataGridViewColumn column in dgv_report.Columns)
                    {
                        if (column.Visible && row.Cells[column.Index].Value != null)
                        {
                            string headerText = column.HeaderText;
                            object cellValue = row.Cells[column.Index].Value;

                            // Map to standardized column names for printing
                            string standardizedKey = StandardizeColumnName(headerText);
                            rowData[standardizedKey] = cellValue;

                            // Also keep the original header for flexibility
                            rowData[headerText] = cellValue;
                        }
                    }

                    reportData.Add(rowData);
                }
            }

            return reportData;
        }

        private string StandardizeColumnName(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
                return columnName;

            string lowerName = columnName.ToLower();

            return lowerName switch
            {
                "productid" or "id" or "product id" => "ProductID",
                "productname" or "name" or "product name" => "ProductName",
                "category" => "Category",
                "totalquantitysold" or "quantity" or "qty" or "total quantity" => "TotalQuantitySold",
                "unitprice" or "price" or "unit price" => "UnitPrice",
                "totalrevenue" or "revenue" or "total" or "total revenue" => "TotalRevenue",
                "numberorder" or "orders" or "order count" or "numoforder" or "numberoforders" => "NumberOrder",
                "orderdate" or "date" => "OrderDate",
                "customername" or "customer" or "customer name" => "CustomerName",
                "ordertotal" or "total amount" or "order total" => "OrderTotal",
                "orderid" => "OrderID",
                _ => columnName
            };
        }

        private decimal CalculateTotalSales(List<Dictionary<string, object>> reportData)
        {
            decimal total = 0;

            // For DateRangeReportProperties, we need to sum OrderTotal but only count each order once
            if (reportData.Count > 0 && reportData[0].ContainsKey("OrderTotal"))
            {
                var distinctOrders = reportData
                    .Where(row => row.ContainsKey("OrderID") && row["OrderID"] != null)
                    .Select(row => new { OrderID = row["OrderID"].ToString(), OrderTotal = row["OrderTotal"] })
                    .DistinctBy(x => x.OrderID);

                foreach (var order in distinctOrders)
                {
                    if (decimal.TryParse(order.OrderTotal.ToString(), out decimal orderTotal))
                    {
                        total += orderTotal;
                    }
                }
                return total;
            }

            // For other report types, use the original logic
            foreach (var row in reportData)
            {
                string[] possibleAmountColumns = {
            "TotalRevenue", "Revenue", "Total", "TotalAmount",
            "OrderTotal", "DailySales", "MonthlySales", "Amount"
        };

                foreach (string columnName in possibleAmountColumns)
                {
                    if (row.ContainsKey(columnName) && row[columnName] != null)
                    {
                        string value = row[columnName].ToString();
                        if (decimal.TryParse(value, out decimal amount))
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

            int totalOrders = 0;

            // For DateRangeReportProperties, count distinct orders
            if (reportData.Count > 0 && reportData[0].ContainsKey("OrderID"))
            {
                var distinctOrders = reportData
                    .Where(row => row.ContainsKey("OrderID") && row["OrderID"] != null)
                    .Select(row => row["OrderID"].ToString())
                    .Distinct()
                    .Count();
                return distinctOrders;
            }

            // For other report types, sum the order counts
            foreach (var row in reportData)
            {
                string[] possibleOrderColumns = { "NumberOrder", "Numoforder", "NumberOfOrders", "Orders", "TotalOrders", "Numoforderdaily" };

                foreach (string columnName in possibleOrderColumns)
                {
                    if (row.ContainsKey(columnName) && row[columnName] != null)
                    {
                        string orderValue = row[columnName].ToString();
                        if (int.TryParse(orderValue, out int orderCount))
                        {
                            totalOrders += orderCount;
                            break;
                        }
                    }
                }
            }

            // If no valid order counts found, return the number of records
            return totalOrders > 0 ? totalOrders : reportData.Count;
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
                return $"Specific Date Report ({dtp_SpecifiDate.Value:MMM dd, yyyy})";
            else
                return "Complete Sales Report";
        }

    }
}

