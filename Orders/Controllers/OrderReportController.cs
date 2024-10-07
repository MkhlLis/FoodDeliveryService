using FoodDeliveryService.Orders.Agregators;
using FoodDeliveryService.Orders.Contracts.Dtos;
using FoodDeliveryService.Orders.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.Orders.Controllers;

[ApiController]
[Route("OrderReports")]
public class OrderReportController
{
    private readonly IEventStore _eventStore;
    public OrderReportController(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    [HttpGet("order-report")]
    public IEnumerable<OrderEventBase> GetOrderReport(Guid orderId)
    {
        var events = _eventStore.GetEvents(orderId);
        return events;
    }

    [HttpGet("order-info")]
    public Order GetOrderInfo([FromQuery] Guid orderId)
    {
        var order = new Order(_eventStore.GetEvents(orderId));
        return order;
    }
}