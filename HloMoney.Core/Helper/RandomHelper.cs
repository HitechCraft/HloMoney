namespace HloMoney.Core.Helper
{
    using System.Collections.Generic;
    using System;
    using Entity;

    public static class RandomHelper
    {
        /// <summary>
        /// Get random winners from parts
        /// </summary>
        /// <param name="entities">As a list of objects</param>
        /// <param name="count">Count of entties</param>
        /// <returns></returns>
        public static ICollection<ContestPart> GetRandomEntities(List<ContestPart> parts, int count)
        {
            ICollection<ContestPart> selectedParts = new List<ContestPart>();

            for (int i = 0; i < count; i++)
            {
                selectedParts.Add(parts[new Random().Next(0, count)]);
            }

            return selectedParts;
        }
    }
}
