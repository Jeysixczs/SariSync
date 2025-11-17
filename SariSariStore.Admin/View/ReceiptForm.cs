using SariSariStore.Core.Model;
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

namespace SariSariStore.Admin
{
    public partial class ReceiptForm : Form
    {
        private Orders _order;
        private PrintDocument _printDocument;
        private string _receiptText;

        public ReceiptForm(Orders order)
        {
            InitializeComponent();
            _order = order;
            InitializePrinting();
            DisplayReceipt();
        }

        private void InitializePrinting()
        {
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
        }

        public void DisplayReceipt()
        {
            if (_order == null) return;

            _receiptText = GenerateReceiptText();
            receiptTextBox.Text = _receiptText;
        }

        private string GenerateReceiptText()
        {
            StringBuilder sb = new StringBuilder();
            int maxWidth = 50; // Maximum characters per line for receipt

            // Helper function to center text
            string CenterText(string text)
            {
                if (text.Length >= maxWidth) return text;
                int padding = (maxWidth - text.Length) / 2;
                return text.PadLeft(text.Length + padding).PadRight(maxWidth);
            }

            // Helper function to add line breaks
            void AddCenteredLine(string text)
            {
                sb.AppendLine(CenterText(text));
            }

            void AddSeparator()
            {
                sb.AppendLine(new string('-', maxWidth));
            }

            // Helper function to format currency as Peso
            string FormatAsPeso(decimal amount)
            {
                return "₱" + amount.ToString("N2");
            }

            // Header
            sb.AppendLine();
            AddCenteredLine("SariSync Store");
            AddSeparator();

            // Order Information
            sb.AppendLine($"Order ID: {_order.OrderID}".PadRight(maxWidth));
            sb.AppendLine($"Customer: {(_order.CustomerName ?? "Walk-in Customer")}".PadRight(maxWidth));
            sb.AppendLine($"Date: {_order.OrderDate:yyyy-MM-dd HH:mm}".PadRight(maxWidth));
            AddSeparator();
            sb.AppendLine();

            // Items Header
            AddCenteredLine("ITEMS PURCHASED");
            AddSeparator();

            // Items List - FIXED FOR PESO FORMAT
            if (_order.Items != null && _order.Items.Count > 0)
            {
                foreach (var item in _order.Items)
                {
                    string productName = item.ProductName;
                    if (productName.Length > 20) // Reduced length for better formatting
                        productName = productName.Substring(0, 20) + "...";

                    // Format: Product name, quantity x price, then total price
                    // Fixed: Use Peso format instead of currency format
                    sb.AppendLine($"{productName,-20} {item.Quantity,2} x {FormatAsPeso(item.UnitPrice),10}");

                    // Calculate and display line total
                  
                }
            }
            else
            {
                sb.AppendLine("No items in order".PadRight(maxWidth));
            }

            AddSeparator();

            // Total - FIXED FOR PESO FORMAT
            sb.AppendLine($"{"TOTAL AMOUNT:",-30} {FormatAsPeso(_order.TotalAmount),12}");
            sb.AppendLine();

            // Payment Status
            string status = _order.IsPaid ? "PAID" : "UNPAID";
            sb.AppendLine($"Payment Status: {status}".PadRight(maxWidth));

            // Notes and Remarks if available
            if (!string.IsNullOrEmpty(_order.Notes))
            {
                sb.AppendLine($"Notes: {_order.Notes}".PadRight(maxWidth));
            }
            if (!string.IsNullOrEmpty(_order.Remarks))
            {
                sb.AppendLine($"Remarks: {_order.Remarks}".PadRight(maxWidth));
            }

            // Footer
            AddSeparator();
            AddCenteredLine("Thank you for shopping with us!");
            AddCenteredLine("Please come again!");
            sb.AppendLine();
            sb.AppendLine($"Printed: {DateTime.Now:yyyy-MM-dd HH:mm}".PadRight(maxWidth));
            AddSeparator();

            return sb.ToString();
        }

        private void btn_PrintButton_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;
                printDialog.AllowSomePages = true;
                printDialog.ShowHelp = true;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Printing error: {ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Use smaller font suitable for receipt printers
                Font receiptFont = new Font("Consolas", 8F, FontStyle.Regular);
                Brush brush = Brushes.Black;

                // Use much smaller margins for receipt paper
                float x = 10;  // Reduced from 50
                float y = 10;  // Reduced from 50
                float lineHeight = receiptFont.GetHeight(e.Graphics);

                string[] lines = _receiptText.Split('\n');

                foreach (string line in lines)
                {
                    e.Graphics.DrawString(line, receiptFont, brush, x, y);
                    y += lineHeight;

                    // Check if we're at the bottom of receipt paper (typically 3-4 inches)
                    if (y > e.PageBounds.Height - 20) // Reduced margin
                    {
                        e.HasMorePages = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Print error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void receiptTextBox_TextChanged(object sender, EventArgs e)
        {
            receiptTextBox.SelectionStart = receiptTextBox.Text.Length;
            receiptTextBox.ScrollToCaret();
        }
    }
}