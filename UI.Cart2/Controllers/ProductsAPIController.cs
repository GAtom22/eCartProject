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

        //// GET api/ProductsAPI
        public IHttpActionResult GetAllProducts()
        {
            var products = this._productsbl.GetAll();
            List<ProdAPI> prodAPI = new List<ProdAPI>();

            foreach (var item in products)
            {
                var _prodApi = new ProdAPI();
                _prodApi.ProductID = item.ProductID;
                _prodApi.ProductName = item.ProductName;
                _prodApi.Description = item.Description;
                _prodApi.UnitPrice = item.UnitPrice;
                _prodApi.CategoryID = item.CategoryID;
                prodAPI.Add(_prodApi);
            }
            return Ok(new { results = prodAPI });

        }

        // GET api/ProductsAPI/id
        public IHttpActionResult GetProduct(int id)
        {
            var item = _productsbl.GetById(id);
            var _prodApi = new ProdAPI();
            _prodApi.ProductID = item.ProductID;
            _prodApi.ProductName = item.ProductName;
            _prodApi.Description = item.Description;
            _prodApi.UnitPrice = item.UnitPrice;
            _prodApi.CategoryID = item.CategoryID;
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_prodApi);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            var products = this._productsbl.GetAll();
            return products.Where(
                (p) => string.Equals(p.Category.CategoryName, category,
                    StringComparison.OrdinalIgnoreCase));
        }
       

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


        public class ProdAPI
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }
            public double? UnitPrice { get; set; }
            public int? CategoryID { get; set; }
        }


    }


}