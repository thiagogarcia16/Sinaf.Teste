using Microsoft.EntityFrameworkCore;
using Sinaf.Teste.Data.Context;
using Sinaf.Teste.Domain.Entities;
using Sinaf.Teste.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sinaf.Teste.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected SinafContext Db;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBase(SinafContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Insert(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);            
        }

        public virtual void Delete(TEntity obj)
        {
            if (Db.Entry(obj).State == EntityState.Detached)
                DbSet.Attach(obj);

            DbSet.Remove(obj);
        }

        public virtual void Delete(long id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }       

        public virtual TEntity GetById(long id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }  

        public  virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
