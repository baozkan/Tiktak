using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core;
using Yekzen.Data;

namespace Yekzen.ServiceModel
{
    public class RepositoryService : ServiceModel.Abstractions.IDocumentService
    {
        private readonly IUnitOfWork unitOfWork;

        public RepositoryService()
        {
            unitOfWork = ServiceProvider.Current.GetService<IUnitOfWork>();
        }

        private static IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            var repository = ServiceProvider.Current.GetService<IRepository<TEntity>>();
            return repository;
        }

        TEntity Abstractions.IDocumentService.Find<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return CreateRepository<TEntity>()
                .Find(predicate);
        }


        ICollection<TEntity> Abstractions.IDocumentService.Query<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return CreateRepository<TEntity>()
                .Query(predicate);
        }

        ICollection<TEntity> Abstractions.IDocumentService.All<TEntity>()
        {
            return CreateRepository<TEntity>()
                .All();
        }

        void Abstractions.IDocumentService.Insert<TEntity>(TEntity entity)
        {
            CreateRepository<TEntity>()
                .Insert(entity);
        }

        void Abstractions.IDocumentService.Update<TEntity>(TEntity entity)
        {
            CreateRepository<TEntity>()
                .Update(entity);
        }

        void Abstractions.IDocumentService.Delete<TEntity>(TEntity entity)
        {
            CreateRepository<TEntity>()
                .Delete(entity);
        }

        void IDisposable.Dispose()
        {
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
    }
}
