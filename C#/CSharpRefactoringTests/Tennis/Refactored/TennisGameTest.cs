using System;
using CSharpRefactorings.Tennis.Refactored;
using NUnit.Framework;

namespace CSharpRefactoringTests.Tennis.Refactored
{
    public class Names
    {
        public const string Player1 = "Ernie";
        public const string Player2 = "Bert";
    }

    [TestFixture(0, 0, "Love-All")]
    [TestFixture(1, 1, "Fifteen-All")]
    [TestFixture(2, 2, "Thirty-All")]
    [TestFixture(3, 3, "Forty-All")]
    [TestFixture(4, 4, "Deuce")]
    [TestFixture(6, 6, "Deuce")]
    [TestFixture(1, 0, "Fifteen-Love")]
    [TestFixture(0, 1, "Love-Fifteen")]
    [TestFixture(2, 0, "Thirty-Love")]
    [TestFixture(0, 2, "Love-Thirty")]
    [TestFixture(3, 0, "Forty-Love")]
    [TestFixture(0, 3, "Love-Forty")]
    [TestFixture(4, 0, "Win for "+ Names.Player1)]
    [TestFixture(0, 4, "Win for " + Names.Player2)]
    [TestFixture(2, 1, "Thirty-Fifteen")]
    [TestFixture(1, 2, "Fifteen-Thirty")]
    [TestFixture(3, 1, "Forty-Fifteen")]
    [TestFixture(1, 3, "Fifteen-Forty")]
    [TestFixture(4, 1, "Win for " + Names.Player1)]
    [TestFixture(1, 4, "Win for " + Names.Player2)]
    [TestFixture(3, 2, "Forty-Thirty")]
    [TestFixture(2, 3, "Thirty-Forty")]
    [TestFixture(4, 2, "Win for " + Names.Player1)]
    [TestFixture(2, 4, "Win for " + Names.Player2)]
    [TestFixture(4, 3, "Advantage " + Names.Player1)]
    [TestFixture(3, 4, "Advantage " + Names.Player2)]
    [TestFixture(5, 4, "Advantage " + Names.Player1)]
    [TestFixture(4, 5, "Advantage " + Names.Player2)]
    [TestFixture(15, 14, "Advantage " + Names.Player1)]
    [TestFixture(14, 15, "Advantage " + Names.Player2)]
    [TestFixture(6, 4, "Win for " + Names.Player1)]
    [TestFixture(4, 6, "Win for " + Names.Player2)]
    [TestFixture(16, 14, "Win for " + Names.Player1)]
    [TestFixture(14, 16, "Win for " + Names.Player2)]
    public class TennisTest
    {
        private readonly int m_Player1Score;
        private readonly int m_Player2Score;
        private readonly string m_ExpectedScore;

        public TennisTest(int player1Score, int player2Score, string expectedScore)
        {
            m_Player1Score = player1Score;
            m_Player2Score = player2Score;
            m_ExpectedScore = expectedScore;
        }

        [Test]
        public void CheckTennisGame1()
        {
            TennisGame1 game = new TennisGame1(Names.Player1, Names.Player2);
            CheckAllScores(game);
        }

        //[Test]
        //public void checkTennisGame2()
        //{
        //    TennisGame2 game = new TennisGame2("player1", "player2");
        //    checkAllScores(game);
        //}

        //[Test]
        //public void checkTennisGame3()
        //{
        //    TennisGame3 game = new TennisGame3("player1", "player2");
        //    checkAllScores(game);
        //}

        public void CheckAllScores(ITennisGame game)
        {
            int highestScore = Math.Max(m_Player1Score, m_Player2Score);
            for (int i = 0; i < highestScore; i++)
            {
                if (i < m_Player1Score) game.WonPoint(Names.Player1);
                if (i < m_Player2Score) game.WonPoint(Names.Player2);
            }
            Assert.AreEqual(m_ExpectedScore, game.GetScore());
        }

    }
}
