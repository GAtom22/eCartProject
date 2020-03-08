using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cart;
using Entities.Cart;

namespace UI.Cart2.Areas.Panel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private IAspNetUsersBL _usersbl;

        public UsersController()
        {
            this._usersbl = new AspNetUsersBL();
        }
        // GET: Panel/users
        public ActionResult Index()
        {
            var users = this._usersbl.GetAll();
            return View(users.ToList());

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser users = this._usersbl.GetById(id.Value);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Panel/Products/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(this._usersbl.GetAll(), "Id", "UserName");
            return View();
        }

        // POST: Panel/Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName")] AspNetUser users)
        {
            if (ModelState.IsValid)
            {
                this._usersbl.Create(users);
                return RedirectToAction("../../Admin/Users");
            }

            ViewBag.id = new SelectList(this._usersbl.GetAll(), "Id", "UserName", users.Id);
            return View(users);
        }

        // GET: Panel/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser users = this._usersbl.GetById(id.Value);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(this._usersbl.GetAll(), "Id", "UserName", users.Id);
            return View(users);
        }

        // POST: Panel/Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hometown, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount,UserName")] AspNetUser users)
        {
            if (ModelState.IsValid)
            {
                this._usersbl.Update(users);
                return RedirectToAction("../../Admin/Users");
            }
            ViewBag.id = new SelectList(this._usersbl.GetAll(), "Id", "UserName", users.Id);
            return View(users);
        }

        // GET: Panel/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser users = this._usersbl.GetById(id.Value);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Panel/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetUser users = this._usersbl.GetById(id);
            this._usersbl.Delete(users);
            return RedirectToAction("../../Admin/Users");
        }

    }
}