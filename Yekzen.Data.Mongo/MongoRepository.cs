using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

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
            if (!(key is string))
                throw new NotSupportedException();
            var filter = Builders<TEntity>.Filter.Eq("Id", key);
            var task = this.collection.Find(filter).FirstOrDefaultAsync();
            task.Wait();
            return task.Result;
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
            var hashSet = new HashSet<TEntity>(this.collection.AsQueryable());
            return hashSet;
        }
       
        public void Insert(TEntity entity)
        {
            this.collection
                .InsertOneAsync(entity)
                .Wait();
            
        }

        public void Update(TEntity entity)
        {
            this.collection.UpdateOneAsync()
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
