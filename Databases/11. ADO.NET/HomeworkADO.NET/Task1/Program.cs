using System.Data.SqlClient;
using System;

namespace Task1
{
    public class Program
    {
        public static void Main()
        {
            // Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.

            // If this connectionString doesn't work, try "Server=.\\SQLEXPRESS;Database=Northwind; Integrated Security=true"
            // or whatever works for you.
            var connectionString = "Server=.;Database=Northwind;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
                int rowsCount = (int)command.ExecuteScalar();

                Console.WriteLine($"Number of rows in the Categories table: {rowsCount}");
            }
        }
    }
}
