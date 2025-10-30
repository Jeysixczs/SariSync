using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SariSariStore.Admin.View
{
    public partial class Register : Form
    {
        public string connection = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True";

        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input validation
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    // Check if username already exists
                    if (UsernameExists(textBox2.Text, con))
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox2.Focus();
                        return;
                    }

                    string query = "INSERT INTO tbl_user (Name, Username, Password) VALUES (@fullname, @username, @password)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@fullname", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@username", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", textBox3.Text);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Registration Failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            // Validate Full Name
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            if (textBox1.Text.Trim().Length < 2)
            {
                MessageBox.Show("Full name must be at least 2 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            if (textBox1.Text.Trim().Length > 100)
            {
                MessageBox.Show("Full name cannot exceed 100 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            // Validate Username
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            if (textBox2.Text.Trim().Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            if (textBox2.Text.Trim().Length > 50)
            {
                MessageBox.Show("Username cannot exceed 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username can only contain letters, numbers, and underscores.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            if (textBox3.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            if (textBox3.Text.Length > 100)
            {
                MessageBox.Show("Password cannot exceed 100 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            return true;
        }

        private bool UsernameExists(string username, SqlConnection connection)
        {
            string query = "SELECT COUNT(1) FROM tbl_user WHERE Username = @username";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", username.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Optional: Add real-time validation in TextChanged events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidateNameField();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidateUsernameField();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ValidatePasswordField();
        }

        private void ValidateNameField()
        {
            if (textBox1.Text.Trim().Length > 100)
            {
                errorProvider1.SetError(textBox1, "Full name cannot exceed 100 characters.");
            }
            else if (textBox1.Text.Trim().Length < 2 && textBox1.Text.Trim().Length > 0)
            {
                errorProvider1.SetError(textBox1, "Full name must be at least 2 characters long.");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void ValidateUsernameField()
        {
            if (textBox2.Text.Trim().Length > 50)
            {
                errorProvider1.SetError(textBox2, "Username cannot exceed 50 characters.");
            }
            else if (textBox2.Text.Trim().Length < 3 && textBox2.Text.Trim().Length > 0)
            {
                errorProvider1.SetError(textBox2, "Username must be at least 3 characters long.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[a-zA-Z0-9_]*$") && textBox2.Text.Length > 0)
            {
                errorProvider1.SetError(textBox2, "Username can only contain letters, numbers, and underscores.");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void ValidatePasswordField()
        {
            if (textBox3.Text.Length > 100)
            {
                errorProvider1.SetError(textBox3, "Password cannot exceed 100 characters.");
            }
            else if (textBox3.Text.Length < 6 && textBox3.Text.Length > 0)
            {
                errorProvider1.SetError(textBox3, "Password must be at least 6 characters long.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            LoginForm log = new LoginForm();
            log.Show();
        }
    }
}