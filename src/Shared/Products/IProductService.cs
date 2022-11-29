namespace Shared.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto.Index>> GetIndexAsync();
        Task<ProductDto.Detail> GetDetailAsync(int productId);
        Task<int> CreateAsync(ProductDto.Mutate model);
        Task EditAsync(int productId, ProductDto.Mutate model);
        Task DeleteAsync(int productId);
       
    }
}
