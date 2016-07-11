using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace CSharpRefactorings.AlphaNum.Original
{
    public class AlphaNumAlgorithm : IComparer<string>, IComparer
    {
        private CompareInfo m_CompareInfo;
        private System.Globalization.CompareOptions m_CompareOptions;
        private AlphaNumericString m_NumericStringX = new AlphaNumericString();
        private AlphaNumericString m_NumericStringY = new AlphaNumericString();

        public AlphaNumAlgorithm(CultureInfo current)
        {
            if (current != null)
            {
                this.m_CompareInfo = current.CompareInfo;
            }
            else
            {
                this.m_CompareInfo = CultureInfo.CurrentCulture.CompareInfo;
            }
            this.m_CompareOptions = System.Globalization.CompareOptions.IgnoreCase;
        }

        public int Compare(object x, object y)
        {
            return this.Compare((string)x, (string)y);
        }

        public int Compare(string x, string y)
        {
            this.m_NumericStringX.Source = x;
            this.m_NumericStringY.Source = y;
            int num = 0;
            bool flag = true;
            while (num == 0)
            {
                bool hasNextToken = this.m_NumericStringX.HasNextToken;
                bool flag3 = this.m_NumericStringY.HasNextToken;
                if (!hasNextToken || !flag3)
                {
                    if (!hasNextToken && !flag3)
                    {
                        return 0;
                    }
                    if (!hasNextToken && flag3)
                    {
                        return -1;
                    }
                    if (hasNextToken && !flag3)
                    {
                        num = 1;
                    }
                    return num;
                }
                bool flag4 = false;
                bool flag5 = false;
                if (flag)
                {
                    flag = false;
                    if (this.m_NumericStringX.IsNumeric && this.m_NumericStringY.IsNumeric)
                    {
                        flag5 = true;
                    }
                }
                else if (this.m_NumericStringX.IsNumeric)
                {
                    if (this.m_NumericStringY.IsNumeric)
                    {
                        flag5 = true;
                    }
                    else
                    {
                        num = -1;
                        flag4 = true;
                    }
                }
                else if (this.m_NumericStringY.IsNumeric)
                {
                    num = 1;
                    flag4 = true;
                }
                if (!flag4)
                {
                    int num2 = this.m_NumericStringX.ReadToken();
                    int num3 = this.m_NumericStringY.ReadToken();
                    if (flag5)
                    {
                        int num4 = num2 - num3;
                        if (num4 == 0)
                        {
                            if (num2 == 1)
                            {
                                num = x[this.m_NumericStringX.Offset] - y[this.m_NumericStringY.Offset];
                            }
                            else
                            {
                                int offset = this.m_NumericStringX.Offset;
                                int num6 = this.m_NumericStringY.Offset;
                                for (int i = 0; i < num2; i++)
                                {
                                    num = this.m_NumericStringX.Source[offset] - this.m_NumericStringY.Source[num6];
                                    if (num != 0)
                                    {
                                        break;
                                    }
                                    offset++;
                                    num6++;
                                }
                            }
                            if (num == 0)
                            {
                                num = -(this.m_NumericStringX.OriginalLength - this.m_NumericStringY.OriginalLength);
                            }
                            continue;
                        }
                        num = num4;
                        continue;
                    }
                    num = this.m_CompareInfo.Compare(x, this.m_NumericStringX.Offset, num2, y, this.m_NumericStringY.Offset, num3, this.m_CompareOptions);
                }
            }
            return num;
        }

        public System.Globalization.CompareOptions CompareOptions
        {
            set
            {
                this.m_CompareOptions = value;
            }
        }

        public CultureInfo CurrentCulture
        {
            set
            {
                if (value != null)
                {
                    this.m_CompareInfo = value.CompareInfo;
                }
            }
        }

        private class AlphaNumericString
        {
            private bool m_HasNext = true;
            private int m_Index;
            private bool m_IsNumeric;
            private int m_Offset;
            private int m_OriginalLength;
            private string m_Source;

            internal AlphaNumericString()
            {
            }

            internal int ReadToken()
            {
                int num3;
                int num4;
                if (!this.m_HasNext)
                {
                    return -1;
                }
                int length = this.m_Source.Length;
                int num2 = this.m_Index + 1;
                if (this.m_IsNumeric)
                {
                    while (((num2 < length) && (this.m_Source[num2] <= '9')) && (this.m_Source[num2] >= '0'))
                    {
                        num2++;
                    }
                    this.m_OriginalLength = num2 - this.m_Index;
                    if (this.m_Source[this.m_Index] != '0')
                    {
                        goto Label_00D4;
                    }
                    num3 = this.m_Index + 1;
                    while (num3 < num2)
                    {
                        if (this.m_Source[num3] != '0')
                        {
                            break;
                        }
                        num3++;
                    }
                }
                else
                {
                    while ((num2 < length) && ((this.m_Source[num2] > '9') || (this.m_Source[num2] < '0')))
                    {
                        num2++;
                    }
                    goto Label_00D4;
                }
                this.m_Index = (num3 < num2) ? num3 : (num2 - 1);
                Label_00D4:
                num4 = num2 - this.m_Index;
                this.m_Offset = this.m_Index;
                this.m_Index = num2;
                return num4;
            }

            internal bool HasNextToken
            {
                get
                {
                    this.m_HasNext = this.m_Index < this.m_Source.Length;
                    if (this.m_HasNext)
                    {
                        this.m_IsNumeric = (this.m_Source[this.m_Index] <= '9') && (this.m_Source[this.m_Index] >= '0');
                    }
                    return this.m_HasNext;
                }
            }

            internal bool IsNumeric
            {
                get
                {
                    return this.m_IsNumeric;
                }
            }

            internal int Offset
            {
                get
                {
                    return this.m_Offset;
                }
            }

            internal int OriginalLength
            {
                get
                {
                    return this.m_OriginalLength;
                }
            }

            internal string Source
            {
                get
                {
                    return this.m_Source;
                }
                set
                {
                    this.m_Source = value;
                    if ((this.m_Source != null) && (this.m_Source != string.Empty))
                    {
                        this.m_Index = 0;
                        this.m_HasNext = true;
                    }
                    else
                    {
                        this.m_HasNext = false;
                    }
                }
            }
        }
    }

}
