namespace Shop.Common.Dtos;

public class DeliveryOptionDetailsDto
{
    public string DeliveryOptionId { get; set; }
    public string DeliveryOptionName { get; set; }
    public decimal DeliveryOptionPrice { get; set; }
    public int DeliveryOptionDays { get; set; }
}