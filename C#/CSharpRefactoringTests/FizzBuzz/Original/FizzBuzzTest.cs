using NUnit.Framework;

namespace CSharpRefactoringTests.FizzBuzz.Original
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void DoFizzBuzzTest(int value, string expected)
        {
            // arrange
            // act
            string actual = CSharpRefactorings.FizzBuzz.Original.FizzBuzz.PrintFizzBuzz(value);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoRangeFizzBuzzTest()
        {
            // arrange
            string expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz 31 32 Fizz 34 Buzz Fizz 37 38 Fizz Buzz 41 Fizz 43 44 FizzBuzz 46 47 Fizz 49 Buzz Fizz 52 53 Fizz Buzz 56 Fizz 58 59 FizzBuzz 61 62 Fizz 64 Buzz Fizz 67 68 Fizz Buzz 71 Fizz 73 74 FizzBuzz 76 77 Fizz 79 Buzz Fizz 82 83 Fizz Buzz 86 Fizz 88 89 FizzBuzz 91 92 Fizz 94 Buzz Fizz 97 98 Fizz Buzz";

            // act
            string actual = CSharpRefactorings.FizzBuzz.Original.FizzBuzz.PrintFizzBuzz();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
