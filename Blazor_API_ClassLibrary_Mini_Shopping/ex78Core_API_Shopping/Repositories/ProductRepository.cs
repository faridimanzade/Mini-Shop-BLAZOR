using ex78Core_API_Shopping.Abstractions;
using ex78Core_API_Shopping.DbContexts;
using ex78Core_ClassLibrary_Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_API_Shopping.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingContext dbContext;

        public ProductRepository(ShoppingContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        //============================================== ALL PRODUCTS
        public List<Product> AllProducts()
        {
            return dbContext.Products.ToList();
        }

        //============================================== BUY PRODUCTS
        public void BuyProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                var foundProduct = dbContext.Products.FirstOrDefault(x => x.id == product.id);
                foundProduct.Amount -= product.Amount;
                dbContext.SaveChanges();
            }
        }

        //============================================== CREATE NEW PRODUCT
        public bool CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            var result = dbContext.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //============================================== GET SPECIFIED PRODUCT
        public Product GetProduct(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.id == id);

            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }
    }
}
