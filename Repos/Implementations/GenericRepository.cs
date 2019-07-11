using HM.Data.Context;
using HM.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repos.Implementations
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected HangmanDbContext Context { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(HangmanDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
       
        public IQueryable<TEntity> Get()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual TEntity Get(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return this.DbSet.Where(where);
        }
    }
}
