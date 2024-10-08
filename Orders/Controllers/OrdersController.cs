using FoodDeliveryService.Orders.Commands;
using FoodDeliveryService.Orders.Contracts.Interfaces.IHandlers;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.Orders.Controllers;

/// <summary>
/// Обработка заказов.
/// </summary>
[ApiController]
[Route("orders")]
public class OrdersController
{
    private readonly IOrderCommandHandler _orderCommandHandler;

    public OrdersController(IOrderCommandHandler orderCommandHandler)
    {
        _orderCommandHandler = orderCommandHandler;
    }
    
    /// <summary>
    /// Создание нового заказа.
    /// </summary>
    /// <param name="customerName">Заказчик.</param>
    /// <returns>Идентификатор заказа.</returns>
    [HttpGet("create-new-order")]
    public Guid CreateNewOrderAsync(string customerName)
    {
        var orderId = _orderCommandHandler.Handle(new CreateOrderCommand(customerName));
        return orderId;
    }

    /// <summary>
    /// Добавление блюда в заказ.
    /// </summary>
    /// <param name="orderId">Идентификатор заказа.</param>
    /// <param name="name">Название блюда.</param>
    /// <param name="quantity">Количество.</param>
    /// <param name="price">Цена.</param>
    [HttpGet("add-menu-option")]
    public void AddNewMenuOption([FromQuery] Guid orderId, [FromQuery] string name, [FromQuery] int quantity, [FromQuery] decimal price)
    {
        _orderCommandHandler.Handle(new AddMenuOptionToOrderCommand(orderId, name, quantity, price));
    }

    /// <summary>
    /// Завершение заказа, заказ выдан.
    /// </summary>
    /// <param name="orderId">Идентификатор заказа.</param>
    [HttpGet("complete-order")]
    public void CompleteOrder([FromQuery] Guid orderId)
    {
        _orderCommandHandler.Handle(new CompleteOrderCommand(orderId));
    }
}