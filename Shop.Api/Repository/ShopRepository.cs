using Microsoft.EntityFrameworkCore;
using Shop.Api.Entities;

namespace Shop.Api.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly SanShopContext _context;

        public ShopRepository(SanShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.CategoryName);
        }

        public IEnumerable<DeliveryOption> GetDeliveryOptions()
        {
            return _context.DeliveryOptions.OrderBy(d => d.DeliveryOptionPrice);
        }

        public IEnumerable<Product> GetProductsToTable()
        {
            return _context.Products.Include(p => p.Category)
                .OrderByDescending(p => p.ProductIsPromoted)
                .ThenByDescending(p => p.ProductDateCreated);
        }
    }
}
