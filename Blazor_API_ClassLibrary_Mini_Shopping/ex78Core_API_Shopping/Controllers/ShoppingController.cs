using ex78Core_API_Shopping.Abstractions;
using ex78Core_ClassLibrary_Shopping;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex78Core_API_Shopping.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ShoppingController(IProductRepository _repository)
        {
            this.repository = _repository;
        }

        //================================================ ALL PRODUCTS
        [HttpGet]
        public List<Product> AllProducts()
        {
            return repository.AllProducts();
        }

        //================================================ GET SPECIFIED PRODUCT
        [HttpGet("{id:int}")]
        public Product GetProduct(int id)
        {
            return repository.GetProduct(id);
        }

        //================================================ CREATE NEW PRODUCT
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (repository.CreateProduct(product))
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        //===================================================== BUY PRODUCTS
        [HttpPost]
        public IActionResult BuyProducts(List<Product> products)
        {
            repository.BuyProducts(products);
            return Ok();
        }
    }
}
