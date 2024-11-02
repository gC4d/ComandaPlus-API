using ComandaPlus_API.Domain.Entities;

namespace ComandaPlus_API.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(Guid? id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveByIdAsync(Guid? id);
    Task<T> RemoveAsync(T entity);
}
