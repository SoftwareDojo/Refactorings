using System;

namespace CSharpRefactorings.Parrot.Original
{
    public class Parrot
    {
        private ParrotTypeEnum m_Type;
        private int m_NumberOfCoconuts = 0;
        private double m_Voltage;
        private bool m_IsNailed;


        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            this.m_Type = type;
            this.m_NumberOfCoconuts = numberOfCoconuts;
            this.m_Voltage = voltage;
            this.m_IsNailed = isNailed;
        }

        public double GetSpeed()
        {
            switch (m_Type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return GetBaseSpeed();
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * m_NumberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return (m_IsNailed) ? 0 : GetBaseSpeed(m_Voltage);
            }
            throw new Exception("Should be unreachable");
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }

        private double GetBaseSpeed()
        {
            return 12.0;
        }
    }
}
