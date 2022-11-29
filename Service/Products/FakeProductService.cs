using Shared.Products;

namespace Services.Products;

public class FakeProductService : IProductService
{
    private readonly List<ProductDto.Index> products = new();

    public FakeProductService()
    {
        products.Add(new ProductDto.Index
        {
            ProductId = "P123-456",
            Name = "Laptop",
            Description = "Nieuwe macbook van Apple",
            UnitPrice = 1000.00,
            LeftInStock = 10,
            Height = 0.40,
            Width = 0.20,
            Depth = 0.02
        });
        products.Add(new ProductDto.Index
        {
            ProductId = "P456-789",
            Name = "Koelkast",
            Description = "Nieuwe koelkast van Samsung",
            UnitPrice = 999.99,
            LeftInStock = 10,
            Height = 1.20,
            Width = 0.50,
            Depth = 0.60
        }); 
        products.Add(new ProductDto.Index
        {
            ProductId = "P123-789",
            Name = "GSM",
            Description = "Nieuwe GSM van Huawei",
            UnitPrice = 500.99,
            LeftInStock = 3,
            Height = 0.12,
            Width = 0.05,
            Depth = 0.012
        });
        products.Add(new ProductDto.Index
        {
            ProductId = "P789-456",
            Name = "Toetsenbord",
            Description = "Het beste toetsenbord van Logitech",
            UnitPrice = 29.99,
            LeftInStock = 10,
            Height = 0.15,
            Width = 0.40,
            Depth = 0.04
        });
        products.Add(new ProductDto.Index
        {
            ProductId = "P456-123",
            Name = "Hoofdtelefoon",
            Description = "Hoofdtelefoon van Sennheiser",
            UnitPrice = 100.99,
            LeftInStock = 10,
            Height = 0.30,
            Width = 0.30,
            Depth = 0.30
        });
        products.Add(new ProductDto.Index
        {
            ProductId = "P789-123",
            Name = "Luidspreker",
            Description = "De luidste luidpspreker van JBL",
            UnitPrice = 50.99,
            LeftInStock = 0,
            Height = 0.40,
            Width = 0.80,
            Depth = 0.20
        });
    }

    public Task<int> CreateAsync(ProductDto.Mutate model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(int productId, ProductDto.Mutate model)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto.Detail> GetDetailAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductDto.Index>> GetIndexAsync()
    {
        //await Task.Delay(1000);
        return products.AsEnumerable();
    }
}
