namespace FoodDeliveryService.Orders.Commands;

public class AddMenuOptionToOrderCommand(Guid orderId, string name, int quantity, decimal price)
{
    public Guid OrderId { get; } = orderId;
    public string Name { get; } = name;
    public int Quantity { get; } = quantity;
    public decimal Price { get; } = price;
}