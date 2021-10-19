using Database;
using Database.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            // use to check connection to ms sql server
            //var connectionString = @"Server=WS-PC-88\SQLEXPRESS03;Trusted_Connection=True;";

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    Console.WriteLine($"ServerVersion: {connection.ServerVersion}");
            //    Console.WriteLine($"State: {connection.State}");
            //}

            using (TestDbContext db = new TestDbContext())
            {
                var user1 = new Security { Login = "Tom", Password = "333" };
                var user2 = new Security { Login = "1", Password = "111" };

                db.Security.Add(user1);
                db.Security.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                var users = db.Security.ToList();
                Console.WriteLine("Список объектов:");
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}.{user.Login} - {user.Password}");
                }
            }
            Console.Read();
        }
    }
}
