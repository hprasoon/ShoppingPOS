using System.Collections.Generic;
using System.Linq;
using ShoppingDataAccess.DataAccess;
using ShoppingDataAccess.Models;

namespace ShoppingDataAccess.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        ShoppinDBContext _shoppinDBContext;
        public ProductRepository(ShoppinDBContext shoppinDBContext)
        {
            _shoppinDBContext = shoppinDBContext;
        }

        public bool Delete(long Id)
        {
            var product = _shoppinDBContext.Products.Where(x => x.product_Id == Id).First();
            _shoppinDBContext.Products.Remove(product);
            _shoppinDBContext.SaveChanges();
            return true;
        }

        public List<Product> GetAll()
        {
            return _shoppinDBContext.Products.ToList();
        }

        public Product GetItem(long Id)
        {
            var product = _shoppinDBContext.Products.Where(x => x.product_Id == Id).First();
            return product;
        }

        public bool Insert(Product product)
        {
            if (product.product_Id <= 0)
                _shoppinDBContext.Products.Add(product);
            else
            {
                var updateProduct = _shoppinDBContext.Products.Where(x => x.product_Id == product.product_Id).First();
                updateProduct = product;
            }
            _shoppinDBContext.SaveChanges();
            return true;
        }

        public bool Update(Product product)
        {
            var updateProduct = _shoppinDBContext.Products.Where(x => x.product_Id == product.product_Id).First();
            product = updateProduct;

            _shoppinDBContext.SaveChanges();
            return true;
        }
    }
}