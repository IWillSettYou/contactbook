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
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;database=contactbook;port=3306;password=";
            //The insertion address
            const string query = "INSERT INTO contacts(name, email, phoneNumber, nameOfMother) VALUES (@name, @email, @phone, @mother);";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                //calculating the procedure time
                var watch = System.Diagnostics.Stopwatch.StartNew();

                conn.Open();
                cmd.Connection = conn;

                //deleting the table if exists
                /*cmd.CommandText = "DROP TABLE IF EXISTS contacts";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "REPAIR TABLE contacts";
                cmd.ExecuteNonQuery();

                Console.WriteLine("Dropped pervious table");*/
                

                //creating a new table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS contacts (" +
                  "id INT NOT NULL AUTO_INCREMENT PRIMARY KEY," +
                  "name VARCHAR(40), email VARCHAR(40), phoneNumber INT(16), nameOfMother VARCHAR(40))";
                cmd.ExecuteNonQuery();

                Console.WriteLine("Table created, inserting values...");

                //defining the variables for the query string
                cmd.Parameters.Add("@name", MySqlDbType.VarChar, 40).Value = a.Name;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 40).Value = a.Email;
                cmd.Parameters.Add("@phone", MySqlDbType.Int16, 16).Value = a.Phone;
                cmd.Parameters.Add("@mother", MySqlDbType.VarChar, 40).Value = a.Mother;
                cmd.ExecuteNonQuery();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine("Credentials succesfully inserted in: " + elapsedMs + "ms");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
                conn.Close();
            }
            conn.Close();
        }
    }
}