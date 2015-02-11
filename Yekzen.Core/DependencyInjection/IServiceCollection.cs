using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.DependencyInjection
{
    /// <summary>
    /// Specifies the contract for a collection of service descriptors.
    /// </summary>
    public interface IServiceCollection : ICollection<IServiceDescriptor>
    {
        /// <summary>
        /// Adds the <paramref name="descriptor"/> to this instance.
        /// </summary>
        /// <param name="descriptor">The <see cref="IServiceDescriptor"/> to add.</param>
        /// <returns>A reference to the current instance of <see cref="IServiceCollection"/>.</returns>
        new IServiceCollection Add(IServiceDescriptor descriptor);
    }
}
