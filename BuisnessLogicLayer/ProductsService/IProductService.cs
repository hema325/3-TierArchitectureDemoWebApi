using BuisnessLogicLayer.Dtos.Products.CreateProductDto;
using BuisnessLogicLayer.Dtos.Products.ProductDto;
using BuisnessLogicLayer.Dtos.Products.UpdateProductDto;

namespace BuisnessLogicLayer.ProductsService
{
    public interface IProductService
    {
        Task<Result<int>> CreateProducAsync(CreateProductDto dto);
        Task<Result<Product>> DeleteProducAsync(int id);
        Task<Result<List<ProductDto>>> GetAllAsync();
        Task<Result<Product>> UpdateProducAsync(UpdateProductDto dto);
    }
}
