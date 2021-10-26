using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using WebTestCore.Models.Security;

namespace WebInterface.EfServices
{
    public class AdoSecurityService : ISecurityService
    {
        public string ConnectionString { get; set; }

        public AdoSecurityService()
        {
            ConnectionString = @"Server=WS-PC-88\SQLEXPRESS03;Database=TestDb;Trusted_Connection=True;";
        }

        public int Authorization(SecurityVm model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"SELECT * FROM [TestDb].[dbo.Securities].[Security] " +
                    $"WHERE Login = {model.Login} " +
                    $"AND Password = {model.Password}",
                    Connection = connection,
                };

                var reader =  command.ExecuteReader();

                if (!reader.HasRows) return 0;

                while (reader.Read())
                {
                    model.Id = reader.GetInt32(0);
                }
            }
            return model.Id;
        }

        public SecurityVm Authorization(int id)
        {
            var security = new SecurityVm();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"SELECT * FROM [TestDb].[dbo.Securities].[Security] " +
                    $"WHERE Id = {id} ",
                    Connection = connection,
                };

                var reader = command.ExecuteReader();

                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    security.Id = reader.GetInt32(0);
                    security.Login = reader.GetString(1);
                    security.Password = reader.GetString(2);
                }
            }
            return security;
        }

        public SecurityListVm GetList()
        {
            SecurityListVm model;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"SELECT * FROM [TestDb].[dbo.Securities].[Security]",
                    Connection = connection,
                };

                var reader = command.ExecuteReader();

                if (!reader.HasRows) return null;

                var listModel = new List<SecurityList>();

                while (reader.Read())
                {
                    var modelElement =  new SecurityList
                    {
                        Id = reader.GetInt32("Id"),
                        Login = reader.GetString("Login"),
                        Password = reader.GetString("Password"),
                    };

                    listModel.Add(modelElement);
                }

                model = new SecurityListVm()
                {
                    SecurityList = listModel,
                };
            }
            return model;
        }

        public void Create(SecurityCreateVm security)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"INSERT INTO [TestDb].[dbo.Securities].[Security] ([Login],[Password]) " +
                    $"VALUES ({security.Login.Trim()}, {security.Password.Trim()})",
                    Connection = connection,
                };

                command.ExecuteNonQuery();
            }
        }

        public SecurityUpdateVm GetUpdate(int id)
        {
            var security = new SecurityUpdateVm();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"SELECT * FROM [TestDb].[dbo.Securities].[Security] " +
                    $"WHERE Id = {id} ",
                    Connection = connection,
                };

                var reader = command.ExecuteReader();

                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    security.Id = reader.GetInt32(0);
                    security.Login = reader.GetString(1);
                    security.Password = reader.GetString(2);
                }
            }
            return security;
        }

        public void Update(SecurityUpdateVm security)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"UPDATE [TestDb].[dbo.Securities].[Security] " +
                    $"SET [Login] = {security.Login}," +
                        $"[Password] = {security.Password}" +
                    $"WHERE Id = {security.Id}",
                    Connection = connection,
                };

                command.ExecuteNonQuery();
            }
        }

        public SecurityDeleteVm GetDelete(int id)
        {
            var security = new SecurityDeleteVm();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"SELECT * FROM [TestDb].[dbo.Securities].[Security] " +
                    $"WHERE Id = {id} ",
                    Connection = connection,
                };

                var reader = command.ExecuteReader();

                if (!reader.HasRows) return null;

                while (reader.Read())
                {
                    security.Id = reader.GetInt32(0);
                    security.Login = reader.GetString(1);
                    security.Password = reader.GetString(2);
                }
            }
            return security;
        }

        public void Delete(SecurityDeleteVm security)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = $"DELETE FROM [TestDb].[dbo.Securities].[Security] " +
                    $"WHERE Id = {security.Id}",
                    Connection = connection,
                };

                command.ExecuteNonQuery();
            }
        }
    }
}