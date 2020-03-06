using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Entities.Cart;
using UI.Cart2.Models;
using BusinessLogic.Cart;

namespace UI.Cart2.Areas.Panel.Controllers
{
    public class CartItemsController : Controller
    {
        private ICartItemBL _cartItembl;
        private IProductsBL _productsbl;
        public CartItemsController()
        {
            this._cartItembl = new CartItemBL();
            this._productsbl = new ProductsBL();
        }



        // GET: Panel/CartItems
        public ActionResult Index()
        {
            var cartItems = this._cartItembl.GetAll();// db.CartItems.Include(c => c.Products);
            return View(cartItems.ToList());
        }

        // GET: Panel/CartItems/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = this._cartItembl.GetById(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // GET: Panel/CartItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(this._productsbl.GetAll(), "ProductID", "ProductName");
            return View();
        }

        // POST: Panel/CartItems/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CartId,Quantity,DateCreated,ProductId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                this._cartItembl.Create(cartItem);
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(this._productsbl.GetAll(), "ProductID", "ProductName", cartItem.ProductId);
            return View(cartItem);
        }

        // GET: Panel/CartItems/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = this._cartItembl.GetById(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(this._productsbl.GetAll(), "ProductID", "ProductName", cartItem.ProductId);
            return View(cartItem);
        }

        // POST: Panel/CartItems/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CartId,Quantity,DateCreated,ProductId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                this._cartItembl.Update(cartItem);
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(this._productsbl.GetAll(), "ProductID", "ProductName", cartItem.ProductId);
            return View(cartItem);
        }

        // GET: Panel/CartItems/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = this._cartItembl.GetById(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: Panel/CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CartItem cartItem = this._cartItembl.GetById(id);
            this._cartItembl.Delete(cartItem);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}