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
        private int _rowsPerPage = 35; // to show per 35 rows per page

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
            sb.AppendLine($"Report: {_reportType}");
            sb.AppendLine($"Date: {DateTime.Now:MMM dd, yyyy hh:mm tt}");
            sb.AppendLine();

            // Summary Section
            sb.AppendLine("SUMMARY");
            sb.AppendLine($"Total Records: {_reportData.Count}");
            sb.AppendLine($"Total Sales: {_totalSales:C2}");
            sb.AppendLine();

            // Detailed Data Section
            if (_reportData.Count > 0)
            {
                sb.AppendLine("DETAILED SALES DATA");
                sb.AppendLine();

                //Simple text representation
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
                graphics.DrawString($"Date: {DateTime.Now:MMM dd, yyyy hh:mm tt}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                // Date Range 
                if (startDate.HasValue && endDate.HasValue)
                {
                    graphics.DrawString($"Period: {startDate.Value:MMM dd, yyyy} to {endDate.Value:MMM dd, yyyy}", normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }
                else if (specificDate.HasValue)
                {
                    graphics.DrawString($"Date: {specificDate.Value:MMM dd, yyyy}", normalFont, Brushes.Black, leftMargin, yPos);
                    yPos += 15;
                }

                // Summary Section
                graphics.DrawString("SUMMARY", headerFont, Brushes.Black, leftMargin, yPos);
                yPos += 15;
                graphics.DrawString($"Total Records: {_reportData.Count}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 12;
                graphics.DrawString($"Total Sales: {_totalSales:C2}", headerFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                // Detailed Data Table
                if (_reportData.Count > 0)
                {
                    graphics.DrawString("DETAILED SALES DATA", headerFont, Brushes.Black, leftMargin, yPos);
                    yPos += 20;

                    // To Define column widths
                    float[] columnWidths = { 45, 100, 80, 40, 65, 75, 45 };
                    string[] headers = { "ProdID", "Product Name", "Category", "Qty", "Unit Price", "Revenue", "Orders" };

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

                    // Calculate which rows to print on this page
                    int startIndex = currentPage * _rowsPerPage;
                    int endIndex = Math.Min(startIndex + _rowsPerPage, _reportData.Count);

                    // Print data rows for current page
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        var row = _reportData[i];
                        xPos = leftMargin;

                        // ProductID
                        string productId = GetCellValue(row, "ProductID");
                        graphics.DrawString(productId, dataFont, Brushes.Black, xPos, yPos);
                        xPos += columnWidths[0];

                        // ProductName
                        string productName = GetCellValue(row, "ProductName");
                        if (productName.Length > 12) productName = productName.Substring(0, 10) + "...";
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

                        // Check if we're running out of space
                        if (yPos > e.MarginBounds.Bottom - 50 && i < endIndex - 1)
                        {
                            e.HasMorePages = true;
                            currentPage++;
                            return;
                        }
                    }

                    // Calculate total pages
                    int totalPages = (_reportData.Count + _rowsPerPage - 1) / _rowsPerPage;

                    // Page number
                    yPos = e.MarginBounds.Bottom - 30;
                    string pageInfo = $"Page {currentPage + 1} of {totalPages}";
                    graphics.DrawString(pageInfo, normalFont, Brushes.Black, centerX - 30, yPos);

                    // If this is the last page, show end of report
                    if (currentPage == totalPages - 1)
                    {
                        yPos += 20;
                        graphics.DrawString("--- End of Report ---", normalFont, Brushes.Black, centerX - 50, yPos);
                        e.HasMorePages = false;
                    }
                    else
                    {
                        e.HasMorePages = true;
                        currentPage++;
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

        private void btn_PrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                currentPage = 0; // Reset to first page
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in print preview: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //To reset the current page before printing
        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            currentPage = 0;
        }
    }
}
