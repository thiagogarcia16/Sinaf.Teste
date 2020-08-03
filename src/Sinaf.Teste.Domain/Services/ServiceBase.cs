using Sinaf.Teste.Domain.Interfaces.Repositories;
using Sinaf.Teste.Domain.Interfaces.Services;
using Sinaf.Teste.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sinaf.Teste.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        protected IUnitOfWork UnitOfWork;     
        protected readonly IRepositoryBase<TEntity> Repository;
        protected readonly NotificationContext NotificationContext;

        public ServiceBase(IUnitOfWork unitOfWork, IRepositoryBase<TEntity> repository, NotificationContext notificationContext)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            NotificationContext = notificationContext;
        }


        public virtual void Insert(TEntity obj)
        {
            Repository.Insert(obj);
            if (!NotificationContext.HasNotifications)
                UnitOfWork.Commit();
        }

        public virtual void Update(TEntity obj)
        {
            Repository.Update(obj);
            if (!NotificationContext.HasNotifications)
                UnitOfWork.Commit();
        }

        public virtual void Delete(long id)
        {
            Repository.Delete(id);
            if (!NotificationContext.HasNotifications)
                UnitOfWork.Commit();
        }

        public virtual void Delete(TEntity obj)
        {
            Repository.Delete(obj);
            if (!NotificationContext.HasNotifications)
                UnitOfWork.Commit();
        }

        public virtual TEntity GetById(long id)
        {
            return Repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }      

        public virtual void Dispose()
        {
            if (Repository != null)
            {
                Repository.Dispose();
            }
        }       
   
    }
}
