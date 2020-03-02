using Entities.Cart;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace DataAccess.Cart.Repository
{
    public class ProductsRepository : IProductsRepository
    {
     
        CartDBEntities context;
        public ProductsRepository()
        {
            this.context = new CartDBEntities();
        }

        public void Create(Product entity)
        {
            try
            {
                context.Products.Add(entity);
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
#if DEBUG
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
#endif
                }
                throw e;
            }
        }

        public void Delete(Product entity)
        {
            try
            {
                context.Products.Remove(entity);
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = context.Products.Find(id);
                context.Products.Remove(entity);
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                var result = new List<Product>();

                result = context.Products.ToList();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                Product result = null;
                result = context.Products.Find(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
