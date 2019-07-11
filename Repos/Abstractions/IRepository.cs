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

        T Get(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        IQueryable<T> Find(Expression<Func<T, bool>> where);
    }
}
