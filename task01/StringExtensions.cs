using System;
using System.Collections.Generic;

namespace task01
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            string stringWithLower = input.ToLower();
            List<char> ListChars = new List<char>();
            foreach (char c in stringWithLower)
            {
                if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c))
                {
                    ListChars.Add(c);
                }
            }
            if (ListChars.Count == 0)
            {
                return false;
            }
            string stringChars = new string(ListChars.ToArray());
            char[] reversedArray = stringChars.ToArray();
            Array.Reverse(reversedArray);
            string reversedString = new string(reversedArray);
            return cleanedString == reversedString;
        }
    }
}