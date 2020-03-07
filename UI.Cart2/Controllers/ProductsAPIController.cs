using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Cart;
using Entities.Cart;

namespace UI.Cart2.Controllers
{
    public class ProductsAPIController : ApiController
    {
        private ICategoriesBL _categoriesbl;
        private IProductsBL _productsbl;
        public ProductsAPIController()
        {
            this._categoriesbl = new CategoriesBL();
            this._productsbl = new ProductsBL();
        }
        
        // GET api/ProductsAPI
        public IEnumerable<Product> GetAllProducts()
        {
            var products = this._productsbl.GetAll();
            return products;
        }

        // GET api/ProductsAPI/id
        public IHttpActionResult GetProduct(int id)
        {
            var products = this._productsbl.GetAll();
            var product = products.FirstOrDefault((p) => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            var products = this._productsbl.GetAll();
            return products.Where(
                (p) => string.Equals(p.Category.CategoryName, category,
                    StringComparison.OrdinalIgnoreCase));
        }
        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}