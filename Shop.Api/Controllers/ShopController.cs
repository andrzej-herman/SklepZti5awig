using Microsoft.AspNetCore.Mvc;
using Shop.Api.Services;
using Shop.Common;
using Shop.Common.Entities;
using Shop.Common.Models;

namespace Shop.Api.Controllers
{
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _service;

        public ShopController(IShopService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/products")]
        public IEnumerable<Product> GetProducts([FromQuery] string categoryId)
        {
            return _service.GetProducts(categoryId);
        }


        [HttpGet]
        [Route("/categories")]
        public IEnumerable<Category> GetCategories()
        {
            return _service.GetCategories();
        }

        [HttpGet]
        [Route("/deliveries")]
        public IEnumerable<DeliveryOption> GetDeliveryOptions()
        {
            return _service.GetDeliveryOptions();
        }

        [HttpGet]
        [Route("/product")]
        public Product GetProductById([FromQuery] string productId)
        {
            return _service.GetProductById(productId);
        }


        [HttpPost]
        [Route("/product")]
        public Product AddProduct(AddProductDTO dto)
        {
            var product = new Product
            {
                ProductId = Helper.GetKey(),
                UserId = dto.UserId,
                Category = _service.GetCategories().FirstOrDefault(c => c.CategoryId == dto.CategoryId),
                Name = dto.Name,
                Description = dto.Description,
                Quantity = dto.Quantity,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                IsPromoted = dto.IsPromoted,
                DateAdd = DateTime.Now,
            };

            return _service.AddProduct(product);
        }
    }


    //Comment AddComment(Comment comment);
}