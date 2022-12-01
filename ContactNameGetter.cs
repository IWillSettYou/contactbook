using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Book
{
    class ContactNameGetter
    {
        public static string GetContactName()
        {
            Console.Write("Name:");
        name:
            var name = Console.ReadLine();


            if (name == null || name == String.Empty)
            {
                Console.WriteLine("Please enter a valid name!");

                goto name;
            }

            //trimming the name to a valid format
            char[] charsToTrim = { '+', '-', '/', '.', ',', '*', '-', '_', };

            var trimmedName = name.Trim().TrimEnd(charsToTrim).TrimStart(charsToTrim);
            var temporaryTrimmedName = trimmedName.Replace(" ", string.Empty);
            char[] nameInChars = temporaryTrimmedName.ToCharArray();

            foreach (char c in nameInChars)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Please enter a valid name!");
                    goto name;
                }
            }
            return trimmedName;
        }
    }
}