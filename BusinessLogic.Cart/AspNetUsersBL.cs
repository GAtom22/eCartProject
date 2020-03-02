using Entities.Cart;
using DataAccess.Cart.Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Cart
{
    public class AspNetUsersBL : IAspNetUsersBL
    {
        IAspNetUsersRepository repository;

        public AspNetUsersBL()
        {
            this.repository = new AspNetUsersRepository();
        }
 
        public void Create(AspNetUser entity)
        {
            

            try
            {
                this.repository.Create(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(AspNetUser entity)
        {
            

            try
            {
                this.repository.Delete(entity);
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
                this.repository.Delete(id);
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

        public IEnumerable<AspNetUser> GetAll()
        {
            
            try
            {
                return this.repository.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AspNetUser GetById(int id)
        {
            try
            {
                return this.repository.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public AspNetUser GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(AspNetUser entity)
        {
            try
            {
                this.repository.Update(entity);
                return;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
    }
}
