using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity FindByKey<TKey>(TKey key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(Expression<Func<TEntity,bool>> predicate, TEntity entity);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(Expression<Func<TEntity, bool>> predicate);
    }
}
