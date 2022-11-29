using Domain;
using Microsoft.AspNetCore.Components;
using Client.Components.Products;
using Shared.Products;

namespace Client.Pages;

public partial class Products
{
    private IEnumerable<ProductDto.Index>? _products;
    [Inject] public IProductService? ProductService { get; set; }
    protected override async Task OnInitializedAsync()
    {
        _products = await ProductService.GetIndexAsync();
    }
}