using Domain;
using Microsoft.AspNetCore.Components;

namespace Client.Components.Products
{
    public partial class ShoppingCart
    {
        [Inject] public ShoppingCartState Cart { get; set; } = default!;
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Cart.OnAdded += StateHasChanged;
        }

        private void MinusOne(Item item)
        {
            Cart.MinusOne(item);
        }
        
        private void PlusOne(Item item)
        {
            Cart.PlusOne(item);
        }

        private void RemoveItem(Item item)
        {
            Cart.RemoveItem(item);
        }

        private void ClearItems()
        {
            Cart.ClearItems();
        }

        private void OrderItems()
        {
            NavigationManager.NavigateTo("/packageShipment");
        }
    }
}
