using DataAccess.Cart.Repository;
using Entities.Cart;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Cart
{
    public class AspNetRolesBL : IAspNetRolesBL
    {
        IAspNetRolesRepository repository;

        public AspNetRolesBL()
        {
            this.repository = new AspNetUserRepository();

        }

        public void Create(AspNetRole entity)
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

        public void Delete(AspNetRole entity)
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

        public IEnumerable<AspNetRole> GetAll()
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

        public AspNetRole GetById(int id)
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

        public AspNetRole GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(AspNetRole entity)
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
