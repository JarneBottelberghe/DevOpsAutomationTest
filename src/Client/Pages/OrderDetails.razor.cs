using Microsoft.AspNetCore.Components;
using Shared.Orders;

namespace Client.Pages;

public partial class OrderDetails
{
    private OrderDto.Index? order;
    [Inject] public IOrderService OrderService { get; set; } = default!;

    [Parameter] public string OrderId { get; set; }

    protected async override Task OnInitializedAsync()
    {
        order = await OrderService.GetOrderDetailAsync(OrderId);
    }
}