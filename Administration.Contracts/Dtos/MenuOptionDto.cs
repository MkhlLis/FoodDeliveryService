namespace FoodDeliveryService.AdministrationContracts.Dtos;

public class MenuOptionDto
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}