using System;

namespace ContactsApp
{
    /// <summary>
    /// Checking data for valid
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks for the entered text, as well as
        /// to a length that must be no more than 50 characters.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="length">Maximum line length.</param>
        /// <param name="field">Field name</param>
        public static void AssertStringOnLength(string text, int length, string field)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($@"You entered an empty line in the {field}");
            }

            if (text.Length > length)
            {
                throw new ArgumentException($"Length {field} should be less " +
                                            $"{length} letters.");
            }
        }

        /// <summary>
        /// Checking a string for digits
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <param name="field"></param>
        public static void AssertStringOnNumbers(string text, string field)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text, i))
                {
                    throw new ArgumentException($"String {field} should not contain numbers");
                }
            }
        }
        /// <summary>
        /// The first character converts to uppercase, the rest to lowercase.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns></returns>
        public static string ToNameFormat(string text)
        {
            text.ToLower();
            text = char.ToUpper(text[0]) + text.Substring(1);
            return text;
        }

    }
}