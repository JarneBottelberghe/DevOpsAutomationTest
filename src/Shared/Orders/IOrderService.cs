
namespace Shared.Orders;
public interface IOrderService
{
    Task<OrderDto.Index?> GetOrderDetailAsync(string orderId);
    Task<IEnumerable<OrderDto.Index>> GetOrdersAsync();
    Task<int> CreateAsync(OrderDto.Create model);
}
