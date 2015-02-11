using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Unity
{
    public class UnityServiceCollection : IServiceCollection
    {
        private readonly IServiceCollection collection;
        private readonly IUnityContainer container;

        public UnityServiceCollection(IUnityContainer container, IServiceCollection collection = null)
        {

            this.collection = collection ?? new ServiceCollection();
            this.container = container;
            foreach (var serviceDescriptor in this.collection)
            {
                this.container.Register(serviceDescriptor);
            }
        }

        

        IServiceCollection IServiceCollection.Add(IServiceDescriptor descriptor)
        {
            this.container.Register(descriptor);
            return collection.Add(descriptor);
        }

        void ICollection<IServiceDescriptor>.Add(IServiceDescriptor item)
        {
            collection.Add(item);
        }

        void ICollection<IServiceDescriptor>.Clear()
        {
            collection.Clear();
        }

        bool ICollection<IServiceDescriptor>.Contains(IServiceDescriptor item)
        {
            return collection.Contains(item);
        }

        void ICollection<IServiceDescriptor>.CopyTo(IServiceDescriptor[] array, int arrayIndex)
        {
            collection.CopyTo(array, arrayIndex);
        }

        int ICollection<IServiceDescriptor>.Count
        {
            get { return collection.Count; }
        }

        bool ICollection<IServiceDescriptor>.IsReadOnly
        {
            get { return collection.IsReadOnly; }
        }

        bool ICollection<IServiceDescriptor>.Remove(IServiceDescriptor item)
        {
            return collection.Remove(item);
        }

        IEnumerator<IServiceDescriptor> IEnumerable<IServiceDescriptor>.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
