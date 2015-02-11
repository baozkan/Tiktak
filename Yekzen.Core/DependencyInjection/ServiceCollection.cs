using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.DependencyInjection
{
    /// <summary>
    /// Default implementation of <see cref="IServiceCollection"/>.
    /// </summary>
    public class ServiceCollection : IServiceCollection
    {
        private readonly List<IServiceDescriptor> descriptors = new List<IServiceDescriptor>();

        /// <inheritdoc />
        public int Count { get { return descriptors.Count; } }

        /// <inheritdoc />
        public bool IsReadOnly { get { return false; } }

        /// <inheritdoc />
        public IServiceCollection Add([NotNull] IServiceDescriptor descriptor)
        {
            descriptors.Add(descriptor);
            return this;
        }

        /// <inheritdoc />
        public void Clear()
        {
            descriptors.Clear();
        }

        /// <inheritdoc />
        public bool Contains(IServiceDescriptor item)
        {
            return descriptors.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(IServiceDescriptor[] array, int arrayIndex)
        {
            descriptors.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(IServiceDescriptor item)
        {
            return descriptors.Remove(item);
        }

        /// <inheritdoc />
        public IEnumerator<IServiceDescriptor> GetEnumerator()
        {
            return descriptors.GetEnumerator();
        }

        void ICollection<IServiceDescriptor>.Add(IServiceDescriptor item)
        {
            Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
