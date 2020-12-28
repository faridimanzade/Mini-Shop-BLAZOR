using ex78Core_Blazor_Shopping.Services;
using ex78Core_ClassLibrary_Shopping;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_Blazor_Shopping.Pages
{
    public class CreateProductBase : ComponentBase
    {
        [Inject]
        public IShoppingService ProductService { get; set; }
        public Product Product { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }

        [Inject]
        public NavigationManager nav { get; set; }

        protected override Task OnInitializedAsync()
        {
            Product = new Product();
            return base.OnInitializedAsync();
        }

        public async Task CreateProduct()
        {
            Product.Price = decimal.Parse(Price);
            Product.Amount = int.Parse(Amount);

            await ProductService.CreateProduct(Product);
            nav.NavigateTo("/allproducts");
        }
    }
}
