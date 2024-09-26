using ComandaPlus_Core.Entities;

namespace ComandaPlus_Core.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int? id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveByIdAsync(int id);
    Task<T> RemoveAsync(T entity);
}
