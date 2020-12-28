using ex78Core_ClassLibrary_Shopping;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ex78Core_Blazor_Shopping.Services
{
    public class ShoppingService : IShoppingService
    {

        private readonly HttpClient httpClient;

        public ShoppingService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<List<Product>> AllProducts()
        {
            var products = await httpClient.GetJsonAsync<List<Product>>("api/shopping/allproducts");
            return products;
        }

        public async Task BuyProducts(List<Product> products)
        {
            await httpClient.PostJsonAsync($"api/shopping/BuyProducts", products);
        }

        public async Task CreateProduct(Product product)
        {
            await httpClient.PostJsonAsync($"api/shopping/Createproduct", product);
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await httpClient.GetJsonAsync<Product>($"api/shopping/getproduct/{id}");
            return product;
        }
    }
}
