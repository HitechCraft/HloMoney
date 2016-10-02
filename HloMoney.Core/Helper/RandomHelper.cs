namespace HloMoney.Core.Helper
{
    using System.Collections.Generic;
    using System;

    public static class RandomHelper
    {
        /// <summary>
        /// Get random entities from entity list
        /// </summary>
        /// <param name="entities">As a list of objects</param>
        /// <param name="count">Count of entties</param>
        /// <returns></returns>
        public static ICollection<object> GetRandomEntities(object entities, int count)
        {
            var entityList = entities as ICollection<object>;

            if(entityList.Count < count)
                throw new Exception("Не достаточно элементов в коллекции");

            return null;
        }
    }
}
