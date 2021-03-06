﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace LevelGraph
{
    class DbUtil
    {
        private static string GetConnectionString()
        {
            var connectionString = string.Empty;
            //connectionString += Properties.Settings.Default.KanmusuDBConnectionString;
            return connectionString;
        }

        public static void insert(string queryString)
        {
            string connectionString = GetConnectionString();
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    connection.ConnectionString = connectionString;
                    //connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Program Files\\KanCollePlugins\\KanmusuDB.mdf\"; Integrated Security = True; Connect Timeout = 30;";
                    connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                }
            }
        }

        public static void select()
        {
            string connectionString = GetConnectionString();
            string queryString =
                "SELECT CategoryID, CategoryName FROM Categories;";
            using (OdbcConnection connection =
                       new OdbcConnection(connectionString))
            {
                OdbcCommand command = connection.CreateCommand();
                command.CommandText = queryString;

                try
                {
                    connection.Open();

                    OdbcDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void update()
        {
        }

        public static void createTable()
        {
        }
    }
}
