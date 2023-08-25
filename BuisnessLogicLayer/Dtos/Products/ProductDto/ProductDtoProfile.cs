namespace BuisnessLogicLayer.Dtos.Products.ProductDto
{
    internal class ProductDtoProfile: Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
