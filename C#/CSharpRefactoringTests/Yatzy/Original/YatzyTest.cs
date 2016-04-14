using NUnit.Framework;

namespace CSharpRefactoringTests.Yatzy.Original
{
    [TestFixture]
    public class YatzyTest
    {
        [Test]
        public void Chance_scores_sum_of_all_dice()
        {
            int expected = 15;
            int actual = CSharpRefactorings.Yatzy.Original.Yatzy.Chance(2, 3, 4, 5, 1);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(16, CSharpRefactorings.Yatzy.Original.Yatzy.Chance(3, 3, 4, 5, 1));
        }

        [Test]
        public void Yatzy_scores_50()
        {
            int expected = 50;
            int actual = CSharpRefactorings.Yatzy.Original.Yatzy.yatzy(4, 4, 4, 4, 4);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(50, CSharpRefactorings.Yatzy.Original.Yatzy.yatzy(6, 6, 6, 6, 6));
            Assert.AreEqual(0, CSharpRefactorings.Yatzy.Original.Yatzy.yatzy(6, 6, 6, 6, 3));
        }

        [Test]
        public void Test_1s()
        {
            Assert.IsTrue(CSharpRefactorings.Yatzy.Original.Yatzy.Ones(1, 2, 3, 4, 5) == 1);
            Assert.AreEqual(2, CSharpRefactorings.Yatzy.Original.Yatzy.Ones(1, 2, 1, 4, 5));
            Assert.AreEqual(0, CSharpRefactorings.Yatzy.Original.Yatzy.Ones(6, 2, 2, 4, 5));
            Assert.AreEqual(4, CSharpRefactorings.Yatzy.Original.Yatzy.Ones(1, 2, 1, 1, 1));
        }

        [Test]
        public void test_2s()
        {
            Assert.AreEqual(4, CSharpRefactorings.Yatzy.Original.Yatzy.Twos(1, 2, 3, 2, 6));
            Assert.AreEqual(10, CSharpRefactorings.Yatzy.Original.Yatzy.Twos(2, 2, 2, 2, 2));
        }

        [Test]
        public void test_threes()
        {
            Assert.AreEqual(6, CSharpRefactorings.Yatzy.Original.Yatzy.Threes(1, 2, 3, 2, 3));
            Assert.AreEqual(12, CSharpRefactorings.Yatzy.Original.Yatzy.Threes(2, 3, 3, 3, 3));
        }

        [Test]
        public void fours_test()
        {
            Assert.AreEqual(12, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 4, 4, 5, 5).Fours());
            Assert.AreEqual(8, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 4, 5, 5, 5).Fours());
            Assert.AreEqual(4, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 5, 5, 5, 5).Fours());
        }

        [Test]
        public void fives()
        {
            Assert.AreEqual(10, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 4, 4, 5, 5).Fives());
            Assert.AreEqual(15, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 4, 5, 5, 5).Fives());
            Assert.AreEqual(20, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 5, 5, 5, 5).Fives());
        }

        [Test]
        public void sixes_test()
        {
            Assert.AreEqual(0, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 4, 4, 5, 5).sixes());
            Assert.AreEqual(6, new CSharpRefactorings.Yatzy.Original.Yatzy(4, 4, 6, 5, 5).sixes());
            Assert.AreEqual(18, new CSharpRefactorings.Yatzy.Original.Yatzy(6, 5, 6, 6, 5).sixes());
        }

        [Test]
        public void one_pair()
        {
            Assert.AreEqual(6, CSharpRefactorings.Yatzy.Original.Yatzy.ScorePair(3, 4, 3, 5, 6));
            Assert.AreEqual(10, CSharpRefactorings.Yatzy.Original.Yatzy.ScorePair(5, 3, 3, 3, 5));
            Assert.AreEqual(12, CSharpRefactorings.Yatzy.Original.Yatzy.ScorePair(5, 3, 6, 6, 5));
        }

        [Test]
        public void two_Pair()
        {
            Assert.AreEqual(16, CSharpRefactorings.Yatzy.Original.Yatzy.TwoPair(3, 3, 5, 4, 5));
            Assert.AreEqual(16, CSharpRefactorings.Yatzy.Original.Yatzy.TwoPair(3, 3, 5, 5, 5));
        }

        [Test]
        public void three_of_a_kind()
        {
            Assert.AreEqual(9, CSharpRefactorings.Yatzy.Original.Yatzy.ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.AreEqual(15, CSharpRefactorings.Yatzy.Original.Yatzy.ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.AreEqual(9, CSharpRefactorings.Yatzy.Original.Yatzy.ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Test]
        public void four_of_a_knd()
        {
            Assert.AreEqual(12, CSharpRefactorings.Yatzy.Original.Yatzy.FourOfAKind(3, 3, 3, 3, 5));
            Assert.AreEqual(20, CSharpRefactorings.Yatzy.Original.Yatzy.FourOfAKind(5, 5, 5, 4, 5));
            Assert.AreEqual(12, CSharpRefactorings.Yatzy.Original.Yatzy.FourOfAKind(3, 3, 3, 3, 3));
        }

        [Test]
        public void smallStraight()
        {
            Assert.AreEqual(15, CSharpRefactorings.Yatzy.Original.Yatzy.SmallStraight(1, 2, 3, 4, 5));
            Assert.AreEqual(15, CSharpRefactorings.Yatzy.Original.Yatzy.SmallStraight(2, 3, 4, 5, 1));
            Assert.AreEqual(0, CSharpRefactorings.Yatzy.Original.Yatzy.SmallStraight(1, 2, 2, 4, 5));
        }

        [Test]
        public void largeStraight()
        {
            Assert.AreEqual(20, CSharpRefactorings.Yatzy.Original.Yatzy.LargeStraight(6, 2, 3, 4, 5));
            Assert.AreEqual(20, CSharpRefactorings.Yatzy.Original.Yatzy.LargeStraight(2, 3, 4, 5, 6));
            Assert.AreEqual(0, CSharpRefactorings.Yatzy.Original.Yatzy.LargeStraight(1, 2, 2, 4, 5));
        }

        [Test]
        public void fullHouse()
        {
            Assert.AreEqual(18, CSharpRefactorings.Yatzy.Original.Yatzy.FullHouse(6, 2, 2, 2, 6));
            Assert.AreEqual(0, CSharpRefactorings.Yatzy.Original.Yatzy.FullHouse(2, 3, 4, 5, 6));
        }
    }
}
