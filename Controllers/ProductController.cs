using Catalog.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private static readonly string[] Products = new[]
        {"Apple", "Orange","Tea", "Meat", "Eggs","Water","Juice" };

        private static readonly string[] Description = new[]
            {"Red apple", "The best oranges","Black tea", "Porkies meat", "Eggs","Water","Orange juice" };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            return Enumerable.Range(1, Products.Length).Select(i => new Product()
            {
                Name = Products[Random.Shared.Next(Products.Length)],
                Description = Description[Random.Shared.Next(Description.Length)],
                Price = Math.Round(Random.Shared.NextDouble() * 100 + 10, 4)
            }).ToArray();
        }
    }
}
