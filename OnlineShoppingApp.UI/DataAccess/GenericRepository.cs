using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public void Delete(int id)
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

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
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

        public void Update(T entity)
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