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
    public class CategoriesController : Controller
    {
        private ICategoriesBL _categoriesbl;
        public CategoriesController()
        {
            this._categoriesbl = new CategoriesBL();
        }

        // GET: Panel/Categories
        public ActionResult Index()
        {
            return View(this._categoriesbl.GetAll());
        }

        // GET: Panel/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category categories = this._categoriesbl.GetById(id.Value);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // GET: Panel/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panel/Categories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description")] Category categories)
        {
            if (ModelState.IsValid)
            {
                this._categoriesbl.Create(categories);

                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: Panel/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category categories = this._categoriesbl.GetById(id.Value);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Panel/Categories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,Description")] Category categories)
        {
            if (ModelState.IsValid)
            {
                this._categoriesbl.Update(categories);

                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: Panel/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category categories = this._categoriesbl.GetById(id.Value);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Panel/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category categories = this._categoriesbl.GetById(id);
            this._categoriesbl.Delete(categories);

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