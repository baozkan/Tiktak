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
using System.Linq.Expressions;

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

        public TEntity Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var result = this.collection
                .Find(predicate)
                .SingleOrDefaultAsync();
            result.Wait();
            return result.Result;
        }

        public ICollection<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                var result = new HashSet<TEntity>(this.collection.AsQueryable<TEntity>());
                return  result;
            }
            else
            {
                var result = this.collection.Find<TEntity>(predicate)
                    .ToCollectionAsync();
                result.Wait();
                return result.Result;
            }
        }

        
        public void Insert(TEntity entity)
        {
            var result = this.collection
                .InsertOneAsync(entity);
            result.Wait();
        }

        public void Update(Expression<Func<TEntity,bool>> predicate,TEntity entity)
        {
            var result = this.collection.ReplaceOneAsync(predicate, entity);
            result.Wait();
        }

        public void Delete(Expression<Func<TEntity,bool>> predicate)
        {
            var result = this.collection.DeleteOneAsync<TEntity>(predicate);
            result.Wait();
        }

        #endregion
    }
}
