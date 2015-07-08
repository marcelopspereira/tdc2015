using System;
using System.Text.RegularExpressions;

namespace Store.Common.Validation
{
    public static class AssertionConcern
    {
        public static void AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;

            if (length < minimum || length > maximum) 
				throw new ArgumentException(message);
        }

        public static void AssertMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue)) 
				throw new ArgumentException(message);
        }

        public static void AssertNotEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue)) 
				throw new ArgumentException(message);
        }

        public static void AssertNotNull(object object1, string message)
        {
            if (object1 == null) 
				throw new ArgumentException(message);
        }

        public static void AssertTrue(bool boolValue, string message)
        {
            if (!boolValue) 
				throw new ArgumentException(message);
        }

        public static void AssertAreEquals(string value, string match, string message)
        {
            if (!(value == match)) 
				throw new ArgumentException(message);
        }
        
        public static void AssertNotZeroOrNegative(int value, string message)
        {
            if (value == 0 || value < 0) 
				throw new ArgumentException(message);
        }        
    }
}
