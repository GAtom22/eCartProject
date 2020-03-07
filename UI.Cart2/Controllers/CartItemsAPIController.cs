using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLogic.Cart;
using Entities.Cart;

namespace UI.Cart2.Controllers
{
    public class CartItemsAPIController : ApiController
    {
        private ICartItemBL _cartItembl;
        private IProductsBL _productsbl;
        public CartItemsAPIController()
        {
            this._cartItembl = new CartItemBL();
            this._productsbl = new ProductsBL();
        }

        // GET api/CartItemsAPI
        [System.Web.Http.HttpGet]
        public IEnumerable<CartItem> Get()
        {
            var cartItems = this._cartItembl.GetAll();
            return cartItems;
        }

        // GET api/CartItemsAPI/id
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            var cartItems = this._cartItembl.GetAll();
            var item = cartItems.FirstOrDefault((p) => p.ProductId == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/CartItemsAPI/item
        [System.Web.Http.HttpPost]
        public void InsertProduct(CartItem item)
        {

            if (ModelState.IsValid)
            {
                this._cartItembl.Create(item);
            }

        }

        // PUT api/CartItemsAPI/item
        [System.Web.Http.HttpPut]
        public void UpdateProduct(CartItem item)
        {
            if (ModelState.IsValid)
            {
                this._cartItembl.Update(item);
            }
        }

        // DELETE api/CartItemsAPI/id
        [System.Web.Http.HttpDelete]
        public void Delete(string id)
        {
            try
            {
                var cartItem = this._cartItembl.GetById(id);
                this._cartItembl.Delete(cartItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}