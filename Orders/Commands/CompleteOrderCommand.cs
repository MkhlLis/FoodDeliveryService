namespace FoodDeliveryService.Orders.Commands;

public class CompleteOrderCommand(Guid orderId)
{
    public Guid OrderId { get; } = orderId;
}