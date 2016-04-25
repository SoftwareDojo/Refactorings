using System;
using CSharpRefactorings.Yatzy.Refactored;
using NUnit.Framework;

namespace CSharpRefactoringTests.Yatzy.Refactored
{
    [TestFixture]
    public class YatzyScorerTest
    {
        [TestCase(new[] { 2, 3, 4, 5, 1 }, 15)]
        [TestCase(new[] { 3, 3, 4, 5, 1 }, 16)]
        public void Chance_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Chance);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new[] { 1, 2, 1, 4, 5 }, 2)]
        [TestCase(new[] { 6, 2, 2, 4, 5 }, 0)]
        [TestCase(new[] { 1, 2, 1, 1, 1 }, 4)]
        public void Ones_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Ones);
        }

        [TestCase(new[] { 1, 2, 3, 2, 6 }, 4)]
        [TestCase(new[] { 2, 2, 2, 2, 2 }, 10)]
        public void Twos_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Twos);
        }

        [TestCase(new[] { 1, 2, 3, 2, 3 }, 6)]
        [TestCase(new[] { 2, 3, 3, 3, 3 }, 12)]
        public void Threes_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Threes);
        }

        [TestCase(new[] { 4, 5, 5, 5, 5 }, 4)]
        [TestCase(new[] { 4, 4, 5, 5, 5 }, 8)]
        [TestCase(new[] { 4, 4, 4, 5, 5 }, 12)]
        public void Fours_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Fours);
        }

        [TestCase(new[] { 4, 4, 4, 5, 5 }, 10)]
        [TestCase(new[] { 4, 4, 5, 5, 5 }, 15)]
        [TestCase(new[] { 4, 5, 5, 5, 5 }, 20)]
        public void Fives_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Fives);
        }

        [TestCase(new[] { 4, 4, 4, 5, 5 }, 0)]
        [TestCase(new[] { 4, 4, 6, 5, 5 }, 6)]
        [TestCase(new[] { 6, 5, 6, 6, 5 }, 18)]
        public void Sixes_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Sixes);
        }

        [TestCase(new[] { 6, 6, 6, 6, 3 }, 0)]
        [TestCase(new[] { 4, 4, 4, 4, 4 }, 50)]
        [TestCase(new[] { 6, 6, 6, 6, 6 }, 50)]
        public void Yatzy_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.Yatzy);
        }

        [TestCase(new[] { 3, 4, 2, 5, 6 }, 0)]
        [TestCase(new[] { 3, 4, 3, 5, 6 }, 6)]
        [TestCase(new[] { 5, 3, 3, 3, 5 }, 10)]
        [TestCase(new[] { 5, 3, 6, 6, 5 }, 12)]
        [TestCase(new[] { 6, 6, 6, 6, 5 }, 12)]
        public void OnePair_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.OnePair);
        }

        [TestCase(new[] { 3, 4, 2, 5, 5 }, 0)]
        [TestCase(new[] { 3, 3, 5, 5, 5 }, 16)]
        [TestCase(new[] { 3, 3, 5, 4, 5 }, 16)]
        public void TwoPair_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.TwoPair);
        }

        [TestCase(new[] { 3, 3, 3, 4, 5 }, 9)]
        [TestCase(new[] { 3, 3, 3, 3, 5 }, 9)]
        [TestCase(new[] { 5, 3, 5, 4, 5 }, 15)]
        public void ThreeOfAKind_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.ThreeOfAKind);
        }

        [TestCase(new[] { 3, 3, 3, 3, 5 }, 12)]
        [TestCase(new[] { 3, 3, 3, 3, 3 }, 12)]
        [TestCase(new[] { 5, 5, 5, 4, 5 }, 20)]
        public void FourOfAKind_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.FourOfAKind);
        }

        [TestCase(new[] { 1, 2, 2, 4, 5 }, 0)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 15)]
        [TestCase(new[] { 2, 3, 4, 5, 1 }, 15)]
        public void SmallStraight_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.SmallStraight);
        }

        [TestCase(new[] { 1, 2, 2, 4, 5 }, 0)]
        [TestCase(new[] { 2, 3, 4, 5, 6 }, 20)]
        [TestCase(new[] { 6, 2, 3, 4, 5 }, 20)]
        public void LargeStraight_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.LargeStraight);
        }

        [TestCase(new[] { 2, 3, 4, 5, 6 }, 0)]
        [TestCase(new[] { 5, 5, 5, 5, 6 }, 0)]
        [TestCase(new[] { 6, 2, 2, 2, 6 }, 18)]
        public void FullHouse_score(int[] dice, int expected)
        {
            AreEqual(dice, expected, YatzyScorer.FullHouse);
        }

        private void AreEqual(int[] dice, int expected, Func<int[], int> scoreAction)
        {
            // act
            int actual = scoreAction(dice);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
