//dont look at this pls ty
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;
using System.Reflection.Metadata.Ecma335;

namespace Contact_Book
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MsTimer t = new();
            var connect = ConnectionChecker.ConnectionCheckerMethod(t);
            if (connect == null)
            {
                Console.ReadKey();
                Environment.Exit(0);
            }
            
            t.Watch.Stop();
            var elapsedMs = t.Watch.ElapsedMilliseconds;

            Console.WriteLine("Connection stability checked in: "+elapsedMs+"ms\n");
            Console.WriteLine("Please enter the contact's credentials!");

            ContactValues a = null;
            MySqlConnection conn = null;

            thereWeGoAgain:
            try
            {
                a = new ContactValues(ContactNameGetter.GetContactName(), ContactEmailGetter.GetContactEmail(), ContactPhoneGetter.GetContactPhone(), ContactNameOfMotherGetter.GetContactMotherName());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Executer.Execute(a);
            Console.WriteLine("Do you want to add more contacts to the table?\nPress '0' to exit, or press '1' to add more contacts!");

            var again = MoreContacts.ThereWeGoAgain();

            if(again == 1)
            {
                goto thereWeGoAgain;
            }
        }
    }
    public class ContactValues
    {
        public string Name { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Mother { get; }
        public ContactValues(string contactName, string contactEmail, string contactPhone, string contactMother)
        {
            this.Name = contactName;
            this.Email = contactEmail;
            this.Phone = contactPhone;
            this.Mother = contactMother;
        }
    }
    public class MsTimer
    {
        public dynamic ?Watch { get; set; }
    }
}