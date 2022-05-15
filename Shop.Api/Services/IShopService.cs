

using Shop.Api.Entities;
using Shop.Common.Dtos;

namespace Shop.Api.Services
{
    public interface IShopService
    {
        IEnumerable<CategoryDto> GetCategories();
        IEnumerable<DeliveryOptionDto> GetDeliveryOptions();
        IEnumerable<ProductToTableDto> GetProductsToTable(string categoryId);
        ResponseDto AddProduct(AddProductDto dto);
        ProductDetailsDto GetProductById(string productId);
        ResponseDto AddComment(AddCommentDto dto);
        
    }
}
