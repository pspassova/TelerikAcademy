using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;

namespace Task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.

            var connectionString = "Server=.;Database=Northwind;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var category = (string)reader["CategoryName"];
                        category = category.Replace(' ', '-');
                        category = category.Replace('/', '+');

                        var picBytes = (byte[])reader["Picture"];
                        var fileName = string.Format("..\\..\\Images\\{0}.jpg", category);

                        WritePicturesFromBytes(fileName, picBytes);
                    }

                    Console.WriteLine("Check the Image folder in Task5 folder :)");
                }
            }
        }
        private static void WritePicturesFromBytes(string fileName, byte[] picBytes)
        {
            FileStream fileStream = File.OpenWrite(fileName);
            using (fileStream)
            {
                int offset = 78;
                fileStream.Write(picBytes, offset, picBytes.Length - offset);
            }
        }
    }
}
