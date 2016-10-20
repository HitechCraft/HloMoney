namespace HloMoney.Core.Helper
{
    using System;
    using System.Collections.Generic;

    public static class RandomHelper
    {
        public static List<int> GetRandomInts(int count, int fromCount)
        {
            List<int> numbers = new List<int>();
            var random = new Random();

            while (numbers.Count < count)
            {
                int newInt = random.Next(0, fromCount);

                if (!numbers.Contains(newInt))
                {
                    numbers.Add(newInt);
                }
            }

            return numbers;
        }
    }
}
