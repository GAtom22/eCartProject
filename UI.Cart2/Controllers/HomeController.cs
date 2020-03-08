using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cart;
using Entities.Cart;

namespace UI.Cart2.Controllers
{
    public class HomeController : Controller
    {
        private ICategoriesBL _categoriesbl;
        private IProductsBL _productsbl;
        public HomeController()
        {
            this._categoriesbl = new CategoriesBL();
            this._productsbl = new ProductsBL();
        }
        public ActionResult Index()
        {

            var products = this._productsbl.GetAll();
            return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}