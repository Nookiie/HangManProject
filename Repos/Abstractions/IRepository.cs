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
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetByID(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteByID(object id);

    }
}
