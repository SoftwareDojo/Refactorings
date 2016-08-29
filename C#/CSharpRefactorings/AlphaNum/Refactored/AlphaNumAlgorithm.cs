using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace CSharpRefactorings.AlphaNum.Refactored
{
    public class AlphaNumAlgorithm : IComparer<string>, IComparer
    {
        private readonly CompareInfo m_CompareInfo;
        private readonly CompareOptions m_CompareOptions;
        private readonly AlphaNumericString m_NumericStringX = new AlphaNumericString();
        private readonly AlphaNumericString m_NumericStringY = new AlphaNumericString();

        public AlphaNumAlgorithm(CultureInfo current)
        {
            m_CompareInfo = current?.CompareInfo ?? CultureInfo.CurrentCulture.CompareInfo;
            m_CompareOptions = CompareOptions.IgnoreCase;
        }

        public int Compare(object x, object y)
        {
            return Compare((string)x, (string)y);
        }

        public int Compare(string x, string y)
        {
            m_NumericStringX.SetSource(x);
            m_NumericStringY.SetSource(y);

            int result = 0;
            while (result == 0)
            {
                int hasNextResult;
                if (!HasNextToken(out hasNextResult)) return hasNextResult;

                bool bothNumeric = AreBothNumeric();
                bool oneNumeric = false;
                if (!bothNumeric) oneNumeric = IsOneNumeric(ref result);
                if (oneNumeric) continue;

                int xNum = m_NumericStringX.ReadToken();
                int yNum = m_NumericStringY.ReadToken();

                if (!bothNumeric)
                {
                    result = m_CompareInfo.Compare(x, m_NumericStringX.Offset, xNum, y, m_NumericStringY.Offset, yNum,
                        m_CompareOptions);
                    continue;
                }

                int diffxy = xNum - yNum;
                if (diffxy != 0) return diffxy;

                if (xNum == 1)
                {
                    result = x[m_NumericStringX.Offset] - y[m_NumericStringY.Offset];
                }
                else
                {
                    int xOffset = m_NumericStringX.Offset;
                    int yOffset = m_NumericStringY.Offset;
                    for (int i = 0; i < xNum; i++)
                    {
                        result = x[xOffset] - y[yOffset];
                        if (result != 0) break;
                        
                        xOffset++;
                        yOffset++;
                    }
                }
                if (result == 0)
                {
                    result = -(m_NumericStringX.OriginalLength - m_NumericStringY.OriginalLength);
                }
            }

            return result;
        }

        private bool HasNextToken(out int result)
        {
            result = 0;
            bool xHasNextToken = m_NumericStringX.HasNextToken;
            bool yHasNextToken = m_NumericStringY.HasNextToken;
            if (xHasNextToken && yHasNextToken) return true;

            if (!xHasNextToken && !yHasNextToken) result = 0;
            if (!xHasNextToken && yHasNextToken) result = - 1;
            if (xHasNextToken && !yHasNextToken) result = 1;
                
            return false;
        }

        private bool AreBothNumeric()
        {
            return m_NumericStringX.IsNumeric && m_NumericStringY.IsNumeric;
        }

        private bool IsOneNumeric(ref int num)
        {
            if (m_NumericStringX.IsNumeric)
            {
                num = -1;
                return true;
            }
            if (m_NumericStringY.IsNumeric)
            {
                num = 1;
                return true;
            }
            return false;
        }
    }
}
