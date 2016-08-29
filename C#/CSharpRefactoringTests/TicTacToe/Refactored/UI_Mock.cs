using System.Collections.Generic;
using CSharpRefactorings.TicTacToe.Refactored;

namespace CSharpRefactoringTests.TicTacToe.Refactored
{
    internal class UI_Mock : IUserInterface
    {
        private readonly int[] m_Input;
        private int m_Index;
        public IList<string> Messages { get; set; }

        public UI_Mock(int[] input)
        {
            m_Input = input;
            m_Index = 0;

            Messages = new List<string>();
        }

        private bool Acknowledge()
        {
            return true;
        }

        private void Print(string value)
        {
            Messages.Add(value);
        }

        public int GetInput(char[] box, char player)
        {
            PrintInput(box, player);

            int result = m_Input[m_Index];
            m_Index++;
            return result;
        }

        private void Clear()
        {

        }

        public void PrintStart()
        {
            Print(" -- Tic Tac Toe -- ");
            //Thread.Sleep(1200);
            Clear();
        }

        public void PrintNotVacant()
        {
            Print("");
            Print("Error: box not vacant!");
            Print("Press any key to try again..");
            Acknowledge();
        }

        public void PrintWrongSelection()
        {
            Print("Wrong selection entered!");
            Print("Press any key to try again..");
            Acknowledge();
        }

        public void PrintWin(char[] box, char player)
        {
            PrintBoard(box);

            Print("");
            Print(string.Format("The winner is {0}!", player));
            Acknowledge();
        }

        public void PrintDraw(char[] box)
        {
            PrintBoard(box);

            Print("");
            Print("No one won.");
            Acknowledge();
        }

        private void PrintInput(char[] box, char player)
        {
            PrintBoard(box);

            Print("");
            Print(string.Format("What box do you want to place {0} in? (1-9)", player));
            Print("> ");
        }

        private void PrintBoard(char[] box)
        {
            Clear();
            Print(string.Format(" {0} | {1} | {2} ", box[0], box[1], box[2]));
            Print(" --------- ");
            Print(string.Format(" {0} | {1} | {2} ", box[3], box[4], box[5]));
            Print(" --------- ");
            Print(string.Format(" {0} | {1} | {2} ", box[6], box[7], box[8]));
        }
    }
}