using DataAccessLayer.Common.Entities;

namespace DataAccessLayer.Common.Repositories
{
    public interface ISharedRepository<TEntity> where TEntity : EntityBase
    {
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
    }
}
