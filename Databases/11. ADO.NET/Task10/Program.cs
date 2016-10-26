using System;
using System.Data.SQLite;

namespace Task10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Re-implement the previous task with SQLite embedded DB.

            // Please open SSMS and create a database named "Books" (an empty one, without any tables).
            var connectionString = "Data Source=../../Books.sqlite;Version=3;";
            SQLiteConnection.CreateFile("../../Books.sqlite");
            var connection = new SQLiteConnection(connectionString);

            CreateTablesInBooksSchema(connection);

            // IF YOU START THE PROGRAM MORE THAN ONCE, comment the next line(like this-- > // AddBooksToSchema(connection);).
            AddData(connection, "Harry Potter", "J. K. Rowling", "9283846102345");
            ListBooks(connection);

            Console.WriteLine("Type a pattern to search a book-title by (eg. harry): ");
            string patternName = Console.ReadLine();
            FindBookByName(connection, patternName);
        }

        private static void CreateTablesInBooksSchema(SQLiteConnection connection)
        {
            string createBooksTables = @"create table books(
                                             id integer primary key autoincrement,
                                             name nvarchar(100),
                                             author nvarchar(100),
                                             isbn nvarchar(13))";

            using (connection = new SQLiteConnection(connection))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(createBooksTables, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Books-schema has it's tables.\n");
            }
        }

        private static void AddData(SQLiteConnection connection, string name, string author, string isbn)
        {
            using (connection = new SQLiteConnection(connection))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand($"insert into books (name, author, isbn) values ('{name}', '{author}', '{isbn}')", connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Data is inserted into tables.\n");
            }
        }

        private static void ListBooks(SQLiteConnection connection)
        {
            using (connection = new SQLiteConnection(connection))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("select name, author from books", connection);
                SQLiteDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var bookName = (string)reader["name"];
                        var bookAuthor = (string)reader["author"];

                        Console.WriteLine($"All books:\n\"{bookName}\" by {bookAuthor}.\n");
                    }
                }
            }
        }

        private static void FindBookByName(SQLiteConnection connection, string pattern)
        {
            pattern = pattern.ToLower();

            using (connection = new SQLiteConnection(connection))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("select name, author from books " +
                                                          $"where name like '%{pattern}%'", connection);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var bookName = (string)reader["name"];
                        var bookAuthor = (string)reader["author"];

                        Console.WriteLine($"Books, containing \"{pattern}\":\n\"{bookName}\" by {bookAuthor}.\n");
                    }
                }
            }
        }
    }
}
