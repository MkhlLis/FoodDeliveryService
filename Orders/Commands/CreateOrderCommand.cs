namespace FoodDeliveryService.Orders.Commands;

public class CreateOrderCommand(string customerName)
{
    public string CustomerName { get; } = customerName;
}