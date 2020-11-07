using System;
using Xunit;
using System.Text;

namespace Base64Kata.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Unpadded()
        {
            var testString = "Hello Bouvet!!!";
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(testString));

            var actual = Base64Konverter.ToBase64(testString);

            Assert.Equal(expected, actual);
        }
    }
}
