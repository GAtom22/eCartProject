using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cart;
using Entities.Cart;


namespace UI.Cart2.Controllers
{
    public class OurProductsController : Controller
    {
        private ICategoriesBL _categoriesbl;
        private IProductsBL _productsbl;
        public OurProductsController()
        {
            this._categoriesbl = new CategoriesBL();
            this._productsbl = new ProductsBL();
        }

        // GET: /Products
        public ActionResult Index()
        {
            var products = this._productsbl.GetAll();
            return View(products.ToList());
        }


        // GET: /Products/Shoes
        public ActionResult Shoes()
        {
            var products = this._productsbl.GetAll().Where(p => p.Category.CategoryName == "Shoes");
            return View(products.ToList());
        }

        // GET: /Products/Shirts
        public ActionResult Shirts()
        {
            var products = this._productsbl.GetAll().Where(p => p.Category.CategoryName == "Shirts");
            return View(products.ToList());
        }

        // GET: /Products/Pants
        public ActionResult Pants()
        {
            var products = this._productsbl.GetAll().Where(p => p.Category.CategoryName == "Pants");
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = _productsbl.GetById(id);
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}