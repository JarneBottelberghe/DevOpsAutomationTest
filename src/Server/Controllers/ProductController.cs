
using Microsoft.AspNetCore.Mvc;
using Shared.Products;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [SwaggerOperation("Returns a list of products available.")]
        [HttpGet]
        public async Task<ProductDto.Index> GetIndex()
        {
            return (ProductDto.Index)await productService.GetIndexAsync();
        }

        [SwaggerOperation("Returns a specific product available.")]
        [HttpGet("{productId}")]
        public async Task<ProductDto.Detail> GetDetail(int productId)
        {
            return await productService.GetDetailAsync(productId);
        }

        [SwaggerOperation("Creates a new product in the catalog.")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto.Mutate model)
        {
            var productId = await productService.CreateAsync(model);
            return CreatedAtAction(nameof(Create), new { id = productId });
        }

        [SwaggerOperation("Edites an existing product.")]
        [HttpPut("{productId}")]
        public async Task<IActionResult> Edit(int productId, ProductDto.Mutate model)
        {
            await productService.EditAsync(productId, model);
            return NoContent();
        }

        [SwaggerOperation("Deletes an existing product.")]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            await productService.DeleteAsync(productId);
            return NoContent();
        }

       
    }
}
