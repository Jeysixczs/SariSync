using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    [Table("tbl_Expense")]
    public class Expenses
    {
        [Key]
        public int ExpenseID { get; set; }
        
        public string ExpenseName { get; set; }
        public Decimal Amount { get; set; }

        public DateTime ExpenseDate { get; set; }
        public string? Description { get; set; }

        public string ConnectionString = @"Data Source=DESKTOP-ECKGUHL\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public List<Expenses> Getexpenses()
        {
            List<Expenses> Expense = new List<Expenses>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from tbl_Expense", con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Expenses expenses = new Expenses
                        {
                            ExpenseID = Convert.ToInt32(reader["ExpenseID"]),
                            ExpenseName = reader["ExpenseName"]?.ToString() ?? string.Empty,
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                            Description = reader["Description"]?.ToString()
                        };
                        Expense.Add(expenses);
                    }
                }
            }


            return Expense;
        }

        
    }
}
