using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cart;

namespace UI.Cart.Areas.Panel.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Panel/Products
        public ActionResult Index()
        {
            ProductsBL products = new ProductsBL();
            return View(products.GetAll().ToList());
        }
    }
}