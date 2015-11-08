using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        TEntity IRepository<TEntity>.FindByKey<TKey>(TKey key)
        {
            throw new NotSupportedException();
        }

        TEntity IRepository<TEntity>.Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return this.set
                .FirstOrDefault(predicate.Compile());
        }

        ICollection<TEntity> IRepository<TEntity>.Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return this.set
                .Where(predicate.Compile())
                .ToList();
        }

        void IRepository<TEntity>.Insert(TEntity entity)
        {
            this.set.Add(entity);
        }

        void IRepository<TEntity>.Update(Expression<Func<TEntity,bool>> predicate, TEntity entity)
        {
            // Do nothing. İtem already changed.
        }

        void IRepository<TEntity>.Delete(Expression<Func<TEntity, bool>> predicate)
        {
            //this.set.Remove(entity);
        }
    }
}
