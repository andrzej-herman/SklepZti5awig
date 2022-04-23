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

    }
}