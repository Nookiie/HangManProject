using HM.Data.Context;
using HM.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
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
            this.Context = context ?? throw new ArgumentException("An instance of HangmanDbContext is required", "context");
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual TEntity Get(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
         
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }

            Context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.Get(id);
            if (entityToDelete != null)
            {
                this.Delete(entityToDelete);
            }

            Delete(entityToDelete);
            Context.SaveChanges();

        }

        public virtual void Delete(TEntity entityToDelete)
        {
            EntityEntry entry = this.Context.Entry(entityToDelete);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entityToDelete);
                this.DbSet.Remove(entityToDelete);
            }
            Context.SaveChanges();

        }

        public virtual void Update(object id, TEntity entityToUpdate)
        {
            EntityEntry entry = this.Context.Entry(entityToUpdate);
            if (entry.State != EntityState.Detached)
            {
                this.DbSet.Attach(entityToUpdate);
            }
            else
            {
                entry.State = EntityState.Modified;
            }
            Context.SaveChanges();

        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return this.DbSet.Where(where);
        }
    }
}
