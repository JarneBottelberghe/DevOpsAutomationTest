namespace Shared.Orders;
using Domain;
public static class OrderDto
{
    public class Index
    {
        public string? OrderId { get; set; }
        public string? Reference { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        public List<Notification> notifications = new List<Notification>();
    }

    public class Create
    {
        public string? Reference { get; set; }

        public List<Notification> notifications = new List<Notification>();
        public IEnumerable<OrderItemDto.Create> Items { get; set; } = default!;
        public IEnumerable<PackageDto.Create> Packages { get; set; } = default!;
    }
}
