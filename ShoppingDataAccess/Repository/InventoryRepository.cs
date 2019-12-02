using System.Collections.Generic;
using System.Linq;
using ShoppingDataAccess.DataAccess;
using ShoppingDataAccess.Models;

namespace ShoppingDataAccess.Repository
{
    public class InventoryRepository : IRepository<Inventory>
    {
        ShoppinDBContext _shoppinDBContext;
        public InventoryRepository(ShoppinDBContext shoppinDBContext)
        {
            _shoppinDBContext = shoppinDBContext;
        }

        public bool Delete(long Id)
        {
            var product = _shoppinDBContext.Inventory.Where(x => x.product_Id == Id).First();
            _shoppinDBContext.Inventory.Remove(product);
            _shoppinDBContext.SaveChanges();
            return true;
        }

        public List<Inventory> GetAll()
        {
            return _shoppinDBContext.Inventory.ToList();
        }

        public Inventory GetItem(long Id)
        {
            var inventory = _shoppinDBContext.Inventory.Where(x => x.inventory_Id == Id).First();
            return inventory;
        }

        public bool Insert(Inventory inventory)
        {
            if (inventory.product_Id <= 0)
                _shoppinDBContext.Inventory.Add(inventory);
            else
            {
                var updateInventory = _shoppinDBContext.Inventory.Where(x => x.product_Id == inventory.product_Id).First();
                updateInventory = inventory;
            }
            _shoppinDBContext.SaveChanges();
            return true;
        }

        public bool Update(Inventory inventory)
        {
            var updateInventory = _shoppinDBContext.Inventory.Where(x => x.inventory_Id == inventory.inventory_Id).First();
            inventory = updateInventory;

            _shoppinDBContext.SaveChanges();
            return true;
        }
    }
}