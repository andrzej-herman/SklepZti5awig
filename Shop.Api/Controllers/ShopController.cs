using Microsoft.AspNetCore.Mvc;
using Shop.Api.Services;
using Shop.Common;
using Shop.Common.Dtos;


namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("shop")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _service;

        public ShopController(IShopService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/categories")]
        public IEnumerable<CategoryDto> GetCategories()
        {
           return _service.GetCategories();
        }

        [HttpGet]
        [Route("/deliveries")]
        public IEnumerable<DeliveryOptionDto> GetDeliveries()
        {
            return _service.GetDeliveryOptions();
        }
        
        [HttpGet]
        [Route("/productstotable")]
        public IEnumerable<ProductToTableDto> GetProductsToTable([FromQuery] string categoryId)
        {
            return _service.GetProductsToTable(categoryId);
        }
        
        [HttpPost]
        [Route("/addproduct")]
        public ResponseDto AddProduct(AddProductDto dto)
        {
            return _service.AddProduct(dto);
        }
        
        [HttpGet]
        [Route("/productdetails")]
        public ProductDetailsDto GetProductById(string productId)
        {
            return _service.GetProductById(productId);
        }
        
        [HttpPost]
        [Route("/comment")]
        public ResponseDto AddComment(AddCommentDto dto)
        {
            return _service.AddComment(dto);
        }
        
    }
}