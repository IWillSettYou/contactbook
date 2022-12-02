using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Contact_Book
{
    class ConnectionChecker
    {
        public static MySqlConnection ConnectionCheckerMethod(MsTimer t)
        {
           
            try
            { 
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;user=tanulo;database=contactbook;port=3306;password=tanulo";
                   
                Console.WriteLine("Checking connection with MySQL server...");
                t.Watch = System.Diagnostics.Stopwatch.StartNew();

                conn.Open();

                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}