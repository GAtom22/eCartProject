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
    public class RolesController : Controller
    {
        private IAspNetRolesBL _rolesbl;

        public RolesController()
        {
            this._rolesbl = new AspNetRolesBL();
        }
        // GET: Panel/Roles
        public ActionResult Index()
        {
            var roles = this._rolesbl.GetAll();
            return View(roles.ToList());

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole roles = this._rolesbl.GetById(id.Value);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // GET: Panel/Products/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(this._rolesbl.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Panel/Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] AspNetRole roles)
        {
            if (ModelState.IsValid)
            {
                this._rolesbl.Create(roles);
                return RedirectToAction("../../Admin/Roles");
            }

            ViewBag.id = new SelectList(this._rolesbl.GetAll(), "Id", "Name", roles.Id);
            return View(roles);
        }

        // GET: Panel/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole roles = this._rolesbl.GetById(id.Value);
            if (roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(this._rolesbl.GetAll(), "Id", "Name", roles.Id);
            return View(roles);
        }

        // POST: Panel/Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AspNetRole roles)
        {
            if (ModelState.IsValid)
            {
                this._rolesbl.Update(roles);
                return RedirectToAction("../../Admin/Roles");
            }
            ViewBag.id = new SelectList(this._rolesbl.GetAll(), "Id", "Name", roles.Id);
            return View(roles);
        }

        // GET: Panel/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole roles = this._rolesbl.GetById(id.Value);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: Panel/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetRole roles = this._rolesbl.GetById(id);
            this._rolesbl.Delete(roles);
            return RedirectToAction("../../Admin/Roles");
        }

    }
}