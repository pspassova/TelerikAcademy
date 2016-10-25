using System;
using System.Data.SqlClient;

namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            // Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
            // Can you do this with a single SQL query (with table join)?

            var connectionString = "Server=.;Database=Northwind;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT c.CategoryName, p.ProductName " +
                                                    "FROM Categories c " +
                                                    "JOIN Products p " +
                                                    "ON c.CategoryID = p.CategoryID", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var category = (string)reader["CategoryName"];
                        var product = (string)reader["ProductName"];

                        Console.WriteLine($"Category: {category}\nProduct: {product}\n\n");
                    }
                }
            }
        }
    }
}
