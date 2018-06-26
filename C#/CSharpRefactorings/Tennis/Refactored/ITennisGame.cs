namespace CSharpRefactorings.Tennis.Refactored
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}
