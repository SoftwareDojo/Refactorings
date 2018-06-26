using System.Collections.Generic;

namespace CSharpRefactorings.FizzBuzz.Refactored
{
    public class FizzBuzz
    {
        private readonly IDictionary<int, string> m_Mapping;

        public FizzBuzz()
        {
            m_Mapping = new Dictionary<int, string> {{3, "Fizz"}, {5, "Buzz"}};
        }

        public string PrintFizzBuzz(int number)
        {
            return DoFizzBuzz(number);
        }

        public string PrintFizzBuzzRange(int count)
        {
            return Range(count);
        }

        private string Range(int count)
        {
            var results = new string[count];

            for (var i = 1; i <= count; i++)
            {
                results[i-1] = DoFizzBuzz(i);
            }

            return string.Join(" ", results);
        }

        private string DoFizzBuzz(int number)
        {
            var printNumber = string.Empty;

            foreach (var mapping in m_Mapping)
            {
                if (number % mapping.Key == 0) printNumber += mapping.Value;
            }

            if (string.IsNullOrEmpty(printNumber)) printNumber = number.ToString();

            return printNumber;
        }
    }
}
