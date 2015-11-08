using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yekzen.Data.Mongo
{
    /// <summary>
    /// Represents extension methods for IAsyncCursorSource.
    /// </summary>
    public static class IAsyncCursorSourceExtensions
    {
        /// <summary>
        /// Returns a collection containing all the documents returned by the cursor returned by a cursor source.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task whose value is the collection of documents.</returns>
        public static async Task<ICollection<TDocument>> ToCollectionAsync<TDocument>(this IAsyncCursorSource<TDocument> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var cursor = await source.ToCursorAsync(cancellationToken).ConfigureAwait(false))
            {
                return await cursor.ToCollectionAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
