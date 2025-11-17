using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SariSariStore.Admin.View
{
    public partial class AddEditSupplierForm : Form
    {
        public readonly int _supplierId;
        private readonly bool _isEditMode;
        private Supplier _supplierService;

        public AddEditSupplierForm()
        {
            InitializeComponent();
            _isEditMode = false;
            _supplierService = new Supplier();
        }

        public AddEditSupplierForm(int selectedSupplierId)
        {
            InitializeComponent();
            _supplierId = selectedSupplierId;
            _isEditMode = true;
            _supplierService = new Supplier();
            saveButton.Text = "💾 UPDATE";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtboxSupplierName.Text))
                {
                    MessageBox.Show("Supplier Name is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtboxSupplierName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtboxContactPerson.Text))
                {
                    MessageBox.Show("Contact Person is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtboxContactPerson.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtboxContactNumber.Text))
                {
                    MessageBox.Show("Contact Number is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtboxContactNumber.Focus();
                    return;
                }

                // Validate phone number format
                string digitsOnly = new string(txtboxContactNumber.Text.Where(char.IsDigit).ToArray());
                string pattern = @"^09\d{9}$";

                if (digitsOnly.Length != 11 || !Regex.IsMatch(digitsOnly, pattern))
                {
                    MessageBox.Show("Invalid phone number format. It should start with '09' followed by 9 digits.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtboxContactNumber.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Address is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                var supplier = new Supplier
                {
                    SupplierName = txtboxSupplierName.Text.Trim(),
                    ContactPerson = txtboxContactPerson.Text.Trim(),
                    PhoneNumber = txtboxContactNumber.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    CreatedDate = DateTime.Now
                };

                if (_isEditMode)
                {
                    supplier.SupplierID = _supplierId;
                    _supplierService.UpdateSupplier(supplier);
                    MessageBox.Show("✅ Supplier updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _supplierService.AddSupplier(supplier);
                    MessageBox.Show("✅ Supplier added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Price and Stock.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving supplier: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSupplierDetails()
        {
            try
            {
                var supplier = _supplierService.GetSupplierById(_supplierId);

                if (supplier == null)
                {
                    MessageBox.Show("Supplier not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Populate the form fields with supplier data
                txtboxSupplierName.Text = supplier.SupplierName;
                txtboxContactPerson.Text = supplier.ContactPerson ?? string.Empty;
                txtboxContactNumber.Text = supplier.PhoneNumber ?? string.Empty;
                txtAddress.Text = supplier.Address ?? string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading supplier: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEditSupplierForm_Load(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                LoadSupplierDetails();
                labelTitle.Text = "Edit Supplier";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtboxContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtboxContactNumber_TextChanged(object sender, EventArgs e)
        {
            string text = txtboxContactNumber.Text.Replace("-", "");
            string formatted = "";

            if (text.Length > 0) formatted = text.Substring(0, Math.Min(4, text.Length));
            if (text.Length > 4) formatted += "-" + text.Substring(4, Math.Min(3, text.Length - 4));
            if (text.Length > 7) formatted += "-" + text.Substring(7, Math.Min(4, text.Length - 7));

            txtboxContactNumber.Text = formatted;
            txtboxContactNumber.SelectionStart = formatted.Length;

            ValidatePhoneNumber();
        }

        private void ValidatePhoneNumber()
        {
            string digitsOnly = new string(txtboxContactNumber.Text.Where(char.IsDigit).ToArray());
            string pattern = @"^09\d{9}$";

            if (digitsOnly.Length != 11 || !Regex.IsMatch(digitsOnly, pattern))
            {
                errorProvider1.SetError(txtboxContactNumber, "Invalid phone number format. It should start with '09' followed by 9 digits.");
            }
            else
            {
                errorProvider1.SetError(txtboxContactNumber, string.Empty);
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}