using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Collections
{
    public static class ICollectionExtensions
    {
        public static void Remove<TSource>(this ICollection<TSource> source, Func<TSource, bool> predicate)
        {
            var item = source.FirstOrDefault(predicate);
            if (item != null)
            {
                source.Remove(item);
            }
        }
    }
}
