using System;

namespace HloMoney.Core.Extentions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtentions
    {
        /// <summary>
        /// Returns the last of [count] elements
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">IEnumerable</param>
        /// <param name="count">Count of elements</param>
        /// <returns></returns>
        public static IEnumerable<T> Limit<T>(this IEnumerable<T> list, int count)
        {
            var limitedList = list.Take(count >= 0 ? count : 0);

            return limitedList;
        }

        /// <summary>
        /// Return range of elements
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">IEnumerable list</param>
        /// <param name="start">Start position</param>
        /// <param name="count">Count elements</param>
        /// <returns></returns>
        public static IEnumerable<T> TakeRange<T>(this IEnumerable<T> list, int start, int count)
        {
            var limitedList = list.Skip(start).Reverse().Skip(list.Count() - count).Reverse();

            return limitedList;
        }

        public static IList<T> Randomize<T>(this IList<T> target)
        {
            Random RndNumberGenerator = new Random();

            SortedList<int, T> newList = new SortedList<int, T>();

            foreach (T item in target)
            {
                newList.Add(RndNumberGenerator.Next(), item);
            }

            target.Clear();

            for (int i = 0; i < newList.Count; i++)
            {
                target.Add(newList.Values[i]);
            }

            return target;
        }
    }
}
