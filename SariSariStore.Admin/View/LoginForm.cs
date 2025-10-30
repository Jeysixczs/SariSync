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
    public partial class LoginForm : Form
    {
        public string connection = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = "SELECT * FROM tbl_user WHERE Username=@username AND Password=@password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", textBox3.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Successful login
                        MessageBox.Show("Login Successful!");
                        // Proceed to the next form or dashboard
                        this.Hide();
                        DashboardForm dashboard = new DashboardForm();
                        dashboard.Show();
                    }
                    else
                    {
                        // Invalid credentials
                        MessageBox.Show("Invalid Username or Password.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }
    }
}
