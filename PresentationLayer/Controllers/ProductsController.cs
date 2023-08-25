using BuisnessLogicLayer.Dtos.Products.CreateProductDto;
using BuisnessLogicLayer.Dtos.Products.UpdateProductDto;
using BuisnessLogicLayer.ProductsService;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("products")]
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            return Result(await _productService.CreateProducAsync(dto));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateProductDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Id is not valid");

            return Result(await _productService.UpdateProducAsync(dto));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Result(await _productService.DeleteProducAsync(id));
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Result(await _productService.GetAllAsync());
        }
    }
}
