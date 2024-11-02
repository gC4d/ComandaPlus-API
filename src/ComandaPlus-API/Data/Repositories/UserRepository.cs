using ComandaPlus_API.Domain.Entities;
using ComandaPlus_API.Interfaces.Repositories;
using ComandaPlus_API.Context;

namespace ComandaPlus_API.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }
}