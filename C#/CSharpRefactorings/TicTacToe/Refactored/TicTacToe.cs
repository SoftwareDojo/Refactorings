namespace CSharpRefactorings.TicTacToe.Refactored
{
    public class Program
    {
        private const char s_Empty = ' ';
        private const char s_X = 'X';
        private const char s_Y = 'Y';
        private readonly IUserInterface m_Ui;
        private readonly char[] m_Box;
        private bool m_IsY;

        public Program(IUserInterface ui)
        {
            m_Ui = ui;
            m_Box = new [] {s_Empty, s_Empty, s_Empty, s_Empty, s_Empty, s_Empty, s_Empty, s_Empty, s_Empty};
        }

        public void Start()
        {
            m_Ui.PrintStart();

            var moveCount = 0;
            m_IsY = true;

            while (true)
            { 
                if (moveCount >= 9)
                {
                    m_Ui.PrintDraw(m_Box);
                    break;
                }

                if (!PlayerMove()) continue;
                moveCount++;

                if (CheckWin())
                {
                    m_Ui.PrintWin(m_Box, GetCurrentPlayer());
                    break;
                }

                m_IsY = !m_IsY;
            }
        }

        private bool PlayerMove()
        {
            char player = GetCurrentPlayer();
            var input = m_Ui.GetInput(m_Box, player);

            if (input <= 0 || input > 9)
            {
                m_Ui.PrintWrongSelection();
                return false;
            }

            if (m_Box[input - 1] != s_Empty)
            {
                m_Ui.PrintNotVacant();
                return false;
            }

            m_Box[input - 1] = player;
            return true;
        }

        private bool CheckWin()
        {
            var player = GetCurrentPlayer();

            if (AreEqual(player, 0, 1, 2)) return true;
            if (AreEqual(player, 3, 4, 5)) return true;
            if (AreEqual(player, 6, 7, 8)) return true;
            if (AreEqual(player, 0, 3, 6)) return true;
            if (AreEqual(player, 1, 4, 7)) return true;
            if (AreEqual(player, 2, 5, 8)) return true;
            if (AreEqual(player, 0, 4, 8)) return true;
            if (AreEqual(player, 2, 4, 6)) return true;

            return false;
        }

        private bool AreEqual(char value, int index1, int index2, int index3)
        {
            return m_Box[index1] == value && m_Box[index2] == value && m_Box[index3] == value;
        }

        private char GetCurrentPlayer()
        {
            return m_IsY ? s_X : s_Y;
        }
    }
}
