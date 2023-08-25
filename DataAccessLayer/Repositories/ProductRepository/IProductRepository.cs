namespace DataAccessLayer.Repositories.ProductRepository
{
    public interface IProductRepository : ISharedRepository<Product>
    {
        Task<Product?> GetByNameAsync(string name);
    }
}
