using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Book
{
    class ContactNameOfMotherGetter
    {
        public static string GetContactMotherName()
        {
            Console.Write("Mother's name:");
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
                    Console.WriteLine("Please enter a valid name of your mother!");
                goto name;
                }
            }
            return trimmedName;
        }
    }
}