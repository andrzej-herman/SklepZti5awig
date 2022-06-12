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
        
        public IEnumerable<ProductToTableDto> GetProductsToTable(string categoryId)
        {
            return _repo.GetProductsToTable(categoryId).Select(p => new ProductToTableDto() 
            { 
                ProductId = p.ProductId,
                CategoryName = p.Category.CategoryName,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductQuantity = p.ProductQuantity
            });
        }
        
        public ResponseDto AddProduct(AddProductDto dto)
        {
            var product = new Product()
            {
                ProductId = Guid.NewGuid().ToString().Replace("-", ""),
                ShopUserId = dto.ShopUserId,
                CategoryId = dto.CategoryId,
                ProductName = dto.ProductName,
                ProductDescription = dto.ProductDescription,
                ProductQuantity = dto.ProductQuantity,
                ProductPrice = dto.ProductPrice,
                ProductIsPromoted = dto.ProductIsPromoted
            };
        
            var dbDeliveryOptions = _repo.GetDeliveryOptions()
                .Where(o => dto.AvailableDeliveryOptions.Contains(o.DeliveryOptionId));
        
            foreach (var dbdo in dbDeliveryOptions)
            {
                product.DeliveryOptions.Add(dbdo);
            }
        
            var result = _repo.AddProduct(product, out var error);
            return result ? 
                new ResponseDto() {Result = true, Description = "Produkt został pomyślnie dodany."} 
                : new ResponseDto() {Result = false, Description = $"Błąd podcazas dodawania produktu: {error}"};
        }
        
        public ProductDetailsDto GetProductById(string productId)
        {
            var product = _repo.GetProductById(productId);
            var dto = new ProductDetailsDto
            {
                ProductId = product.ProductId,
                ShopUserId = product.ShopUserId,
                ShopUserName = $"{product.ShopUser.UserFirstName} {product.ShopUser.UserLastName}",
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                DeliveryOptions = new List<DeliveryOptionDetailsDto>()
            };
        
            foreach (var pdo in product.DeliveryOptions)
            {
                dto.DeliveryOptions.Add(new DeliveryOptionDetailsDto()
                {
                    DeliveryOptionId = pdo.DeliveryOptionId,
                    DeliveryOptionName = pdo.DeliveryOptionName,
                    DeliveryOptionPrice = pdo.DeliveryOptionPrice,
                    DeliveryOptionDays = pdo.DeliveryOptionDays
                });
            }
        
            dto.Comments = new List<CommentDto>();
            foreach (var pc in product.Comments)
            {
                dto.Comments.Add(new CommentDto()
                {
                    CommentId = pc.CommentId,
                    CommentText = pc.CommentText,
                    Note  = pc.Note
                });
        
            }
        
            return dto;
        }
        
        public ResponseDto AddComment(AddCommentDto dto)
        {
            var comment = new Comment()
            {
                CommentId = Guid.NewGuid().ToString().Replace("-", ""),
                ProductId = dto.ProductId,
                CommentText = dto.CommentText,
                Note = dto.Note,
            };
            
            var result = _repo.AddComment(comment, out var error);
            return result ? 
                new ResponseDto() {Result = true, Description = "Komentarz został dodany."} 
                : new ResponseDto() {Result = false, Description = $"Błąd podcazas dodawania komentarza: {error}"};
        }
    }
}
