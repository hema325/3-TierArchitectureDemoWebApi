using DataAccessLayer.Repositories.ProductRepository;
using FluentValidation;

namespace BuisnessLogicLayer.Dtos.Products.UpdateProductDto
{
    internal class UpdateProductDtoValidator: AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator(IProductRepository productRepository)
        {
            RuleFor(d => d.Name)
            .NotEmpty()
            .MaximumLength(250)
               .MustAsync(async (n, ct) => await productRepository.GetByNameAsync(n) == null).WithMessage("`{PropertyName}` has been taken");
        }
    }
}
