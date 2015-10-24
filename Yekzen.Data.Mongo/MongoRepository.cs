using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data.Mongo
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MongoDB.Driver.IMongoCollection<TEntity> collection;

        public MongoRepository(IUnitOfWork context)
        { 
            var name = typeof(TEntity).Name;
            this.collection = (context as MongoContext).Database.GetCollection<TEntity>(name); 
        }

        #region IRepository<TEntity> Implemantation
        
        public TEntity FindByKey<TKey>(TKey key)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> All()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            var task = this.collection.InsertOneAsync(entity);
            task.Wait();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
