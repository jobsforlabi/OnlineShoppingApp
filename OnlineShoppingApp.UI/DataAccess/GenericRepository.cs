using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineShoppingApp.UI.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private OnlineShoppingContext shoppingContext = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.shoppingContext = new OnlineShoppingContext();
            this.table = shoppingContext.Set<T>();
        }

        public GenericRepository(OnlineShoppingContext shoppingContext)
        {
            this.shoppingContext = shoppingContext;
            this.table = shoppingContext.Set<T>();
        }

        public virtual void Delete(int id)
        {
            try
            {
                T itemToDelete = table.Find(id);

                if (itemToDelete != null)
                {
                    table.Remove(itemToDelete);
                    shoppingContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IEnumerable<T> GetAll(Func<T, bool> whereClause, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = table;

            if(whereClause != null)
            {
                query = query.Where(whereClause).AsQueryable();
            }

            if (navigationProperties != null)
            {
                foreach (var navigaionProperty in navigationProperties)
                {
                    query = query.Include(navigaionProperty);
                }
            }

            return query.ToList();
        }

        public virtual T GetById(int id, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = table.Find(id) as IQueryable<T>;

            foreach (var navigaionProperty in navigationProperties)
            {
                query = query.Include(navigaionProperty);
            }

            return query.FirstOrDefault();
        }

        public virtual void Insert(T entity)
        {
            try
            {
                table.Add(entity);
                shoppingContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                table.Attach(entity);
                shoppingContext.Entry(entity).State = EntityState.Modified;
                shoppingContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}