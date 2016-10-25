using System;
using System.Data.SqlClient;

namespace Task2
{
    public class Program
    {
        public static void Main()
        {
            // Write a program that retrieves the name and description of all categories in the Northwind DB.

            var connectionString = "Server=.;Database=Northwind;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (string)reader["CategoryName"];
                        var description = (string)reader["Description"];

                        Console.WriteLine($"Category: {categoryName}\nDescription: {description}\n\n");
                    }
                }
            }
        }
    }
}
