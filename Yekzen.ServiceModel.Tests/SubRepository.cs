using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Data;

namespace Yekzen.ServiceModel.Tests
{
    internal class SubRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ICollection<TEntity> set;

        public SubRepository()
        {
            this.set = new HashSet<TEntity>();
        }

        TEntity IRepository<TEntity>.Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return this.set
                .FirstOrDefault(predicate.Compile());
        }

        ICollection<TEntity> IRepository<TEntity>.Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return this.set
                .Where(predicate.Compile())
                .ToList();
        }

        ICollection<TEntity> IRepository<TEntity>.All()
        {
            return this.set;
        }

        void IRepository<TEntity>.Insert(TEntity entity)
        {
            this.set.Add(entity);
        }

        void IRepository<TEntity>.Update(TEntity entity)
        {
            // Do nothing. İtem already changed.
        }

        void IRepository<TEntity>.Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }
    }
}
