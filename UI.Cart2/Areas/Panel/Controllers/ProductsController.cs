using BusinessLogic.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Cart;

namespace UI.Cart2.Areas.Panel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private ICategoriesBL _categoriesbl;
        private IProductsBL _productsbl;
        public ProductsController()
        {
            this._categoriesbl = new CategoriesBL();
            this._productsbl = new ProductsBL();
        }

        // GET: Panel/Products
        public ActionResult Index()
        {
            var products = this._productsbl.GetAll();// db.Products.Include(p => p.Categories);
            return View(products.ToList());
        }

        // GET: Panel/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = this._productsbl.GetById(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Panel/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(this._categoriesbl.GetAll(), "CategoryID", "CategoryName");
            return View();
        }

        // POST: Panel/Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Description,ImagePath,UnitPrice,CategoryID")] Product products)
        {
            var rnd = new Random();
            int num = rnd.Next(1, 1000);
            products.ImagePath = "https://i.picsum.photos/id/" + num + "/300/300.jpg";
             
            if (ModelState.IsValid)
            {
                this._productsbl.Create(products);
                return RedirectToAction("../../Admin/Products");
            }

            ViewBag.CategoryID = new SelectList(this._categoriesbl.GetAll(), "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Panel/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = this._productsbl.GetById(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(this._categoriesbl.GetAll(), "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // POST: Panel/Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Description,ImagePath,UnitPrice,CategoryID")] Product products)
        {
            if (ModelState.IsValid)
            {
                this._productsbl.Update(products);
                return RedirectToAction("../../Admin/Products");
            }
            ViewBag.CategoryID = new SelectList(this._categoriesbl.GetAll(), "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Panel/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = this._productsbl.GetById(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Panel/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product products = this._productsbl.GetById(id);
            this._productsbl.Delete(products);
            return RedirectToAction("../../Admin/Products");
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