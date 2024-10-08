using FoodDeliveryService.Orders.Contracts.Dtos;

namespace FoodDeliveryService.Orders.Agregators;

public class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public List<OrderMenuOptionDto> Products { get; } = new();
    public bool IsCompleted { get; private set; }

    public Order(IEnumerable<OrderEventBase> events)
    {
        foreach (var orderEvent in events)
        {
            Apply(orderEvent);
        }
    }

    private void Apply(OrderEventBase orderEvent)
    {
        switch (orderEvent)
        {
            case CreateOrderEvent createdEvent:
                Id = createdEvent.OrderId;
                CustomerName = createdEvent.CustomerName;
                break;
            case AddProductToOrderEvent productAddedEvent:
                Products.Add(new OrderMenuOptionDto
                {
                    Name = productAddedEvent.MenuOption,
                    Quantity = productAddedEvent.Quantity,
                    Price = productAddedEvent.Price,
                });
                break;
            case OrderCompletedEvent _:
                IsCompleted = true;
                break;
        }
    }
}