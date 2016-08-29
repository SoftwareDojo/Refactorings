using System;

namespace CSharpRefactorings.AlphaNum.Refactored
{
    internal class AlphaNumericString
    {
        private int m_Index;
        private string m_Source;

        internal int Offset { get; private set; }
        internal int OriginalLength { get; private set; }

        internal int ReadToken()
        {
            if (!HasNextToken) return -1;

            int length = m_Source.Length;
            int numIndex;
            int pos = m_Index + 1;
                        
            if (IsNumeric)
            {
                while ((pos < length) && IsNumericChar(pos)) pos++;
                
                OriginalLength = pos - m_Index;
                if (!IsZero(m_Index)) return SavePos(pos);
                
                numIndex = m_Index + 1;
                while (numIndex < pos)
                {
                    if (!IsZero(numIndex)) break;
                    numIndex++;
                }
            }
            else
            {
                while ((pos < length) && !IsNumericChar(pos)) pos++;
                return SavePos(pos);
            }

            m_Index = (numIndex < pos) ? numIndex : (pos - 1);
            return SavePos(pos);
        }

        internal bool HasNextToken => m_Index < m_Source.Length;

        internal bool IsNumeric => IsNumericChar(m_Index);

        internal void SetSource(string source)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException(nameof(source));

            m_Source = source;
            m_Index = 0;
        }

        private bool IsNumericChar(int index)
        {
            return m_Source[index] >= 48 && m_Source[index] <= 57;
        }

        private bool IsZero(int index)
        {
            return m_Source[index] == 48;
        }

        private int SavePos(int pos)
        {
            var result = pos - m_Index;
            Offset = m_Index;
            m_Index = pos;
            return result;
        }
    }
}