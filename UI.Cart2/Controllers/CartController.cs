using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cart;
using Entities.Cart;

namespace UI.Cart2.Controllers
{
    public class CartController : Controller
    {
        private ICartItemBL _cartItemsbl;
        private IProductsBL _productsbl;
        public CartController()
        {
            this._cartItemsbl = new CartItemBL();
            this._productsbl = new ProductsBL();
        }
        public const string CartSessionKey = "CartId";
        
        public string ShoppingCartId { get; set; }
        // GET: Cart
        public ActionResult Index()
        {
            ShoppingCartId = GetCartId();
            return View(_cartItemsbl.GetAll().Where(c=> c.CartId == ShoppingCartId));
        }


        public ActionResult AddToCart(int id)
        {
            ShoppingCartId = GetCartId();
            var cartItem = _cartItemsbl.GetAll().SingleOrDefault(
          c => c.CartId == ShoppingCartId
          && c.ProductId == id);
            if (cartItem == null)
            {
                
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Quantity = 1,
                    DateCreated = DateTime.Now,
                    Product = _productsbl.GetById(id)
                };

                _cartItemsbl.Create(cartItem);

               
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            TotalItems(ShoppingCartId);

            return Redirect("/OurProducts");
        }

        public ActionResult UpdateCartItem(CartItem item)
        {
             _cartItemsbl.Update(item);
            return Redirect("Index");
        }

        public ActionResult DeleteCartItem(CartItem item)
        {
            var current = _cartItemsbl.GetAll().Where(c=>c.ItemId==item.ItemId && c.CartId == item.CartId);

            if (current.FirstOrDefault().Quantity > item.Quantity) {
                item.Quantity = current.FirstOrDefault().Quantity - item.Quantity;
                _cartItemsbl.Update(item);
            }
            else
            {
                _cartItemsbl.Delete(item);
            }
     
            return Redirect("Index");
        }

        public ActionResult EmptyCart()
        {
            var items = _cartItemsbl.GetAll().Where(c => c.CartId == ShoppingCartId);

            foreach (var item in items)
            {
                _cartItemsbl.Delete(item);
            }

            return Redirect("Index");
        }

        public string GetCartId()
        {
            if (Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(User.Identity.Name))
                {
                    Session[CartSessionKey] = User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return Session[CartSessionKey].ToString();
        }

        public void TotalItems(string ShoppingCartId)
        {
            var items = _cartItemsbl.GetAll().Where(c => c.CartId == ShoppingCartId);
            var total = 0;
            foreach (var item in items)
            {
                total += item.Quantity;
            }
            Session["itemsNum"] = total;
        }
    }
}