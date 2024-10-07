using FoodDeliveryService.Orders.Commands;
using FoodDeliveryService.Orders.Contracts.Dtos;
using FoodDeliveryService.Orders.Contracts.Interfaces;
using FoodDeliveryService.Orders.Contracts.Interfaces.IHandlers;

namespace FoodDeliveryService.Orders.Handlers;

public class OrderCommandHandler : IOrderCommandHandler
{
    private readonly IEventStore _eventStore;

    public OrderCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public Guid Handle(CreateOrderCommand command)
    {
        var orderId = Guid.NewGuid();
        var orderCreatedEvent = new CreateOrderEvent(orderId, command.CustomerName);
        _eventStore.SaveEvent(orderCreatedEvent);
        return orderId;
    }

    public void Handle(AddMenuOptionToOrderCommand command)
    {
        var addProductEvent = new AddProductToOrderEvent(command.OrderId, command.Name, 
            command.Quantity, command.Price);
        _eventStore.SaveEvent(addProductEvent);
    }

    public void Handle(CompleteOrderCommand command)
    {
        var orderCompletedEvent = new OrderCompletedEvent(command.OrderId);
        _eventStore.SaveEvent(orderCompletedEvent);
    }
}