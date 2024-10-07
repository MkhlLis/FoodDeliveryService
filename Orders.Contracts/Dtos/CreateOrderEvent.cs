namespace FoodDeliveryService.Orders.Contracts.Dtos;

/// <summary>
/// Событие создания заказа.
/// </summary>
public class CreateOrderEvent : OrderEventBase
{
    public string CustomerName { get; }
    
    public CreateOrderEvent(Guid orderId, string customerName) : base(orderId)
    {
        CustomerName = customerName;
    }
}