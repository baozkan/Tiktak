using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yekzen.Core;

namespace Yekzen.Data.Mongo
{

    /// <summary>
    /// Represents extension methods for IAsyncCursor.
    /// </summary>
    public static class IAsyncCursorExtensions
    {
        /// <summary>
        /// Returns a collection containing all the documents returned by a cursor.
        /// </summary>
        /// <typeparam name="TDocument">The type of the document.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task whose value is the collection of documents.</returns>
        public static async Task<ICollection<TDocument>> ToCollectionAsync<TDocument>(this IAsyncCursor<TDocument> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            Require.NotNull <IAsyncCursor<TDocument>>(source, "source");

            var collection = new HashSet<TDocument>();
           
            using (source)
            {
                while (await source.MoveNextAsync(cancellationToken).ConfigureAwait(false))
                {
                    foreach (var document in source.Current)
                    {
                        collection.Add(document);   
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            return collection;
        }
    }
}
