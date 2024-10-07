namespace FoodDeliveryService.Orders.Contracts.Dtos;

// Событие завершения заказа
public class OrderCompletedEvent : OrderEventBase
{
    public OrderCompletedEvent(Guid orderId)
        : base(orderId)
    {
    }
}