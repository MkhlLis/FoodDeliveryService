using FoodDeliveryService.Orders.Contracts.Dtos;

namespace FoodDeliveryService.Orders.Agregators;

public class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public List<(string ProductName, int Quantity, decimal Price)>
        Products { get; private set; } = new List<(string, int, decimal)>();
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
                Products.Add((productAddedEvent.MenuOption, productAddedEvent.Quantity, 
                    productAddedEvent.Price));
                break;
            case OrderCompletedEvent _:
                IsCompleted = true;
                break;
        }
    }
}