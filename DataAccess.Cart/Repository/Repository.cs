using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Cart.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.context.Set<T>().Find(id);
            this.context.Set<T>().Remove(entity);
            this.context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = this.context.Set<T>().Find(id);
            this.context.Set<T>().Remove(entity);
            this.context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this.context.Set<T>().ToList().AsEnumerable();
        }

        public T GetById(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            this.context.Entry<T>(entity);
            this.context.SaveChanges();
        }
    }
}
