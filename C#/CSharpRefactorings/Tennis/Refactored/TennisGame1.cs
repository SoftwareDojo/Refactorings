using System.Collections.Generic;

namespace CSharpRefactorings.Tennis.Refactored
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Dictionary<int, string> m_Score;

        private int m_Score1;
        private int m_Score2;
        private readonly string m_Player1Name;
        private readonly string m_Player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            m_Score = new Dictionary<int, string> {{0, "Love"}, {1, "Fifteen"}, {2, "Thirty"}, {3, "Forty"}};

            m_Player1Name = player1Name;
            m_Player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == m_Player1Name) m_Score1++;
            else if (playerName == m_Player2Name) m_Score2++;
        }

        public string GetScore()
        {
            if (m_Score1 < 4 && m_Score2 < 4)
            {
                var score = m_Score[m_Score1] + "-";
                if (m_Score1 == m_Score2) return score + "All";
                return score + m_Score[m_Score2];
            }

            var diff = m_Score1 - m_Score2;
            if (diff == 0) return "Deuce";
            if (diff == 1) return "Advantage " + m_Player1Name;
            if (diff == -1) return "Advantage " + m_Player2Name;
            if (diff >= 2) return "Win for " + m_Player1Name;
            if (diff <= -2) return "Win for " + m_Player2Name;

            return string.Empty;
        }
    }
}
