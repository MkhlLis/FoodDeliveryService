namespace FoodDeliveryService.Administration.Contracts;

public class PageFilter
{
    public string PartText { get; set; }

    public decimal PriceMin { get; set; }
    
    public decimal PriceMax { get; set; }
    
    public int PageSize { get; set; }
    
    public int PageNumber { get; set; }
}