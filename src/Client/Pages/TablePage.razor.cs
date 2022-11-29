using BlazorDateRangePicker;
using Microsoft.AspNetCore.Components;
using Shared.Orders;


namespace Client.Pages;
public partial class TablePage
{
    [Inject] public IOrderService? OrderService { get; set; }
    private string OrderNr { get; set; }

    private IEnumerable<OrderDto.Index>? orders;
    private bool DateSorted = false;
    private bool StatusSorted = false;

    protected override async Task OnInitializedAsync()
    {
        orders = await OrderService.GetOrdersAsync();
    }

    private void SortDate()
    {
        if (!DateSorted)
        {
            orders = orders?.OrderBy(x => x.OrderDate).ToList();
            DateSorted = true;
            StatusSorted = false;
        }
        else
        {
            orders = orders?.OrderByDescending(x => x.OrderDate).ToList();
            DateSorted = false;
            StatusSorted = false;
        }
    }

    private void SortStatus()
    {
        if (!StatusSorted)
        {
            orders = orders?.OrderBy(x => x.OrderStatus).ToList();
            StatusSorted = true;
            DateSorted = false;
        }
        else
        {
            orders = orders?.OrderByDescending(x => x.OrderStatus).ToList();
            StatusSorted = false;
            DateSorted = false;
        }
    }

    private void FindOrders()
    {
        if (OrderNr != null)
        {
            orders = orders?.Where(x => x.OrderId?.Contains(OrderNr) == true).ToList();
        }
    }

    public void OnRangeSelect(DateRange range)
    {
        //https://github.com/jdtcn/BlazorDateRangePicker
        orders = orders?.Where(x => x.OrderDate >= range.Start && x.OrderDate <= range.End).ToList();
    }
}