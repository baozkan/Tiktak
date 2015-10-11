using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Collections
{
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Removes a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An System.Collections.Generic.ICollection<TSource> to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        public static void Remove<TSource>(this ICollection<TSource> source, Func<TSource, bool> predicate)
        {
            
            var item = source.FirstOrDefault(predicate);
            if (item != null)
            {
                source.Remove(item);
            }
        }

        /// <summary>
        /// Adds a sequence of value to an System.Collections.Generic.ICollection<TSource>.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An System.Collections.Generic.ICollection<TSource> to add.</param>
        /// <param name="collection">An System.Collections.Generic.IEnumerable<TSource> for adding.</param>
        public static void AddRange<TSource>(this ICollection<TSource> source, IEnumerable<TSource> collection)
        {
            foreach (var item in collection)
            {
                source.Add(item);
            }
        }
    }
}
