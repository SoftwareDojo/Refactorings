using System;

namespace CSharpRefactorings.Parrot.Refactored
{
    public class AfricanParrot : Parrot
    {
        private readonly int m_NumberOfCoconuts;

        public AfricanParrot(int numberOfCoconuts)
        {
            m_NumberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed()
        {
            return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * m_NumberOfCoconuts);
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }
    }
}
