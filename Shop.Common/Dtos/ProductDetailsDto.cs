namespace Shop.Common.Dtos;

public class ProductDetailsDto
{
    public string ProductId { get; set; }
    public string ShopUserId { get; set; }
    public string ShopUserName { get; set; }
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductQuantity { get; set; }
    public decimal ProductPrice { get; set; }
    public List<DeliveryOptionDetailsDto> DeliveryOptions { get; set; }
    public List<CommentDto> Comments { get; set; }

    public double AverageNote
    {
        get
        {
            if (Comments == null) return 0;
            if (!Comments.Any()) return 0;
            var sum = Convert.ToDouble(Comments.Sum(c => c.Note));
            return sum / Comments.Count;
        }
    }
    
}