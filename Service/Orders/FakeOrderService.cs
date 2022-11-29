using Domain;
using Shared.Orders;
namespace Services.Orders;

public class FakeOrderService : IOrderService
{
    private List<OrderDto.Index> orders = new();
    public FakeOrderService()
    {
        orders.Add(new OrderDto.Index
        {
            OrderId = "B11422-d55162",
            Reference = "PIX",
            OrderDate = new DateTime(2023, 2, 14),
            OrderStatus = 1,
            notifications = { new Notification(OrderStatus.CREATED, "B11422-d55162") }
        });
        orders.Add(new OrderDto.Index
        {
            OrderId = "B11422-d55182",
            Reference = "PIX",
            OrderDate = new DateTime(2022, 2, 16),
            OrderStatus = 1,
            notifications = { new Notification(OrderStatus.CREATED, "B11422-d55182") }
        });
        orders.Add(new OrderDto.Index
        {
            OrderId = "C11422-d55199",
            Reference = "PLS",
            OrderDate = new DateTime(2022, 3, 10),
            OrderStatus = 2,
            notifications = { new Notification(OrderStatus.PROCCESSED, "C11422-d55199") }
        });
        orders.Add(new OrderDto.Index
        {
            OrderId = "B11422-d55442",
            Reference = "PIX",
            OrderDate = new DateTime(2022, 4, 30),
            OrderStatus = 3,
            notifications = { new Notification(OrderStatus.SHIPPED, "B11422-d55442") }
        });
        orders.Add(new OrderDto.Index
        {
            OrderId = "B11422-d55199",
            Reference = "PLS",
            OrderDate = new DateTime(2022, 6, 6),
            OrderStatus = 4,
            notifications = { new Notification(OrderStatus.DELIVERED, "B11422-d55199") }
        });
    }

    public Task<int> CreateAsync(OrderDto.Create model)
    {
        string id = Guid.NewGuid().ToString("N");
        orders.Add(new OrderDto.Index
        {
            OrderId = id,
            Reference = model.Reference,
            OrderDate = new DateTime(),
            OrderStatus = 1,
            notifications = { new Notification(OrderStatus.CREATED, id) }
        });
        return Task.FromResult(1);
    }



    public async Task<OrderDto.Index?> GetOrderDetailAsync(string orderId)
    {
        await Task.Delay(100);
        return orders.Single(x => x.OrderId.Equals(orderId));
    }

    public async Task<IEnumerable<OrderDto.Index>> GetOrdersAsync()
    {
        await Task.Delay(100);
        return orders.AsEnumerable();
    }
}
