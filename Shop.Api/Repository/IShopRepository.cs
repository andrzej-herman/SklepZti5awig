using Shop.Api.Entities;

namespace Shop.Api.Repository
{
    public interface IShopRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<DeliveryOption> GetDeliveryOptions();
        IEnumerable<Product> GetProductsToTable(string categoryId);
        bool AddProduct(Product product, out string error);
        Product GetProductById(string productId);
        bool AddComment(Comment comment, out string error);
    }
}
