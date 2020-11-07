using System;
using System.Linq;

namespace Base64Kata
{
    public class Base64Konverter
    {
        private static readonly char[] lookup= new char[64]
          { 'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'};

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

                result[resultIndex++] = lookup[(concated >> 18) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 12) & 0x3F];
                result[resultIndex++] = lookup[(concated >>  6) & 0x3F];
                result[resultIndex++] = lookup[ concated        & 0x3F];

                remaining -= 3;
                inputIndex += 3;
            }

            if (remaining == 2)
            {
                // Pad the last char
                // Convert last group
                var slice = span.Slice(inputIndex, 2);
                var concated = slice[0] << 16 | slice[1] << 8;
                
                result[resultIndex++] = lookup[(concated >> 18) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 12) & 0x3F];
                result[resultIndex++] = lookup[(concated >>  6) & 0x3F];
                result[resultIndex]   = '=';
            }

            if (remaining == 1)
            {
                // Pad the last two chars
                // Convert last group
                var slice = span.Slice(inputIndex, 1);
                var concated = slice[0] << 16;

                result[resultIndex++] = lookup[(concated >> 18) & 0x3F];
                result[resultIndex++] = lookup[(concated >> 12) & 0x3F];
                result[resultIndex++] = '=';
                result[resultIndex]   = '=';
            }

            return new string(result);
        }
    }
}
