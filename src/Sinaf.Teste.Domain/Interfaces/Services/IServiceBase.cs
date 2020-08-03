using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sinaf.Teste.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Delete(long id);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                 Func<IQueryable<TEntity>,
                                 IOrderedQueryable<TEntity>> orderBy = null,
                                 string includeProperties = "");
        void Dispose();
    }
}
