using FoodDeliveryService.Orders.Agregators;
using FoodDeliveryService.Orders.Contracts.Dtos;
using FoodDeliveryService.Orders.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.Orders.Controllers;

/// <summary>
/// Запрос информации о заказе.
/// </summary>
[ApiController]
[Route("OrderReports")]
public class OrderReportController
{
    private readonly IEventStore _eventStore;
    public OrderReportController(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    /// <summary>
    /// Отчет о стадиях изменения заказа.
    /// </summary>
    /// <param name="orderId">Идентификатор заказа.</param>
    /// <returns>Список событий формирующих заказ.</returns>
    [HttpGet("order-report")]
    public async Task<IEnumerable<OrderEventBase>> GetOrderReport(Guid orderId)
    {
        var events = await _eventStore.GetEvents(orderId);
        return events;
    }

    /// <summary>
    /// Информация о текущем состоянии заказа.
    /// </summary>
    /// <param name="orderId">Идентификатор заказа.</param>
    /// <returns>Текущее состояние заказа.</returns>
    [HttpGet("order-info")]
    public async Task<Order> GetOrderInfo([FromQuery] Guid orderId)
    {
        var events = await _eventStore.GetEvents(orderId);
        var order = new Order(events);
        return order;
    }
}