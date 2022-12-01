using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Book
{
    class ContactPhoneGetter
    {
        public static string GetContactPhone()
        {
            Console.Write("Phone number:");
        number:
            var number = Console.ReadLine();
            if (number == null || number == String.Empty)
            {
                Console.WriteLine("Please enter a valid phone number!");
                goto number;
            }

            //trimming the input from idiocy
            char[] charsToTrim = { '+', '-', '/', '.', ',', '*', '-', '_', };
            var clearNumber = number.Trim().TrimEnd(charsToTrim).TrimStart(charsToTrim);
            clearNumber.Replace(" ", string.Empty);

            //checking if the input is a number
            foreach (var s in clearNumber)
            {
                if (Char.IsDigit(s) != true)
                {
                    Console.WriteLine("Please enter a valid phone number!");
                    goto number;
                }
            }
            return clearNumber;
        }
    }
}