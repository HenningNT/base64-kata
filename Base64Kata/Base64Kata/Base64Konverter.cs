using System;
using System.Linq;

namespace Base64Kata
{
    public class Base64Konverter
    {
        private static readonly char[] lookup;

        static Base64Konverter()
        {
            lookup = GenerateBase64LookupTable();
        }
        public static string ToBase64(in string theString)
        {
            var span = theString.AsSpan();
            var remaining = span.Length;
            var inputIndex = 0;
            var resultIndex = 0;

            // Create new array for result, adjust length for padding
            var resultLength = span.Length;
            if (span.Length % 3 == 1) resultLength += 2;
            if (span.Length % 3 == 2) resultLength += 1;
            var result = new char[resultLength * 8 / 6];

            while (remaining >= 3)
            {
                // Convert group
                var slice = span.Slice(inputIndex, 3);
                var concated = slice[0] << 16 | slice[1] << 8 | slice[2];

                result[resultIndex++] = lookup[(concated >> 3 * 6) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 2 * 6) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 1 * 6) & 0x3F];
                result[resultIndex++] = lookup[ concated           & 0x3F];

                remaining -= 3;
                inputIndex += 3;
            }

            if (remaining == 2)
            {
                // Pad the last char
                // Convert last group
                var slice = span.Slice(inputIndex, 2);
                var concated = slice[0] << 16 | slice[1] << 8;

                result[resultIndex++] = lookup[(concated >> 3 * 6) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 2 * 6) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 1 * 6) & 0x3F];
                result[resultIndex]   = '=';
            }

            if (remaining == 1)
            {
                // Pad the last two chars
                // Convert last group
                var slice = span.Slice(inputIndex, 1);
                var concated = slice[0] << 16;

                result[resultIndex++] = lookup[(concated >> 3 * 6) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 2 * 6) & 0x3F];
                result[resultIndex++] = '=';
                result[resultIndex]   = '=';
            }

            return new string(result);
        }

        /// <summary>Generate array with valid Base64 values (A-Z, a-z, 0-9 and +/)
        /// Thanks to Frode Hus https://github.com/FrodeHus/base64-kata/blob/2451df106f583f22c77a527f70f5d1e7fab7c391/Program.cs#L50
        /// </summary>
        private static char[] GenerateBase64LookupTable()
        {
            //generate array with A-Z, a-z, 0-9 and +/
            var uppercase = Enumerable.Range(65, 26).Select(c => Convert.ToChar(c));
            var lowercase = Enumerable.Range(97, 26).Select(c => Convert.ToChar(c));
            var numbers = Enumerable.Range(48, 10).Select(c => Convert.ToChar(c));
            var special = new[] { '+', '/' };
            return uppercase.Concat(lowercase).Concat(numbers).Concat(special).ToArray();
        }
    }
}
