using System;
using Xunit;
using System.Text;

namespace Base64Kata.Tests
{
    public class UnitTestv5
    {
        [Fact]
        public void SingleLetter()
        {
            var testString = "o";
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(testString));

            var actual = Base64Konverter.ToBase64v5(testString);

            Assert.Equal(4, actual.Length);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoLetters()
        {
            var testString = "oo";
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(testString));

            var actual = Base64Konverter.ToBase64v5(testString);

            Assert.Equal(4, actual.Length);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TreeLetters()
        {
            var testString = "oOo";
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(testString));

            var actual = Base64Konverter.ToBase64v5(testString);

            Assert.Equal(4, actual.Length);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LongUnpaddedString()
        {
            var testString = "oooOOOoooOOO";
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(testString));

            var actual = Base64Konverter.ToBase64v5(testString);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LongPaddedString()
        {
            var testString = "Hello, Bouvet!";
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(testString));

            var actual = Base64Konverter.ToBase64v5(testString);

            Assert.Equal(expected, actual);
        }
    }
}
