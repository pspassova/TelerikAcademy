using System;
using System.Data.SqlClient;

namespace Task4
{
    public class Program
    {
        public static void Main()
        {
            // Write a method that adds a new product in the products table in the Northwind database.
            // Use a parameterized SQL command.

            var connectionString = "Server=.;Database=Northwind;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Products " +
                                                    "(ProductName, SupplierID, CategoryID, QuantityPerUnit, " +
                                                    "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                                                    "VALUES " +
                                                    "(@productName, @supplierID, @categoryID, @quantityPerUnit, " +
                                                    "@unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", connection);

                command.Parameters.AddWithValue("@productName", "Some Name");
                command.Parameters.AddWithValue("@supplierID", 3);
                command.Parameters.AddWithValue("@categoryID", 5);
                command.Parameters.AddWithValue("@quantityPerUnit", "10 boxes x 20 bags");
                command.Parameters.AddWithValue("@unitPrice", 18.01);
                command.Parameters.AddWithValue("@unitsInStock", 0);
                command.Parameters.AddWithValue("@unitsOnOrder", 2);
                command.Parameters.AddWithValue("@reorderLevel", 1);
                command.Parameters.AddWithValue("@discontinued", 0);

                command.ExecuteNonQuery();

                Console.WriteLine("Check Northwind for a new added product :)");
            }
        }
    }
}
