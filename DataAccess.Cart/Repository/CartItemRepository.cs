using Entities.Cart;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Cart.Repository
{
    /// <summary>
    /// La clase CartItem contiene el esquema que va a definir cada producto que un usuario agrega al carro de la compra.
    /// Por Convención, Entity Framework Code First espera que la clave principal de la tabla CartItem sea CartItemId o ID. Sin embargo, el código invalida el comportamiento predeterminado mediante el atributo de anotación de datos [Key]. El atributo Key de la propiedad ItemId especifica que la propiedad ItemID es la clave principal
    /// La propiedad CartId especifica el ID del usuario asociado al elemento que se va a comprar.Agregará código para crear este usuario ID cuando el usuario tenga acceso al carro de la compra. Esta ID también se almacenará como una variable de sesión ASP.NET.
    /// </summary>
    public class CartItemRepository : ICartItemRepository
    {
     

        CartDBEntities context;
        public CartItemRepository()
        {
            this.context = new CartDBEntities();
        }

        public void Create(CartItem entity)
        {
            try
            {
                context.CartItems.Add(entity);
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

        public void Delete(CartItem entity)
        {
            try
            {
                context.CartItems.Remove(entity);
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
            try
            {
                var entity = context.CartItems.Find(id);
                context.CartItems.Remove(entity);
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
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetAll()
        {
            try
            {
                var result = new List<CartItem>();

                result = context.CartItems.ToList();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CartItem GetById(string id)
        {
            try
            {
                CartItem result = null;
                result = context.CartItems.Find(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CartItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CartItem entity)
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
