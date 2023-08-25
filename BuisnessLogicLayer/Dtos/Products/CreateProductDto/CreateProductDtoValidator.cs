using DataAccessLayer.Repositories.ProductRepository;
using FluentValidation;

namespace BuisnessLogicLayer.Dtos.Products.CreateProductDto
{
    internal class CreateProductDtoValidator: AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator(IProductRepository productRepository)
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .MaximumLength(250)
                .MustAsync(async (n, ct) => await productRepository.GetByNameAsync(n) == null).WithMessage("{PropertyName} has been taken");
        }
    }
}
