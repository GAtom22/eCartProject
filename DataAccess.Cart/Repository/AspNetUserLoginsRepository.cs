using Entities.Cart;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace DataAccess.Cart.Repository
{
    public class AspNetUserLoginsRepository : IAspNetUserLoginsRepository
    {
        CartDBEntities context;
        public AspNetUserLoginsRepository()
        {
            this.context = new CartDBEntities();
        }
 
        public void Create(AspNetUserLogin entity)
        {
            try
            {
                context.AspNetUserLogins.Add(entity);
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

        public void Delete(AspNetUserLogin entity)
        {
            try
            {
                context.AspNetUserLogins.Remove(entity);
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
                var entity = context.AspNetUserLogins.Find(id);
                context.AspNetUserLogins.Remove(entity);
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

        public IEnumerable<AspNetUserLogin> GetAll()
        {
            try
            {
                var result = new List<AspNetUserLogin>();

                result = context.AspNetUserLogins.ToList();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AspNetUserLogin GetById(int id)
        {
            try
            {
                AspNetUserLogin result = null;
                result = context.AspNetUserLogins.Find(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AspNetUserLogin GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(AspNetUserLogin entity)
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
