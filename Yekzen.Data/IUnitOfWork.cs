using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data
{
    /// <summary>
    /// The unit of work represents a transaction when used in data layers. 
    /// Typically the unit of work will roll back the transaction 
    /// if SaveChanges() has not been invoked before being disposed.
    /// </summary>
    public interface IUnitOfWork : IDisposable  
    {
        void SaveChanges();
    }
}
