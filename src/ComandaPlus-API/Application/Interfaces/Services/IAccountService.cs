using ComandaPlus_API.Application.Dtos;

namespace ComandaPlus_API.Interfaces.Services;

public interface IAccountService
{
    Task<IEnumerable<AccountDTO>> GetAll();
    Task<AccountDTO> GetById(Guid? id);
    Task Add(AccountDTO accountDTO);
    Task Update(AccountDTO accountDTO);
    Task Delete(Guid? id);
    
}
