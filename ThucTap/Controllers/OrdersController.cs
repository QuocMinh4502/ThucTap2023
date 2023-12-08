using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Commands;
using ThucTap.Models;
using ThucTap.Queries;
using static ThucTap.Queries.GetListQuery;
using static ThucTap.Queries.GetByIdQuery;
using static ThucTap.Commands.CreateCommands;
using static ThucTap.Commands.DeleteCommands;
using static ThucTap.Commands.UpdateCommands;

namespace ThucTap.Controllers
{
  // OrdersController
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator mediator;

    public OrdersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<List<OrderDetails>> GetOrderListAsync()
    {
            var orderDetails = await mediator.Send(new GetOrderListQuery());
        return orderDetails;
    }

    [HttpGet("{orderId}")]
    public async Task<OrderDetails> GetOrderByIdAsync(int orderId)
    {
        var orderDetails = await mediator.Send(new GetOrderByIdQuery() { Id = orderId });
        return orderDetails;
    }

    [HttpPost]
    public async Task<OrderDetails> AddOrderAsync(OrderDetails orderDetails)
    {
        var orderDetail = await mediator.Send(new CreateOrderCommand(
            orderDetails.Customer,
            orderDetails.Products,
            orderDetails.OrderDate,
            orderDetails.TotalAmount));
        return orderDetail;
    }

    [HttpPut]
    public async Task<int> UpdateOrderAsync(OrderDetails orderDetails)
    {
        var isOrderDetailUpdated = await mediator.Send(new UpdateOrderCommand(
           orderDetails.OrderId,
           orderDetails.Customer,
           orderDetails.Products,
           orderDetails.OrderDate,
           orderDetails.TotalAmount));
        return isOrderDetailUpdated;
    }

    [HttpDelete("{orderId}")]
    public async Task<int> DeleteOrderAsync(int orderId)
    {
        return await mediator.Send(new DeleteOrderCommand() { Id = orderId });
    }
}

}
