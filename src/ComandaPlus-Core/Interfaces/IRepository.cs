using ComandaPlus_Core.Entities;

namespace ComandaPlus_Core.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(int? id);
    Task<IEnumerable<T>> GetAllAsync<T>();
    Task<T> CreateAsync<T>(T entity);
    Task<T> UpdateAsync<T>(T entity);
    Task<T> RemoveAsync<T>(int id);
}
