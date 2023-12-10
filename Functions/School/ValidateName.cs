using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL.Functions.School
{
    internal class ValidateName
    {
        public static string FormatName(string input, string name)
        {
            // Validate the user input
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2 || ContainsDigits(input))
            {
                Console.WriteLine($"\nInvalid {name}. Please enter characters only (minimum of 2). Press ENTER to try again.");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                return "invalid";
            }
            // Convert the first letter to uppercase and the rest to lowercase
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
        // Check if user input contains any digits
        static bool ContainsDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
