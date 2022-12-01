using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Book
{
    class ContactEmailGetter
    {
        public static string GetContactEmail()
        {
            Console.WriteLine("Email address:");
        email:
            var email = Console.ReadLine();

            //checking if the input is null
            if (email == null || email == String.Empty)
            {
                Console.WriteLine("Please enter a valid E-Mail address!");
                goto email;
            }

            //trimming the email from spaces
            char[] charsToTrim = { '+', '-', '/', '.', ',', '*', '-', '_', };

            var trimmedEmail = email.Trim().TrimEnd(charsToTrim).TrimStart(charsToTrim);

            //checking if the email can be a real email
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address == email)
                {
                    return trimmedEmail;
                }
                else
                {
                    Console.WriteLine("Please enter a valid E-Mail address!");
                    goto email;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid E-Mail address!");
                goto email;
            }
        }
    }
}