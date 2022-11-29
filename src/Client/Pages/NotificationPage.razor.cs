using Domain;
using Microsoft.AspNetCore.Components;
using Shared.Orders;

namespace Client.Pages;
public partial class NotificationPage
{
    [Inject] public IOrderService? OrderService { get; set; }
    private string? OrderNr { get; set; }

    public List<Notification>? AllNotifications;
    private IEnumerable<OrderDto.Index>? orders;

    protected override async Task OnInitializedAsync()
    {
        AllNotifications = new List<Notification>();
        if (OrderService != null)
        {
            orders = await OrderService.GetOrdersAsync();
        }
        if (orders != null)
        {
            foreach (OrderDto.Index item in orders)
            {
                item.notifications.ForEach(noti => AllNotifications.Add(noti));

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