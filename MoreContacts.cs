using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Book
{
    public class MoreContacts
    {
        public static int ThereWeGoAgain(){

        input:
            var input = Console.ReadLine();

            if (input == null || input == String.Empty)
            {
                Console.WriteLine("Please enter one of the specified input above!");

                goto input;
            }

            //trimming the name to a valid format
            char[] charsToTrim = { '+', '-', '/', '.', ',', '*', '-', '_', };

            var trimmedInput = input.Trim().TrimEnd(charsToTrim).TrimStart(charsToTrim);
            var temporaryTrimmedInput = trimmedInput.Replace(" ", string.Empty);
            char[] inputInChars = temporaryTrimmedInput.ToCharArray();

            foreach (char c in inputInChars)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine("Please enter one of the specified input above!");
                    goto input;
                }
            }

            if(Convert.ToInt16(trimmedInput) == 1)
            {
                return 1;
            }
            Console.WriteLine("Closing session...\nPress any key to exit");

            Environment.Exit(0);
            return 0;
        }
    }
}
