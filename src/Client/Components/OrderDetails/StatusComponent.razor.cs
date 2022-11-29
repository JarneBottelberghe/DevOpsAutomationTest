using Microsoft.AspNetCore.Components;
using Shared.Orders;

namespace Client.Components.OrderDetails;

public partial class StatusComponent
{
    //[Parameter, EditorRequired] public OrderDto.Index CurrentOrder { get; set; } = default!;
    [Parameter] public int? OrderStatus { get; set; }
    [Inject] public IOrderService OrderService { get; set; } = default!;
}