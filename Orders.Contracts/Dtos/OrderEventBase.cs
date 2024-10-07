namespace FoodDeliveryService.Orders.Contracts.Dtos;

// Базовый класс для всех событий
public abstract class OrderEventBase
{
    public Guid OrderId { get; }
    public DateTime DateEvent { get; }

    protected OrderEventBase(Guid orderId)
    {
        OrderId = orderId;
        DateEvent = DateTime.UtcNow;
    }
}