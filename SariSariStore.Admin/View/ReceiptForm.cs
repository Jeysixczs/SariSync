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
        private PrintPreviewDialog _printPreviewDialog;
        private PrintDialog _printDialog;

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
            _printPreviewDialog = new PrintPreviewDialog();
            _printPreviewDialog.Document = _printDocument;

            _printDialog = new PrintDialog(); //to be able to select printer
            _printDialog.Document = _printDocument;
            _printDialog.AllowSomePages = false;
            _printDialog.ShowHelp = false; //true to show help button
        }

        public void DisplayReceipt()
        {
            if (_order == null) return;

            //Display receipt details
            string receiptText = GenerateRecieptText();
            receiptTextBox.Text = receiptText;
        }

        private string GenerateRecieptText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== Sari-Sari Store =====");
            sb.AppendLine("----------------------------");
            sb.AppendLine($"Order ID: {_order.OrderID}");
            sb.AppendLine($"Customer Name: {_order.CustomerName}");
            sb.AppendLine($"Order Date: {_order.OrderDate:yyyy-MM-dd HH:mm}");
            sb.AppendLine("----------------------------");
            sb.AppendLine();

            sb.AppendLine("Items:");
            sb.AppendLine("----------------------------");

            if (_order.Items != null && _order.Items.Count > 0)
            {
                foreach (var item in _order.Items)
                {
                    sb.AppendLine($"{item.ProductName}");
                    sb.AppendLine($"  Qty: {item.Quantity}  Unit Price: {item.UnitPrice:C2}  Total: {item.TotalPrice:C2}");
                }
            }
            sb.AppendLine("----------------------------");
            sb.AppendLine($"Total Amount: {_order.TotalAmount:C2}");
            sb.AppendLine();
            sb.AppendLine($"Payment Status: {(_order.IsPaid ? "Paid" : "Unpaid")}");
            sb.AppendLine("============================");
            sb.AppendLine("Thank you for shopping with us!");
            return sb.ToString();
        }

        private void btn_PrintButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    _printPreviewDialog.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("No order data to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            try
            {
                    // Show printer selection dialog
                if (_printDialog.ShowDialog() == DialogResult.OK)
                {
                    // If User selected a printer and clicked OK
                    _printDocument.Print();
                }
                    // If user clicks Cancel, nothing happens
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Printing error: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string receiptText = GenerateRecieptText();
            Font font = new Font("Courier New", 10);
            Brush brush = Brushes.Black;

            //calculate positions
            float x = 10;
            float y = 10;
            float lineHeight = font.GetHeight(e.Graphics);

            //split receipt text into lines and print each line
            string[] lines = receiptText.Split('\n');

            foreach (string line in lines)
            {
                e.Graphics.DrawString(line, font, brush, x, y);
                y += lineHeight;

                if (y + lineHeight > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void receiptTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
