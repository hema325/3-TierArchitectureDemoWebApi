namespace BuisnessLogicLayer.Dtos.Products.CreateProductDto
{
    internal class CreateProductDtoProfile: Profile
    {
        public CreateProductDtoProfile()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }
}
