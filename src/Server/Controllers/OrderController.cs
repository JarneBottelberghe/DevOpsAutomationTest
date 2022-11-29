using Microsoft.AspNetCore.Mvc;

using Shared.Orders;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [SwaggerOperation("Returns a list of orders from user.")]
        [HttpGet]
        public async Task<OrderDto.Index> GetIndex()
        {
            return (OrderDto.Index)await orderService.GetOrdersAsync();
        }
    }
}
