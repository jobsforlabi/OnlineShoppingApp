using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineShoppingApp.UI.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> whereClause, params Expression<Func<T, object>>[] navigationProperties);
        T GetById(int id, params Expression<Func<T, object>>[] navigationProperties);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}