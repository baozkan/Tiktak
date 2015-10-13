using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core;

namespace Yekzen.Data.RavenDb
{
    public class RavenDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IDocumentSession Session { get; set; }

        public RavenDbRepository(IUnitOfWork context)
        {
            var ravenDbContext = context as RavenDbContext;
            this.Session = ravenDbContext.Session;
        }

        public TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var entity = Session.Query<TEntity>().FirstOrDefault(predicate);
            return entity;
        }

        public ICollection<TEntity> Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return Session.Query<TEntity>().Where(predicate).ToHashSet();
        }

        public ICollection<TEntity> All()
        {
            return Session.Query<TEntity>().ToHashSet();
        }

        public void Create(TEntity entity)
        {
            Session.Store(entity);
            Session.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Session.Store(entity);
        }

        public void Delete(TEntity entity)
        {
            Session.Delete<TEntity>(entity);
        }
    }
}
