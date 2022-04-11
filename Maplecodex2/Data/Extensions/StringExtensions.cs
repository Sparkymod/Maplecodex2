using System.Text.RegularExpressions;

namespace Maplecodex2.Data.Extensions
{
    public static class StringExtensions
    {
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
            if (input is null || comparer is null)
            {
                return false;
            }

            string newInput = SpecialRegex.Replace(input.ToLowerInvariant(), "").TrimEnd();
            string newComparer = SpecialRegex.Replace(comparer.ToLowerInvariant(), "").TrimEnd();

            return newInput.Contains(newComparer);
        }

        /// <summary>
        /// Compare if an int contains a number or is equal to the number.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="comprare"></param>
        /// <returns>true if contains the number; otherwise, false.</returns>
        public static bool CompareWith(this int input, int comprare)
        {
            if (input is 0 || comprare is 0)
            {
                return false;
            }
            if (input == comprare)
            {
                return true;
            }

            return input.ToString().Contains(comprare.ToString());
        }
    }
}
