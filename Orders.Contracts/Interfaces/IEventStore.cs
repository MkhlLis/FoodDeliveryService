using FoodDeliveryService.Orders.Contracts.Dtos;

namespace FoodDeliveryService.Orders.Contracts.Interfaces;

public interface IEventStore 
{
    void SaveEvent(OrderEventBase orderEvent);
    Task<IEnumerable<OrderEventBase>> GetEvents(Guid orderId);
}