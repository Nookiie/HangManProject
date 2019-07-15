using HM.Data.Abstraction;
using HM.Data.Context;
using HM.Data.Entities.GameItems;
using HM.Repositories.Abstractions;
using Repos.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Repositories.Implementations
{
    public class GenericUnit<T> : IDisposable
        where T:BaseEntity<int>
    {

        private readonly HangmanDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public GenericUnit(HangmanDbContext context)
        {
            this.context = context;
        }

        public GenericUnit()
        {

        }

        public HangmanDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<T> Entity
        {
            get
            {
                return this.GetRepository<T>();
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];

        }
    }
}
