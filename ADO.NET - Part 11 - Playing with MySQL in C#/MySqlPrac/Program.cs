using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlPrac
{
    //Console Application, .NET Framework 4.5, VS 2013
    //Test with SQL Server
    //Test with MySQL
    class Program
    {
        static void Main(string[] args)
        {
            TestDBMySQL();
            Console.ReadKey();
        }

        static void TestDBMySQL()
        {
            String connStr = @"server=localhost; port=3306;Uid=root;Pwd=;database=cms;Convert Zero Datetime=True";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    String query = "Insert into users(Name,Age) Values('ABC',20)";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    int recEffected = command.ExecuteNonQuery();

                    query = "Select * from users";
                    command = new MySqlCommand(query, conn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        String name = Convert.ToString(reader["Name"]);
                        int age = Convert.ToInt32(reader["Age"]);

                        Console.WriteLine("ID:{0}", id);
                        Console.WriteLine("Name:{0}", name);
                        Console.WriteLine("Age:{0}", age);
                    }

                    //DataTable dt = new DataTable();
                    //dt.Load(reader);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        static void TestDBSQLServer()
        {
            String connStr = @"Data Source=.\SQLEXPRESS2012;Initial Catalog=cms;User Id=sa;Password=P@ssword12345;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    String query = "Insert into dbo.users(Name,Age) Values('ABC',20)";
                    SqlCommand command = new SqlCommand(query, conn);
                    int recEffected = command.ExecuteNonQuery();

                    query = "Select * from dbo.users";
                    command = new SqlCommand(query, conn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        String name = Convert.ToString(reader["Name"]);
                        int age = Convert.ToInt32(reader["Age"]);

                        Console.WriteLine("ID:{0}", id);
                        Console.WriteLine("Name:{0}", name);
                        Console.WriteLine("Age:{0}", age);
                    }

                    //DataTable dt = new DataTable();
                    //dt.Load(reader);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
