using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HM.Repositories.Abstractions
{
    public interface IRepository<T> 
        where T:class
    {
        IQueryable<T> Get();

        T Get(int id);

        void Insert(T entity);

        void Update(object id, T entity);

        void Delete(T entity);

        void Delete(int id);

        IQueryable<T> Find(Expression<Func<T, bool>> where);
    }
}
