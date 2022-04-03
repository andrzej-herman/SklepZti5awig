using Shop.Common;
using Shop.Common.Entities;

namespace Shop.Api.Services
{
    public class ShopService : IShopService
    {
        private List<Product> _products = new List<Product>();
        private List<Comment> _comments = new List<Comment>();

        private readonly List<Category> _categories = new List<Category>()
        {
            new() { CategoryId = Helper.GetKey(), Name = "Elektronika" },
            new() { CategoryId = Helper.GetKey(), Name = "Dom i ogród" },
            new() { CategoryId = Helper.GetKey(), Name = "Odzież męska" },
            new() { CategoryId = Helper.GetKey(), Name = "Odzież damska" },
            new() { CategoryId = Helper.GetKey(), Name = "Odzież dziecięca" },
            new() { CategoryId = Helper.GetKey(), Name = "Kosmetyki i uroda" },
            new() { CategoryId = Helper.GetKey(), Name = "Inne" }
        };

        private readonly List<DeliveryOption> _deliveryOptions = new List<DeliveryOption>
        {
            new() 
            {
                DeliveryOptionId = Helper.GetKey(), 
                DeliveryOptionName = "Poczta Polska",
                DeliveryOptionPrice = 6.99m,
                DeliveryOptionDays = 7
            },
            new()
            {
                DeliveryOptionId = Helper.GetKey(),
                DeliveryOptionName = "Paczkomat InPost",
                DeliveryOptionPrice = 10.99m,
                DeliveryOptionDays = 3
            },
            new()
            {
                DeliveryOptionId = Helper.GetKey(),
                DeliveryOptionName = "Kurier DHL",
                DeliveryOptionPrice = 17.99m,
                DeliveryOptionDays = 1
            }
        };


        public Product AddProduct(Product product)
        {
            _products.Add(product);
            return product;
        }

        public Comment AddComment(Comment comment)
        {
            _comments.Add(comment);
            return comment;
        }

        public IEnumerable<Product> GetProducts(string categoryId)
        {
            var products = categoryId == null ? _products : _products.Where(p => p.Category.CategoryId == categoryId).ToList();
            products.ForEach(p => p.Comments = _comments.Where(c => c.ProductId == p.ProductId).ToList());
            return products;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public IEnumerable<DeliveryOption> GetDeliveryOptions()
        {
            return _deliveryOptions;
        }

        public Product GetProductById(string productId)
        {
            var product = _products.SingleOrDefault(p => p.ProductId == productId);
            product.Comments = _comments.Where(c => c.ProductId == productId).ToList();
            return product;
        }
    }
}
