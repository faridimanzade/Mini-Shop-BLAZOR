using ex78Core_ClassLibrary_Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_API_Shopping.Abstractions
{
    public interface IProductRepository
    {
        List<Product> AllProducts();

        Product GetProduct(int id);

        bool CreateProduct(Product product);

        void BuyProducts(List<Product> products);
    }
}
