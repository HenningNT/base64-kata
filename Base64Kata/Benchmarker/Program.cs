using Base64Kata;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace Benchmarker
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }

    [MemoryDiagnoser]
    public class Benchmarker
    {
        string testString = "øgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjg";

        [Benchmark]
        public void Testv1()
        {
            var actual = Base64Konverter.ToBase64v2(testString);
        }

        [Benchmark]
        public void Testv2()
        {
            var actual = Base64Konverter.ToBase64v2(testString);
        }

        [Benchmark]
        public void Testv3()
        {
            var actual = Base64Konverter.ToBase64v3(testString);
        }

        [Benchmark]
        public void Testv4()
        {
            var actual = Base64Konverter.ToBase64v4(testString);
        }

        [Benchmark]
        public void Testv5()
        {
            var actual = Base64Konverter.ToBase64v5(testString);
        }

        [Benchmark]
        public void Testv3_2()
        {
            var actual = Base64Konverter.ToBase64v3_2(testString);
        }

        [Benchmark]
        public void Test_ConvertToBase64()
        {
            var actual = Convert.ToBase64String(Encoding.UTF8.GetBytes(testString));
        }
    }
}
