using ComandaPlus_API.Domain.Entities;
using ComandaPlus_API.Interfaces.Repositories;
using ComandaPlus_API.Context;

namespace ComandaPlus_API.Repositories;

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