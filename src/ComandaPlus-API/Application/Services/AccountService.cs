using AutoMapper;
using ComandaPlus_API.Application.Dtos;
using ComandaPlus_API.Domain.Entities;

namespace ComandaPlus_API.Services;

public class AccountService
{
    private readonly IMapper _mapper;
    public AccountService(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Add(AccountDTO accountDTO)
    {
       var account = _mapper.Map<Account>(accountDTO);
    }

    public async Task Delete(Guid? id)
    {
    }

    public async Task<IEnumerable<AccountDTO>> GetAll()
    {
        return default;
    }

    public async Task<AccountDTO?> GetById(Guid? id)
    {
        if(id == Guid.Empty || id == null)
            return null;
        
        return default;
    }

    public async Task Update(AccountDTO accountDTO)
    {
        
    }
}
