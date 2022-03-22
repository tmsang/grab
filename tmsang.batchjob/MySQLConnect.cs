using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace tmsang.batchjob
{
    public class MySQLConnect
    {
        private MySqlConnection connection;

        public MySQLConnect()
        {
            var connectionString = GetConnectionString();

            connection = new MySqlConnection(connectionString);

            Console.WriteLine($"{"ConnectionString ",17} : {connectionString}");
            Console.WriteLine($"{"DataSource ",17} : {connection.DataSource}");
        }

        public string GetConnectionString() {
            var stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder["Server"] = "localhost";
            stringBuilder["Database"] = "grab";
            stringBuilder["User Id"] = "root";
            stringBuilder["Password"] = "";
            stringBuilder["Port"] = "3306";

            var connectionString = stringBuilder.ToString();            

            return connectionString;
        }

        public void Update(string sql)
        {
            try
            {
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    var result = command.ExecuteNonQuery();
                    Console.WriteLine($"-------- There are {result} updated records at {DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")} ----------");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void Insert(string sql)
        {
            try
            {
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    var result = command.ExecuteNonQuery();
                    Console.WriteLine($"-------- There are {result} inserted records at {DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")} ----------");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string sql)
        {
            try
            {
                connection.Open();
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    var result = command.ExecuteNonQuery();
                    Console.WriteLine($"-------- There are {result} deleted records at {DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")} ----------");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
