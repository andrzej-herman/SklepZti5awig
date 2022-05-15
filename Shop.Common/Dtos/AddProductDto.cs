using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Common.Dtos;

public class AddProductDto
{
    [Required]
    [StringLength(200)]
    public string CategoryId { get; set; }
    
    [Required]
    [StringLength(200)]
    public string ShopUserId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string ProductName { get; set; }
    
    [Required]
    public string ProductDescription { get; set; }
    
    [Required]
    public int ProductQuantity { get; set; }
    
    [Required]
    public decimal ProductPrice { get; set; }
    
    [Required]
    public bool ProductIsPromoted { get; set; }
    
    [Required] public List<string> AvailableDeliveryOptions { get; set; }
    
}