using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Common.Repositories
{
    internal abstract class SharedRepository<TEntity> : ISharedRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationDbContext _context;

        protected SharedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
