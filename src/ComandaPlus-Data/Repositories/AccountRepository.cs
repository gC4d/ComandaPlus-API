using ComandaPlus_Core.Entities;
using ComandaPlus_Core.Interfaces.Repositories;
using ComandaPlus_Data.Context;

namespace ComandaPlus_Data.Repositories;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    public AccountRepository(DatabaseContext context) : base(context)
    {
    }

    public Task<Account> GetLicenseAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetOwnerAsync(int? id)
    {
        throw new NotImplementedException();
    }
}