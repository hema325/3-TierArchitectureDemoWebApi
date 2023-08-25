using BuisnessLogicLayer.Dtos.Products.CreateProductDto;
using BuisnessLogicLayer.Dtos.Products.ProductDto;
using BuisnessLogicLayer.Dtos.Products.UpdateProductDto;
using DataAccessLayer.Repositories.ProductRepository;
using Microsoft.Extensions.Logging;

namespace BuisnessLogicLayer.ProductsService
{
    internal class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<int>> CreateProducAsync(CreateProductDto dto)
        {
            var validator = new CreateProductDtoValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return new Result<int>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = validationResult.ToString()
                };
            }

            var product = _mapper.Map<Product>(dto);

            try
            {
                await _productRepository.CreateAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to create product exception, message: {message} ", ex.InnerException?.Message ?? ex.Message);

                return new Result<int>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }

            _logger.LogInformation("Product with id {id} has been created", product.Id);

            return new Result<int>
            {
                StatusCode = HttpStatusCode.OK,
                Payload = product.Id
            };
        }

        public async Task<Result<Product>> UpdateProducAsync(UpdateProductDto dto)
        {
            var validator = new UpdateProductDtoValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return new Result<Product>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = validationResult.ToString()
                };
            }

            var product = await _productRepository.GetByIdAsync(dto.Id);

            if (product == null)
            {
                _logger.LogError("Product with id {id} wasn't found", dto.Id);

                return new Result<Product>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Product with id {dto.Id} wasn't found"
                };
            }

            _mapper.Map(dto, product);

            try
            {
                await _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to Update product with id {id} exception, message: {message} ", dto.Id, ex.InnerException?.Message ?? ex.Message);

                return new Result<Product>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }

            _logger.LogInformation("Product with id {id} has been updated", product.Id);

            return new Result<Product>
            {
                StatusCode = HttpStatusCode.NoContent
            };
        }

        public async Task<Result<Product>> DeleteProducAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                _logger.LogError("Product with id {id} wasn't found", id);

                return new Result<Product>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Product with id {id} wasn't found"
                };
            }

            try
            {
                await _productRepository.DeleteAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to delete product with id {id} exception, message: {message} ",
                    id, 
                    ex.InnerException?.Message ?? ex.Message);

                return new Result<Product>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }

            _logger.LogInformation("Product with id {id} has been deleted", product.Id);

            return new Result<Product>
            {
                StatusCode = HttpStatusCode.NoContent
            };
        }

        public async Task<Result<List<ProductDto>>> GetAllAsync()
        {
            var products =  await _productRepository.GetAllAsync();

            if (products == null || products.Count == 0)
                return new Result<List<ProductDto>>
                {
                    StatusCode = HttpStatusCode.NoContent,
                };

            return new Result<List<ProductDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Payload = _mapper.Map<List<ProductDto>>(products)
            };
        }
    }
}
