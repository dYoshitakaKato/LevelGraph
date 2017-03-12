using System;
using System.Data.Odbc;

namespace LevelGraph
{
    class DbUtil
    {
        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            // Assumes Northwind.mdb is located in the c:\Data folder.
            return "Driver={Microsoft Access Driver (*.mdb)};"
                + "Dbq=c:\\Data\\Northwind.mdb;Uid=Admin;Pwd=;";
        }

        public static void insert()
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
