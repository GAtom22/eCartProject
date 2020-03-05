using BusinessLogic.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Cart2.Areas.Panel.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            ProductsBL products = new ProductsBL();
            return View(products.GetAll().ToList());
        }
    }
}