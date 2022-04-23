using Shop.Api.Entities;

namespace Shop.Api.Repository
{
    public interface IShopRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<DeliveryOption> GetDeliveryOptions();
        IEnumerable<Product> GetProductsToTable();
    }
}
