using FoodDeliveryService.Orders.Contracts.Dtos;
using FoodDeliveryService.Orders.Contracts.Interfaces;

namespace FoodDeliveryService.Orders.EventStores;

public class InMemoryEventStore: IEventStore
{
    private readonly List<OrderEventBase> _events = new();

    public void SaveEvent(OrderEventBase orderEvent)
    {
        _events.Add(orderEvent);
    }

    public Task<IEnumerable<OrderEventBase>> GetEvents(Guid orderId)
    {
        return Task.FromResult(_events.Where(e => e.OrderId == orderId));
    }
}