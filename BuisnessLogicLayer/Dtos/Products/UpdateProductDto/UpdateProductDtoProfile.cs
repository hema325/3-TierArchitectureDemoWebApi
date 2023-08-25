namespace BuisnessLogicLayer.Dtos.Products.UpdateProductDto
{
    internal class UpdateProductDtoProfile: Profile
    {
        public UpdateProductDtoProfile()
        {
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
