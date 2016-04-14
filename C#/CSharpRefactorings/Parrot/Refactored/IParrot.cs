namespace CSharpRefactorings.Parrot.Refactored
{
    public interface IParrot
    {
        double GetSpeed();
    }

    public abstract class Parrot : IParrot
    {
        protected double GetBaseSpeed()
        {
            return 12.0;
        }

        public abstract double GetSpeed();

    }
}
