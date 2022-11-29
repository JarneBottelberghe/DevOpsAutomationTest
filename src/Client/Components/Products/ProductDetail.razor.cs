using Microsoft.AspNetCore.Components;
using Shared.Products;
using Domain;
using Client.Components.Products;

namespace Client.Components.Products
{
    public partial class ProductDetail
    {
        [Inject] public ShoppingCartState ShoppingCart { get; set; } = default!;
        [Parameter] public ProductDto.Index Product { get; set; }
        int amount = 1;
        public bool DetailsShown { get; set; } = false;

        private void ShowDetails()
        {
            DetailsShown = !DetailsShown;
            StateHasChanged();
        }
        private void AddProduct()
        {
            Product product = new(Product.ProductId, Product.Name, Product.Description, Product.UnitPrice, Product.LeftInStock, Product.Height, Product.Width, Product.Depth);
            Item cartItem = new(Product.ProductId, amount, Product.UnitPrice * amount, product);
            System.Console.WriteLine($"Product: {cartItem.Product.ProductName}\tquantity: {cartItem.Quantity}");
            ShoppingCart.AddItem(cartItem);
        }
    }
}
