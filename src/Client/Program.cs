using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Shared.Orders;
using Services.Orders;
using Shared.Products;
using Services.Products;
using Client.Components.Products;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddSingleton<IOrderService, FakeOrderService>();
builder.Services.AddSingleton<IProductService, FakeProductService>();

builder.Services.AddSingleton<ShoppingCartState>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
