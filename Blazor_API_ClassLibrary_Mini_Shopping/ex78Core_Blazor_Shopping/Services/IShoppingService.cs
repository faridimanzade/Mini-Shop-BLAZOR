using ex78Core_ClassLibrary_Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_Blazor_Shopping.Services
{
    public interface IShoppingService
    {
        Task<List<Product>> AllProducts();

        Task CreateProduct(Product product);

        Task<Product> GetProduct(int id);

        Task BuyProducts(List<Product> products);
    }
}
