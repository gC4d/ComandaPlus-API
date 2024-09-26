using ComandaPlus_Core.Entities;

namespace ComandaPlus_Core.Interfaces.Repositories;

public interface IAccountRepository : IRepository<Account>
{
    Task<Account> GetOwnerAsync(int? id);
    Task<Account> GetLicenseAsync(int? id);
}