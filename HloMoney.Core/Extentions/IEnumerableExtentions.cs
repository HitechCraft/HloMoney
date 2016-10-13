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
    }
}
