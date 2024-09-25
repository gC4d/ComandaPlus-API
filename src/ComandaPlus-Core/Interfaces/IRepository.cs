using ComandaPlus_Core.Entities;

namespace ComandaPlus_Core.Interfaces.Repositories;

public interface IRepository
{
    Task<T> GetByIdAsync<T>(int? id) where T : BaseEntity;
    Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity;
    Task<T> CreateAsync<T>(T entity) where T : BaseEntity;
    Task<T> UpdateAsync<T>(T entity) where T : BaseEntity;
    Task<T> RemoveAsync<T>(int id) where T : BaseEntity;
}
