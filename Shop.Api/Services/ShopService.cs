using Shop.Api.Entities;
using Shop.Api.Repository;
using Shop.Common;
using Shop.Common.Dtos;

namespace Shop.Api.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _repo;

        public ShopService(IShopRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return _repo.GetCategories().Select(c => new CategoryDto()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
            });
        }

        public IEnumerable<DeliveryOptionDto> GetDeliveryOptions()
        {
            return _repo.GetDeliveryOptions().Select(c => new DeliveryOptionDto()
            {
                DeliveryOptionId = c.DeliveryOptionId,
                DeliveryOptionName = c.DeliveryOptionName
            });
        }

        public IEnumerable<ProductToTableDto> GetProductsToTable()
        {
            return _repo.GetProductsToTable().Select(p => new ProductToTableDto() 
            { 
                ProductId = p.ProductId,
                CategoryName = p.Category.CategoryName,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductQuantity = p.ProductQuantity
            });
        }
    }
}
