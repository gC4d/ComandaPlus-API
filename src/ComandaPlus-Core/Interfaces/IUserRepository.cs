using ComandaPlus_Core.Entities;

namespace ComandaPlus_Core.Interfaces.Repositories;
public interface IUserRepository
{    
    Task<User> GetByIdAsync(int? id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> RemoveAsync(int id);
}