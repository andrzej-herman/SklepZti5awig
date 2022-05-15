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

        public IEnumerable<Product> GetProductsToTable(string categoryId)
        {
            var products = _context.Products.Include(p => p.Category)
                .OrderByDescending(p => p.ProductIsPromoted)
                .ThenByDescending(p => p.ProductDateCreated);

            return !string.IsNullOrEmpty(categoryId) 
                ? products.Where(p => p.CategoryId == categoryId) : products;
        }

        public bool AddProduct(Product product, out string error)
        {
            error = string.Empty;
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return false;
            }
           
        }

        public Product GetProductById(string productId)
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.ShopUser)
                .Include(p => p.Comments)
                .Include(p => p.DeliveryOptions)
                .FirstOrDefault(p => p.ProductId == productId);
        }

        public bool AddComment(Comment comment, out string error)
        {
            error = string.Empty;
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return false;
            }
        }
    }
}
