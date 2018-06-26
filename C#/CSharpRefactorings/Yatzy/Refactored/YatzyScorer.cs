using System;
using System.Linq;

namespace CSharpRefactorings.Yatzy.Refactored
{
    public static class YatzyScorer
    {
        private const int s_MinValue = 1;
        private const int s_MaxValue = 6;
        private const int s_DiceCount = 5;

        public static int Chance(int[] dice)
        {
            CheckDice(dice);
            return dice.Sum();
        }

        public static int Ones(int[] dice)
        {
            CheckDice(dice);
            return DiceCount(dice, 1);
        }

        public static int Twos(int[] dice)
        {
            CheckDice(dice);
            return DiceCount(dice, 2) * 2;
        }

        public static int Threes(int[] dice)
        {
            CheckDice(dice);
            return DiceCount(dice, 3) * 3;
        }

        public static int Fours(int[] dice)
        {
            CheckDice(dice);
            return DiceCount(dice, 4) * 4;
        }

        public static int Fives(int[] dice)
        {
            CheckDice(dice);
            return DiceCount(dice, 5) * 5;
        }

        public static int Sixes(int[] dice)
        {
            CheckDice(dice);
            return DiceCount(dice, 6) * 6;
        }

        public static int Yatzy(int[] dice)
        {
            CheckDice(dice);
            return MaxDiceCount(dice, s_DiceCount) > 0 ? 50 : 0;
        }

        public static int OnePair(int[] dice)
        {
            CheckDice(dice);
            return 2*MaxDiceCount(dice, 2);
        }

        public static int TwoPair(int[] dice)
        {
            CheckDice(dice);

            var sum = 0;
            for (var i = s_MaxValue; i >= s_MinValue; i--)
            {
                if (DiceCount(dice, i) < 2) continue;
                if (sum == 0) sum = 2*i;
                else return sum + 2*i;
            }

            return 0;
        }

        public static int ThreeOfAKind(int[] dice)
        {
            CheckDice(dice);
            return MaxDiceCount(dice, 3) * 3;
        }

        public static int FourOfAKind(int[] dice)
        {
            CheckDice(dice);
            return MaxDiceCount(dice, 4) * 4;
        }

        public static int SmallStraight(int[] dice)
        {
            CheckDice(dice);

            for (var i = s_MinValue; i < s_MaxValue; i++)
            {
                if (DiceCount(dice, i) != 1) return 0;
            }

            return 15;
        }

        public static int LargeStraight(int[] dice)
        {
            CheckDice(dice);

            for (var i = s_MaxValue; i > s_MinValue; i--)
            {
                if (DiceCount(dice, i) != 1) return 0;
            }

            return 20;
        }

        public static int FullHouse(int[] dice)
        {
            CheckDice(dice);

            var threeOfAKind = MaxDiceCount(dice, 3);
            if (threeOfAKind == 0) return 0;

            for (var i = s_MaxValue; i >= s_MinValue; i--)
            {
                if (i == threeOfAKind) continue;
                if (DiceCount(dice, i) == 2) return (2*i) + (3*threeOfAKind);
            }

            return 0;
        }

        private static int MaxDiceCount(int[] dice, int minCount)
        {
            for (var i = s_MaxValue; i >= s_MinValue; i--)
            {
                if (DiceCount(dice, i) >= minCount) return i;
            }

            return 0;
        }

        private static int DiceCount(int[] dice, int condition)
        {
            return dice.Count(d => d == condition);
        }

        private static void CheckDice(int[] dice)
        {
            if (dice == null) throw new ArgumentNullException(nameof(dice));
            if (dice.Length != s_DiceCount) throw new ArgumentException(nameof(dice));

            foreach (var value in dice)
            {
                if (value < s_MinValue || value > s_MaxValue) throw new ArgumentException(nameof(dice));
            }
        }
    }
}
