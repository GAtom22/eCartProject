using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cart;
using Entities.Cart;

namespace UI.Cart.Areas.Panel.Controllers
{
    public class UsersController : Controller
    {
        // GET: Panel/Users
        public ActionResult Index()
        {
            return View();
        }
        // GET: Panel/Users/Roles
        public ActionResult Roles()
        {
            AspNetUsersBL users = new AspNetUsersBL();
            
            return View(users.GetAll());
        }


        // POST: Panel/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                AspNetUsersBL users = new AspNetUsersBL();
                users.Delete(id);
                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panel/Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            AspNetUsersBL users = new AspNetUsersBL();

            return View(users.GetById(id));
        }

        // POST: Panel/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(AspNetUser entity)
        {
            try
            {
                // TODO: Add delete logic here
                AspNetUsersBL users = new AspNetUsersBL();
                users.Update(entity);
                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }
    }
}