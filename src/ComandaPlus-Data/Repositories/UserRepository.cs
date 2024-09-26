using ComandaPlus_Core.Entities;
using ComandaPlus_Core.Interfaces.Repositories;
using ComandaPlus_Data.Context;

namespace ComandaPlus_Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }
}