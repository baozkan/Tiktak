﻿using Raven.Client;
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

        public TEntity FindByKey<TKey>(TKey key)
        {
            Requires.IsType<TKey, string>(key, "key");

            var id = key as string;
            var entity = Session.Load<TEntity>(id);
            return entity;

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

        public void Insert(TEntity entity)
        {
            Session.Store(entity);
        }

        public void Update(TEntity entity)
        {
            // save changes will take care of it
        }

        public void Delete(TEntity entity)
        {
            Session.Delete<TEntity>(entity);
        }
    }
}
