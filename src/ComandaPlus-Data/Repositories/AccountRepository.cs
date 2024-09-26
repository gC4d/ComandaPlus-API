using ComandaPlus_Core.Entities;
using ComandaPlus_Core.Interfaces.Repositories;

namespace ComandaPlus_Data.Repositories;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    public Task<Account> GetLicenseAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetOwnerAsync(int? id)
    {
        throw new NotImplementedException();
    }
}