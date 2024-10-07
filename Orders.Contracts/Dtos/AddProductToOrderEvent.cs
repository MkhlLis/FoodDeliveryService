namespace FoodDeliveryService.Orders.Contracts.Dtos;

/// <summary>
/// Событие добавление продукта в заказ.
/// </summary>
public class AddProductToOrderEvent : OrderEventBase
{
    public string MenuOption { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    public AddProductToOrderEvent(Guid orderId, string menuOption, int quantity, decimal price)
        : base(orderId)
    {
        MenuOption = menuOption;
        Quantity = quantity;
        Price = price;
    }
}