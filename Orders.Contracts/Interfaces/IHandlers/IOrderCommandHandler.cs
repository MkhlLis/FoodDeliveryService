using FoodDeliveryService.Orders.Commands;

namespace FoodDeliveryService.Orders.Contracts.Interfaces.IHandlers;

public interface IOrderCommandHandler
{
    Guid Handle(CreateOrderCommand command);
    void Handle(AddMenuOptionToOrderCommand command);
    void Handle(CompleteOrderCommand command);
}