using FoodDeliveryService.Orders.Commands;
using FoodDeliveryService.Orders.Contracts.Interfaces.IHandlers;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.Orders.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController
{
    private readonly IOrderCommandHandler _orderCommandHandler;

    public OrdersController(IOrderCommandHandler orderCommandHandler)
    {
        _orderCommandHandler = orderCommandHandler;
    }
    
    [HttpGet("create-new-order")]
    public Guid CreateNewOrderAsync(string customerName)
    {
        var orderId = _orderCommandHandler.Handle(new CreateOrderCommand(customerName));
        return orderId;
    }

    [HttpGet("add-menu-option")]
    public void AddNewMenuOption([FromQuery] Guid orderId, [FromQuery] string name, [FromQuery] int quantity, [FromQuery] decimal price)
    {
        _orderCommandHandler.Handle(new AddMenuOptionToOrderCommand(orderId, name, quantity, price));
    }

    [HttpGet("complete-order")]
    public void CompleteOrder([FromQuery] Guid orderId)
    {
        _orderCommandHandler.Handle(new CompleteOrderCommand(orderId));
    }
}