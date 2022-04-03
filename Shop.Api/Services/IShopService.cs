using Shop.Common.Entities;

namespace Shop.Api.Services
{
    public interface IShopService
    {
        IEnumerable<Product> GetProducts(string categoryId);
        IEnumerable<Category> GetCategories();
        IEnumerable<DeliveryOption> GetDeliveryOptions();
        Product GetProductById(string productId);
        Product AddProduct(Product product);
        Comment AddComment(Comment comment);
    }
}
