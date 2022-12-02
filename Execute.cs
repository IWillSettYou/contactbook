using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Xml.Linq;

namespace Contact_Book
{
    class Executer
    {
        public static void Execute(ContactValues a)
        {
            MySqlConnection conn = new();
            conn.ConnectionString = "server=localhost;user=tanulo;database=contactbook;port=3306;password=tanulo";
            //The insertion address

            const string query = "CREATE TABLE IF NOT EXISTS contacts (" +
                                 "id INT NOT NULL AUTO_INCREMENT PRIMARY KEY," +
                                 "name VARCHAR(40), email VARCHAR(40), phoneNumber VARCHAR(16), nameOfMother VARCHAR(40))";

            const string query2 = "INSERT INTO contacts(name, email, phoneNumber, nameOfMother) VALUES (?name, ?email, ?phone, ?mother);";

                conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();



                conn.Open();
            MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                cmd2.Connection = conn;

                //defining the variables for the query string
                cmd2.Parameters.Add("?name", MySqlDbType.VarChar, 40).Value = a.Name;
                cmd2.Parameters.Add("?email", MySqlDbType.VarChar, 40).Value = a.Email;
                cmd2.Parameters.Add("?phone", MySqlDbType.VarChar, 16).Value = a.Phone;
                cmd2.Parameters.Add("?mother", MySqlDbType.VarChar, 40).Value = a.Mother;
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Table created, inserting values...");

                conn.Close();

            try
            {
                //calculating the procedure time
                var watch = System.Diagnostics.Stopwatch.StartNew();




                Console.WriteLine(a.Name + a.Email + a.Phone + a.Mother);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine("Credentials succesfully inserted in: " + elapsedMs + "ms");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
                conn.Close();
                conn.Close();
            }
        }
    }
}