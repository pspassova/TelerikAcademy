using System;
using System.Data.OleDb;

namespace Task6
{
    public class Program
    {
        public static void Main()
        {
            // Create an Excel file with 2 columns: name and score...
            // Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\scores.xlsx; Extended Properties = \"Excel 12.0 Xml;HDR=YES\"";
            OleDbConnection connection = new OleDbConnection(connectionString);

            connection.Open();

            using (connection)
            {
                for (int i = 1; i < 15; i++)
                {
                    OleDbCommand command = new OleDbCommand("SELECT * FROM [Scores$]", connection);

                    command.Parameters.AddWithValue("@name", "User N" + i);

                    OleDbDataReader reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var name = (string)reader["Name"];
                            var score = (string)reader["Score"];

                            Console.WriteLine($"Name: {name}\nScore: {score}\n\n");
                        }
                    }
                }
            }
        }
    }
}
