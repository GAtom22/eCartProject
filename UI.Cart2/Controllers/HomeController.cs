using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using BusinessLogic.Cart.ShoppingCart;

namespace UI.Cart2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //ShoppingCartActionsBL usersShoppingCart = new ShoppingCartActionsBL();

            //string cartStr = string.Format("Cart ({0})", usersShoppingCart.GetCount());
            //Session["NumItems"] = cartStr;
               
            return View();
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