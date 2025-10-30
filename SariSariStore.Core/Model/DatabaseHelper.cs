using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    public class DatabaseHelper
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UserManagement;Integrated Security=True;";

        public bool RegisterUser(string username, string password, string email)
        {
          
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // In a real application, you should hash the password
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password); // Hash this in production
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            


        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password); // Compare with hashed password in production

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 1;
                }
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }

        public bool UserExists(string username)
        {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            
         
        }
    }
}
