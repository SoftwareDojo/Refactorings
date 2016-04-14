using System;

namespace CSharpRefactorings.Parrot.Refactored
{
    public class NorwegianBlueParrot : Parrot
    {
        private readonly double m_Voltage;
        private readonly bool m_IsNailed;

        public NorwegianBlueParrot(double voltage) : this(voltage, false)
        {
            
        }

        public NorwegianBlueParrot(bool isNailed) : this(0, isNailed)
        {
            
        }

        public NorwegianBlueParrot(double voltage, bool isNailed)
        {
            m_Voltage = voltage;
            m_IsNailed = isNailed;
        }

        public override double GetSpeed()
        {
            return (m_IsNailed) ? 0 : GetBaseSpeed(m_Voltage);
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }
    }
}
