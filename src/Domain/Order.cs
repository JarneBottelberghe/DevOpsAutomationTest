namespace Domain;
public class Order
{
    public string? OrderId { get;}
    public double? NetPrice { get; set; }
    private double? NetAmount { get; set; }
    public DateTime? OrderDate { get; set; }
    private Address? DeliveryAddress { get; set; }
    private Address? InvoiceAddress { get; set; }
    public ISet<Item> Items => _items;
    public OrderStatus _orderStatus { get; private set; }
    private ISet<Item> _items = new HashSet<Item>();
    private User? _user;
    private Shipment? _shipment;
    public List<Notification> _notfications = new List<Notification>();

    public Order()
    {

    }

    public void ChangeStatus(OrderStatus status)
    {
        _orderStatus = status;
        _notfications.Add(new Notification(_orderStatus, OrderId));
    }

    public void AddOrderItems(ISet<Item> items)
    {
        _items = items;
    }

    public void RemoveOrderItem(Item item)
    {
        _items.Remove(item);
    }
}
