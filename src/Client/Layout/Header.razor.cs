using Client.Components.Products;
using Domain;
using Microsoft.AspNetCore.Components;
using Shared.Orders;

namespace Client.Layout;
public partial class Header
{
    [Inject] public IOrderService? OrderServiceHead { get; set; }
    [Inject] public ShoppingCartState ShoppingCart { get; set; } = default!;
    private string? OrderNrHead { get; set; }

    public List<Notification>? AllNotificationsHead;
    private IEnumerable<OrderDto.Index>? ordersHead;


    protected override async Task OnInitializedAsync()
    {
        // shopping cart
        ShoppingCart.OnChange += () => StateHasChanged();
        ShoppingCart.OnAdded += () => {
            StateHasChanged();
            System.Console.Out.WriteLine($"collapsed = {collapseShoppingCart}");
            // if cart is collapsed, click on it when product is added
            if(collapseShoppingCart == true)
            {
                pressedShoppingCart();
            }
        };
        // notifications
        AllNotificationsHead = new List<Notification>();
        if (OrderServiceHead != null)
        {
            ordersHead = await OrderServiceHead.GetOrdersAsync();
        }
        if (ordersHead != null)
        {
            foreach (OrderDto.Index item in ordersHead)
            {
                item.notifications.ForEach(noti => AllNotificationsHead.Add(noti));

            }
        }

    }

    //private void FindNotifications()
    //{
    //    foreach (OrderDto.Index item in orders)
    //    {
    //        item.notifications.ForEach(noti => AllNotifications.Add(noti));
    //    }
    //}

}