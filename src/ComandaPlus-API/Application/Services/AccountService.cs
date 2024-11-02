using AutoMapper;
using ComandaPlus_API.Dtos;
using ComandaPlus_API.Entities;
using ComandaPlus_API.Interfaces.Repositories;
using ComandaPlus_API.Interfaces.Services;

namespace ComandaPlus_API.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    public AccountService(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Add(AccountDTO accountDTO)
    {
       var account = _mapper.Map<Account>(accountDTO);
       await _accountRepository.CreateAsync(account);
    }

    public async Task Delete(Guid? id)
    {
        await _accountRepository.RemoveByIdAsync(id);
    }

    public async Task<IEnumerable<AccountDTO>> GetAll()
    {
        var accounts = await _accountRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AccountDTO>>(accounts);
    }

    public async Task<AccountDTO?> GetById(Guid? id)
    {
        if(id == Guid.Empty || id == null)
            return null;
        
        var account = await _accountRepository.GetByIdAsync(id);
        return _mapper.Map<AccountDTO>(account);
    }

    public async Task Update(AccountDTO accountDTO)
    {
        var account = _mapper.Map<Account>(accountDTO);
        await _accountRepository.UpdateAsync(account);
    }
}
