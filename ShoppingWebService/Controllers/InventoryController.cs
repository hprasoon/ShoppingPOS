using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoppingDataAccess.DataAccess;
using ShoppingDataAccess.Models;
using ShoppingDataAccess.Repository;

namespace ShoppingWebService.Controllers
{
    [Produces("application/json")]
    [Route("inventory")]
    public class InventoryController : Controller
    {
        private readonly IRepository<Inventory> repository;

        public InventoryController(ShoppinDBContext context)
        {
            repository = new InventoryRepository(context);
        }

        [HttpGet]
        public IEnumerable<Inventory> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Inventory Get(int id)
        {
            var inventory = repository.GetItem((long)id);
            if (inventory == null)
            {
                return null; ;
            }

            return inventory;
        }

        [HttpPost]
        public void Post([FromBody]Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(inventory);
            }
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                repository.Update(inventory);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id == 0)
            {
                return;
            }

            var inventory = repository.GetItem((int)id);
            if (inventory == null)
            {
                return;
            }

            repository.Delete(inventory.inventory_Id);
        }
    }
}