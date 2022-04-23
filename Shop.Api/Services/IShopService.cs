

using Shop.Api.Entities;
using Shop.Common.Dtos;

namespace Shop.Api.Services
{
    public interface IShopService
    {
        IEnumerable<CategoryDto> GetCategories();
        IEnumerable<DeliveryOptionDto> GetDeliveryOptions();
        IEnumerable<ProductToTableDto> GetProductsToTable();





        // Product GetProductById(string productId);
        // Product AddProduct(Product product);
        // Comment AddComment(Comment comment);
    }
}
