/// @Author: Sparkymod
/// **
/// @Github: @sparkymod
/// **
using System.Text.RegularExpressions;

namespace Maplecodex2.Data.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Regex to everythin.
        /// </summary>
        private static readonly Regex AlphaDigitSpecialRegex = new("[a-zA-Z0-9!@#$&()\\-`.+,/\"]*");

        /// <summary>
        /// Regex to verify special characters.
        /// </summary>
        private static readonly Regex SpecialRegex = new("[!@#$&()\\-`.+,/\"]*");

        /// <summary>
        /// Compare if a string contains SpecialCharacters and remove it, then compare if contains any char on this string.
        /// </summary>
        /// <param name="input">String to check.</param>
        /// <param name="comparer">String that will be compared.</param>
        /// <returns>true if string contains the input string; otherwise, false.</returns>
        public static bool CompareWith(this string input, string comparer)
        {
            if (input == null || comparer == null) 
            {  
                return false; 
            }

            string newInput = SpecialRegex.Replace(input.ToLowerInvariant(), "");
            string newComparer = SpecialRegex.Replace(comparer.ToLowerInvariant(), "");

            if (newInput.Contains(newComparer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compare if an int contains a number or is equal to the number.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="comprare"></param>
        /// <returns>true if contains the number; otherwise, false.</returns>
        public static bool CompareWith(this int input, int comprare)
        {
            if (input == 0 || comprare == 0)
            {
                return false;
            }
            if (input == comprare)
            {
                return true;
            }
            if (input.ToString().Contains(comprare.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
