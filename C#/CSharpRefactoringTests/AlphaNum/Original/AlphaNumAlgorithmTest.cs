using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CSharpRefactorings.AlphaNum.Original;
using NUnit.Framework;

namespace CSharpRefactoringTests.AlphaNum.Original
{
    [TestFixture]
    public class AlphaNumAlgorithmTest
    {
        [Test]
        public void Compare()
        {
            // arrange
            var comparer = new AlphaNumAlgorithm(null);
            List<string> actual = new List<string>{"z1.txt", "z10.txt", "z100.txt", "z102.txt", "z11.txt", "z19.txt", "z2.txt", "z20.txt", "z9.txt" };
            List<string> expected = new List<string>{"z1.txt", "z2.txt", "z9.txt", "z10.txt", "z11.txt", "z19.txt", "z20.txt", "z100.txt", "z102.txt"
            };

            // act
            var watch = new Stopwatch();
            watch.Start();

            actual.Sort(comparer);

            watch.Stop();

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
            Console.WriteLine($"Performance = {watch.ElapsedTicks}");
        }
    }
}
