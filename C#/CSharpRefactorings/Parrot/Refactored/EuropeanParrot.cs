namespace CSharpRefactorings.Parrot.Refactored
{
    public class EuropeanParrot : Parrot
    {
        public override double GetSpeed()
        {
            return GetBaseSpeed();
        }
    }
}
