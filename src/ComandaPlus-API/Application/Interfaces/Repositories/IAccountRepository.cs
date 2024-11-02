using ComandaPlus_API.Domain.Entities;

namespace ComandaPlus_API.Interfaces.Repositories;

public interface IAccountRepository : IRepository<Account>
{
    Task<Account> GetOwnerAsync(int? id);
    Task<Account> GetLicenseAsync(int? id);
}