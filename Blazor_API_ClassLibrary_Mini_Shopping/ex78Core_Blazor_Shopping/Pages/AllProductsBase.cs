using ex78Core_Blazor_Shopping.Services;
using ex78Core_ClassLibrary_Shopping;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_Blazor_Shopping.Pages
{
    public class AllProductsBase : ComponentBase
    {
        [Inject]
        public IShoppingService ShoppingService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Product> Products { get; set; }
        public List<Product> SelectedProducts { get; set; }
        public decimal TotalPrice = 0;


        protected override async Task OnInitializedAsync()
        {
            Products = await ShoppingService.AllProducts();
            SelectedProducts = new List<Product>();
        }

        public async Task AddToChart(int id)
        {
            var product = await ShoppingService.GetProduct(id);
            var inListProduct = SelectedProducts.FirstOrDefault(x => x.id == id);

            if (inListProduct != null)
            {
                if (inListProduct.Amount < product.Amount)
                {
                    inListProduct.Amount++;
                }
            }
            else
            {
                product.Amount = 1;
                SelectedProducts.Add(product);
            }
            TotalPriceCalculator();
        }

        public void RemoveAll(int id)
        {
            var productRemovedAll = SelectedProducts.RemoveAll(x => x.id == id);
            TotalPriceCalculator();
        }

        public void RemoveOne(int id)
        {
            SelectedProducts.FirstOrDefault(x => x.id == id).Amount--;
            TotalPriceCalculator();
        }

        public void ClearList()
        {
            SelectedProducts.Clear();
            TotalPriceCalculator();
        }

        public async Task BuyProducts()
        {
            await ShoppingService.BuyProducts(SelectedProducts);
            NavigationManager.NavigateTo("/allproducts", true);
        }

        private void TotalPriceCalculator()
        {
            if (SelectedProducts != null || SelectedProducts.Count > 0)
            {
                TotalPrice = 0;

                foreach (var item in SelectedProducts)
                {
                    TotalPrice = TotalPrice + (item.Price * item.Amount);
                }
            }
        }
    }
}
