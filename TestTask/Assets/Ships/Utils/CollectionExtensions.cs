using System.Collections.Generic;

namespace Utils
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Расширения с обработкой ситуации выхода за границы массива
        /// </summary>
        public static T GetItemSafe<T>(this IList<T> collection, int index) =>
            index >= collection.Count || index < 0 ? default : collection[index];
    }
}