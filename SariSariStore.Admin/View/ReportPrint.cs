using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SariSariStore.Admin.View
{
    public partial class ReportPrint : Form
    {
        private string _reportType;
        private List<Dictionary<string, object>> _reportData;
        private decimal _totalSales;
        private int totalOrders;
        private DateTime? startDate;
        private DateTime? endDate;
        private DateTime? specificDate;

        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private PrintDialog printDialog;
        private int currentPage = 0;
        private List<List<Dictionary<string, object>>> _pages = new List<List<Dictionary<string, object>>>();
        private int _rowsPerPage = 35; 

        public ReportPrint(string reportType, List<Dictionary<string, object>> reportData,
                         decimal totalSales, int totalOrders, DateTime? startDate = null,
                         DateTime? endDate = null, DateTime? specificDate = null)
        {
            InitializeComponent();
            _reportType = reportType;
            _reportData = reportData;
            _totalSales = totalSales;
            this.totalOrders = totalOrders;
            this.startDate = startDate;
            this.endDate = endDate;
            this.specificDate = specificDate;

            InitializePrintComponents();
            GenerateReportText();
            PreparePages();
        }

        private void InitializePrintComponents()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            printDocument.BeginPrint += new PrintEventHandler(PrintDocument_BeginPrint);
            printDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.Text = "Print Preview - SariSync Report";

            printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;
        }

        private void PreparePages()
        {
            _pages.Clear();

            if (_reportData.Count == 0)
                return;

            _rowsPerPage = 25; // Reduced from 35 to 25 to fit more content per page

            // Split data into pages
            for (int i = 0; i < _reportData.Count; i += _rowsPerPage)
            {
                var pageData = _reportData.Skip(i).Take(_rowsPerPage).ToList();
                _pages.Add(pageData);
            }
        }

        private void GenerateReportText()
        {
            StringBuilder sb = new StringBuilder();

            // Header
            sb.AppendLine("SARI-SARI STORE");
            sb.AppendLine("SALES REPORT");
            sb.AppendLine("====================");
            sb.AppendLine();

            // Report Information
            //sb.AppendLine($"Report: {_reportType}");

            // Handle both "Date Range" and "Data Range" typos
            if ((_reportType.Contains("Specific Date") || _reportType.Contains("specific date")) && specificDate.HasValue)
            {
                // For specific date reports
                sb.AppendLine($"Report Date: {specificDate.Value:MMM dd, yyyy}");
            }
            else if ((_reportType.Contains("Date Range") || _reportType.Contains("Data Range") || _reportType.Contains("date range")) && startDate.HasValue && endDate.HasValue)
            {
                // For date range reports
                sb.AppendLine($"Report Period: {startDate.Value:MMM dd, yyyy} to {endDate.Value:MMM dd, yyyy}");
            }
            // In GenerateReportText method:
            else if (_reportType == "Complete Sales Report" || _reportType.Contains("Complete Sales"))
            {
                // For complete sales report - no specific date, show all-time data
                sb.AppendLine("Report Period: All Time");
            }
            else
            {
                // Fallback for other report types
                sb.AppendLine($"Report Date: {DateTime.Now:MMM dd, yyyy}");
            }

            sb.AppendLine($"Report Generated: {DateTime.Now:MMM dd, yyyy hh:mm tt}");
            sb.AppendLine();

            // Rest of the method remains the same...
            // Summary Section
            sb.AppendLine("SUMMARY");
            sb.AppendLine($"Total Records: {_reportData.Count}");
            sb.AppendLine($"Total Sales: {_totalSales:C2}");

            if (totalOrders > 0)
            {
                sb.AppendLine($"Total Orders: {totalOrders}");
            }

            sb.AppendLine();

            // Detailed Data Section
            if (_reportData.Count > 0)
            {
                sb.AppendLine("DETAILED SALES DATA");
                sb.AppendLine();

                // Simple text representation
                foreach (var row in _reportData)
                {
                    string productId = GetCellValue(row, "ProductID");
                    string productName = GetCellValue(row, "ProductName");
                    string category = GetCellValue(row, "Category");
                    string quantity = GetCellValue(row, "TotalQuantitySold");
                    string unitPrice = FormatNumericValue(GetCellValue(row, "UnitPrice"), true);
                    string revenue = FormatNumericValue(GetCellValue(row, "TotalRevenue"), true);
                    string orders = GetCellValue(row, "NumberOrder");

                    sb.AppendLine($"{productId,-5} {Truncate(productName, 15),-15} {Truncate(category, 12),-12} {quantity,-4} {unitPrice,-10} {revenue,-12} {orders,-6}");
                }
            }
            else
            {
                sb.AppendLine("No transaction data available for the selected period.");
            }

            // Footer
            sb.AppendLine();
            sb.AppendLine("--- End of Report ---");

            txtbox_ReportPrint.Text = sb.ToString();
            txtbox_ReportPrint.SelectionStart = 0;
            txtbox_ReportPrint.ScrollToCaret();
        }

        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font normalFont = new Font("Arial", 9);
            Font smallFont = new Font("Arial", 8);
            Font dataFont = new Font("Arial", 8);

            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            float centerX = e.MarginBounds.Left + (e.MarginBounds.Width / 2);

            try
            {
                // Store Title
                graphics.DrawString("SARI-SARI STORE", titleFont, Brushes.Black, centerX - 80, yPos);
                yPos += 25;
                graphics.DrawString("SALES REPORT", headerFont, Brushes.Black, centerX - 40, yPos);
                yPos += 30;

                // Report Information
                graphics.DrawString($"Report: {_reportType}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;

                //Handle both "Date Range" and "Data Range" typos
                if ((_reportType.Contains("Specific Date") || _reportType.Contains("specific date")) && specificDate.HasValue)
                {
                    // For specific date reports
                    graphics.DrawString($"Report Date: {specificDate.Value:MMM dd, yyyy}", normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }
                else if ((_reportType.Contains("Date Range") || _reportType.Contains("Data Range") || _reportType.Contains("date range")) && startDate.HasValue && endDate.HasValue)
                {
                    // For date range reports
                    graphics.DrawString($"Report Period: {startDate.Value:MMM dd, yyyy} to {endDate.Value:MMM dd, yyyy}", normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }
                else if (_reportType == "Complete Sales Report" || _reportType.Contains("Complete Sales"))
                {
                    // For complete sales report - no specific date, show all-time data
                    graphics.DrawString("Report Period: All Time", normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }
                else
                {
                    // Fallback for other report types
                    graphics.DrawString($"Report Date: {DateTime.Now:MMM dd, yyyy}", normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }

                graphics.DrawString($"Report Generated: {DateTime.Now:MMM dd, yyyy hh:mm tt}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                
                // Summary Section
                graphics.DrawString("SUMMARY", headerFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                graphics.DrawString($"Total Records: {_reportData.Count}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 12;
                graphics.DrawString($"Total Sales: {_totalSales:C2}", headerFont, Brushes.Black, leftMargin, yPos);

                // Add total orders for DateRange reports
                if (_reportType.Contains("Date Range") || _reportType.Contains("Data Range") || _reportType.Contains("Specific Date"))
                {
                    yPos += 12;
                    graphics.DrawString($"Total Orders: {totalOrders}", headerFont, Brushes.Black, leftMargin, yPos);
                }

                yPos += 20;

                // Check what type of data we have and print accordingly
                if (_reportData.Count > 0 && currentPage < _pages.Count)
                {
                    // Detect if this is DateRangeReportProperties data
                    bool isDateRangeReport = _reportData[0].ContainsKey("OrderDate") ||
                                           _reportData[0].ContainsKey("CustomerName") ||
                                           _reportData[0].ContainsKey("OrderTotal");

                    if (isDateRangeReport)
                    {
                        PrintDateRangeReport(graphics, e, ref yPos, leftMargin, centerX, smallFont, dataFont, normalFont);
                    }
                    else
                    {
                        PrintSalesSummaryReport(graphics, e, ref yPos, leftMargin, centerX, smallFont, dataFont, normalFont);
                    }
                }
                else
                {
                    graphics.DrawString("No transaction data available.", normalFont, Brushes.Black, leftMargin, yPos);
                    e.HasMorePages = false;
                }
            }
            catch (Exception ex)
            {
                graphics.DrawString($"Print Error: {ex.Message}", normalFont, Brushes.Red, leftMargin, yPos);
                e.HasMorePages = false;
            }
        }

        private void PrintDateRangeReport(Graphics graphics, PrintPageEventArgs e, ref float yPos, float leftMargin, float centerX, Font smallFont, Font dataFont, Font normalFont)
        {
            graphics.DrawString("DETAILED ORDER DATA", smallFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            // Define column widths for DateRange report - matching your desired headers
            float[] columnWidths = { 70, 100, 80, 90, 70, 70, 40 }; 
            string[] headers = { "Order Date", "ProductName", "Category", "CustomerName", "UnitPrice", "OrderTotal", "Qty" };

            // Print headers
            float xPos = leftMargin;
            for (int i = 0; i < headers.Length; i++)
            {
                graphics.DrawString(headers[i], smallFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[i];
            }
            yPos += 15;

            // Draw line under headers
            graphics.DrawLine(Pens.Black, leftMargin, yPos, xPos, yPos);
            yPos += 8;

            // Get current page data
            var currentPageData = _pages[currentPage];

            // Print data rows for current page
            foreach (var row in currentPageData)
            {
                xPos = leftMargin;

                // Order Date
                string orderDate = GetCellValue(row, "OrderDate");
                if (DateTime.TryParse(orderDate, out DateTime date))
                {
                    graphics.DrawString(date.ToString("MMM dd yyyy"), dataFont, Brushes.Black, xPos, yPos);
                }
                else
                {
                    graphics.DrawString(orderDate, dataFont, Brushes.Black, xPos, yPos);
                }
                xPos += columnWidths[0];

                // Product Name
                string productName = GetCellValue(row, "ProductName");
                if (productName.Length > 15) productName = productName.Substring(0, 13) + "...";
                graphics.DrawString(productName, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[1];

                // Category
                string category = GetCellValue(row, "Category");
                if (category.Length > 12) category = category.Substring(0, 10) + "...";
                graphics.DrawString(category, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[2];

                // Customer Name
                string customerName = GetCellValue(row, "CustomerName");
                if (customerName.Length > 12) customerName = customerName.Substring(0, 10) + "...";
                graphics.DrawString(customerName, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[3];

                // Unit Price
                string unitPrice = FormatNumericValue(GetCellValue(row, "UnitPrice"), true);
                graphics.DrawString(unitPrice, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[4];

                // Order Total
                string orderTotal = FormatNumericValue(GetCellValue(row, "OrderTotal"), true);
                graphics.DrawString(orderTotal, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[5];

                // Quantity
                string quantity = GetCellValue(row, "Quantity");
                graphics.DrawString(quantity, dataFont, Brushes.Black, xPos, yPos);

                yPos += 14;

                // Check if we're running out of space for the next row
                if (yPos > e.MarginBounds.Bottom - 30)
                {
                    break;
                }
            }

            PrintPageFooter(graphics, e, ref yPos, centerX, normalFont);
        }

        private void PrintSalesSummaryReport(Graphics graphics, PrintPageEventArgs e, ref float yPos, float leftMargin, float centerX, Font smallFont, Font dataFont, Font normalFont)
        {
            graphics.DrawString("DETAILED SALES DATA", smallFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            // Define column widths for Sales Summary report
            float[] columnWidths = { 40, 100, 70, 35, 65, 75, 40 };
            string[] headers = { "ID", "Product Name", "Category", "Qty", "Unit Price", "Revenue", "Orders" };

            // Print headers
            float xPos = leftMargin;
            for (int i = 0; i < headers.Length; i++)
            {
                graphics.DrawString(headers[i], smallFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[i];
            }
            yPos += 15;

            // Draw line under headers
            graphics.DrawLine(Pens.Black, leftMargin, yPos, xPos, yPos);
            yPos += 8;

            // Get current page data
            var currentPageData = _pages[currentPage];

            // Print data rows for current page
            foreach (var row in currentPageData)
            {
                xPos = leftMargin;

                // ProductID
                string productId = GetCellValue(row, "ProductID");
                graphics.DrawString(productId, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[0];

                // ProductName
                string productName = GetCellValue(row, "ProductName");
                if (productName.Length > 15) productName = productName.Substring(0, 13) + "...";
                graphics.DrawString(productName, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[1];

                // Category
                string category = GetCellValue(row, "Category");
                if (category.Length > 10) category = category.Substring(0, 8) + "...";
                graphics.DrawString(category, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[2];

                // Quantity
                string quantity = GetCellValue(row, "TotalQuantitySold");
                graphics.DrawString(quantity, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[3];

                // Unit Price
                string unitPrice = FormatNumericValue(GetCellValue(row, "UnitPrice"), true);
                graphics.DrawString(unitPrice, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[4];

                // Revenue
                string revenue = FormatNumericValue(GetCellValue(row, "TotalRevenue"), true);
                graphics.DrawString(revenue, dataFont, Brushes.Black, xPos, yPos);
                xPos += columnWidths[5];

                // Orders
                string orders = GetCellValue(row, "NumberOrder");
                graphics.DrawString(orders, dataFont, Brushes.Black, xPos, yPos);

                yPos += 14;

                // Check if we're running out of space for the next row
                if (yPos > e.MarginBounds.Bottom - 30)
                {
                    break;
                }
            }

            PrintPageFooter(graphics, e, ref yPos, centerX, normalFont);
        }

        private void PrintPageFooter(Graphics graphics, PrintPageEventArgs e, ref float yPos, float centerX, Font font)
        {
            // Page number and footer
            yPos = e.MarginBounds.Bottom - 20;
            string pageInfo = $"Page {currentPage + 1} of {_pages.Count}";
            graphics.DrawString(pageInfo, font, Brushes.Black, centerX - 30, yPos);

            // Check if there are more pages
            if (currentPage < _pages.Count - 1)
            {
                e.HasMorePages = true;
                currentPage++;
            }
            else
            {
                // Last page - show end of report
                yPos += 15;
                graphics.DrawString("--- End of Report ---", font, Brushes.Black, centerX - 50, yPos);
                e.HasMorePages = false;
            }
        }

        private string GetCellValue(Dictionary<string, object> row, string columnName)
        {
            // for trying the exact match first
            if (row.ContainsKey(columnName) && row[columnName] != null)
            {
                return row[columnName].ToString();
            }

            // fallback: case-insensitive match
            var key = row.Keys.FirstOrDefault(k =>
                string.Equals(k, columnName, StringComparison.OrdinalIgnoreCase));
            if (key != null && row[key] != null)
            {
                return row[key].ToString();
            }

            return "-";
        }

        private string FormatNumericValue(string value, bool asCurrency = false)
        {
            if (decimal.TryParse(value, out decimal decimalValue))
            {
                if (asCurrency)
                {
                    return decimalValue.ToString("C2");
                }
                else
                {
                    return decimalValue % 1 == 0 ? ((int)decimalValue).ToString() : decimalValue.ToString("F2");
                }
            }
            return value;
        }

        private void btn_PrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                currentPage = 0; // Reset to first page
                PreparePages(); // Re-prepare pages in case data changed
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in print preview: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    currentPage = 0; // Reset to first page
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing document: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //To reset the current page before printing
        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            currentPage = 0;
        }
    }
}
