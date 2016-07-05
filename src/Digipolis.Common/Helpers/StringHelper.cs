using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Digipolis.Common.Helpers
{
    public class StringHelper
    {

        /// <summary>
        /// Returns a string value that contains the contents of the given string or specifies whether the string is empty or null.
        /// </summary>
        /// <param name="input">A string.</param>
        /// <returns>null, empty or the content of the string.</returns>
        public static string GetValidString(string input)
        {
            if (input == null) return "null";
            if (input.Trim() == String.Empty) return "empty";
            return input;
        }

        /// <summary>
        /// Returns the ToString() value of the given object or null if the object is null.
        /// </summary>
        /// <param name="input">An object.</param>
        /// <returns>null or ToString() of the object.</returns>
        public static string GetValidString(object input)
        {
            return input == null ? "null" : input.ToString();
        }

        /// <summary>
        /// Geeft de input string terug zonder whitespace karakters.
        /// </summary>
        /// <param name="input">Een string.</param>
        /// <returns>The input string without whitespace characters, null if the input string is null.</returns>
        public static string RemoveWhitespaces(string input)
        {
            if (input == null) return null;
            return Regex.Replace(input, @"\s+", String.Empty);
        }

        /// <summary>
        /// Returns null (= default) if the input value is null and the trimmed value if they are not null.
        /// </summary>
        /// <param name="input">A string value.</param>
        /// <returns>NULL if the given value is null and the trimmed value if they are not null.</returns>
        public static string TrimOrDefault(string input)
        {
            return input == null ? null : input.Trim();
        }

        /// <summary>
        /// Returns the given string, starting with a lowercase letter.
        /// </summary>
        /// <param name="input">The string that needs to be converted to camel case.</param>
        /// <returns>The given string, starting with a lowercase letter.</returns>
        public static string ToCamelCase(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return input;

            if (input.Length < 2)
            {
                if (!Char.IsUpper(input[0]))
                {
                    return input;
                }
                else
                {
                    return Camelize(input);
                }
            }

            var clean = Regex.Replace(input, @"[\W]", " ");

            var words = clean.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            var result = "";
            for (int i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                if (i == 0)
                    result += Camelize(currentWord);
                else
                    result += Pascalize(currentWord);

                if (currentWord.Length > 1) result += currentWord.Substring(1);
            }

            return result;
        }

        /// <summary>
        /// Returns the given string, beginning with an uppercase letter.
        /// </summary>
        /// <param name="input">The string that needs to be converted to Pascal case.</param>
        /// <returns>The given string, starting with an uppercase letter.</returns>
        public static string ToPascalCase(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return input;

            if (input.Length < 2)
            {
                if (!Char.IsLower(input[0]))
                {
                    return input;
                }
                else
                {
                    return Pascalize(input);
                }
            }

            var clean = Regex.Replace(input, @"[\W]", " ");

            var words = clean.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            var result = "";
            for (int i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                if (i == 0)
                    result += Pascalize(currentWord);
                else
                    result += Pascalize(currentWord);

                if (currentWord.Length > 1) result += currentWord.Substring(1);
            }

            return result;
        }

        /// <summary>
        /// Returns a decoded string of the base64 input string.
        /// </summary>
        /// <param name="input">A base64 string.</param>
        /// <returns>The coded base64 string.</returns>
        public static string FromBase64(string input)
        {
            if (input == null) return null;
            var bytes = Convert.FromBase64String(input);
            var output = Encoding.UTF8.GetString(bytes);
            return output;
        }

        /// <summary>
        /// Returns the given string in base64 format.
        /// </summary>
        /// <param name="input">The string to be converted to base64.</param>
        /// <returns>The base64 string.</returns>
        public static string ToBase64(string input)
        {
            if (input == null) return null;
            var bytes = Encoding.UTF8.GetBytes(input);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        private static string Camelize(string input)
        {
            return Char.ToLowerInvariant(input[0]).ToString();
        }

        private static string Pascalize(string input)
        {
            return Char.ToUpperInvariant(input[0]).ToString();
        }
    }

}