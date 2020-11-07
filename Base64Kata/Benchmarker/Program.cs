using Base64Kata;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarker
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }

    public class Benchmarker
    {
        string testString = "øgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjgøgjksøcjgsødfkljgsødlkfjgøsdlkfjgøsdlkfjgøsdlkfgjøsdlfkjgøsldkfgøsldkfjgølsdkfjgølsdkfjgølskdjfgølskdjfgølskdjfgøsldkfjgøsldkfjgøsldkjfgølskdfjg";

        [Benchmark]
        public void Testv1()
        {
            var actual = Base64Konverter.ToBase64v2(testString);
        }

        [Benchmark]
        public void testv2()
        {
            var actual = Base64Konverter.ToBase64v2(testString);
        }

        [Benchmark]
        public void testv3()
        {
            var actual = Base64Konverter.ToBase64v3(testString);
        }
    }
}
