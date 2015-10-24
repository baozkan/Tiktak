using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.ServiceModel.Abstractions
{
    public interface IDocumentService : IDisposable
    {
        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        ICollection<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        ICollection<TEntity> All<TEntity>() where TEntity : class;

        void Insert<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;
    }
}
