using Shop.Common.Entities;

namespace Shop.Api.Services
{
    public interface IShopService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetCategories();
        IEnumerable<DeliveryOption> GetDeliveryOptions();
        Product GetProductById(string productId);
        string AddProduct(Product product);
    }
}
