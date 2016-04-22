using System;

namespace CSharpRefactorings.Snippets.Original
{
    public class IsPrimeNumberSnippet
    {
        public static bool IsPrimeNumber(int m)
        {
            bool yes = false;
            int j = 2;
            for (; j <= Math.Sqrt(m); j++)
            {
                if (m % j == 0)
                {
                    return yes;
                }
            }
            return yes = true;
        }
    }
}
