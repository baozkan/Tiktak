using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Get<TEntity>() where TEntity : class;
    }
}
