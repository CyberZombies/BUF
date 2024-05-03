using System;
using Microsoft.Data.Sqlite;
namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            int age = Int32.Parse(Console.ReadLine());
            string sqlExpression = $"INSERT INTO Users (Name, Age) VALUES ('{name}',{ age})";
        using (var connection = new SqliteConnection("Data Source=usersdata.db"))
            {
                connection.Open();
                // добавление
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Добавлено объектов: {number}");
                // обновление ранее добавленного объекта
                Console.WriteLine("Введите новое имя:");
                name = Console.ReadLine();
                sqlExpression = $"UPDATE Users SET Name='{name}' WHERE Age={age}";
                command.CommandText = sqlExpression;
                number = command.ExecuteNonQuery();
                Console.WriteLine($"Обновлено объектов: {number}");
            }
            Console.Read();
        }
    }
}
