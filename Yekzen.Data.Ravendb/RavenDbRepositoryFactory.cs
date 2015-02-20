using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data.RavenDb
{
    public class RavenDbRepositoryFactory  : IRepositoryFactory
    {
        public IRepository<TEntity> Get<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
