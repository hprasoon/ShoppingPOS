using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShoppingDataAccess.DataAccess;
using ShoppingDataAccess.Models;
using ShoppingDataAccess.Repository;

namespace ShoppingWebService.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> repository;

        public ProductsController(ShoppinDBContext context)
        {
            repository = new ProductRepository(context);
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = repository.GetItem((long)id);
            if (product == null)
            {
                return null; ;
            }

            return product;
        }

        [HttpPost]
        public void Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(product);
            }
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Update(product);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id == 0)
            {
                return;
            }

            var product = repository.GetItem((int)id);
            if (product == null)
            {
                return;
            }

            repository.Delete(product.product_Id);
        }
    }
}