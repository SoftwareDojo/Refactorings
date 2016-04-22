using System;

namespace CSharpRefactorings.Snippets.Refactored
{
    public class IsPrimeNumberSnippet
    {
        private bool IsPrimeNumber(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
