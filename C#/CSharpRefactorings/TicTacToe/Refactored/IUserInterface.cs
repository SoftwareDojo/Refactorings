namespace CSharpRefactorings.TicTacToe.Refactored
{
    public interface IUserInterface
    {
        int GetInput(char[] box, char player);
        void PrintStart();
        void PrintNotVacant();
        void PrintWrongSelection();
        void PrintWin(char[] box, char player);
        void PrintDraw(char[] box);
    }
}