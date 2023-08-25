using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.ProductRepository
{
    internal class ProductRepository : SharedRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}
