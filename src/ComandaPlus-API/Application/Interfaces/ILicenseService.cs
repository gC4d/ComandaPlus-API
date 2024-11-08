
using ComandaPlus_API.Dtos;

namespace ComandaPlus_API.Interfaces.Services;

public interface ILicenseService
{
    Task<IEnumerable<LicenseDTO>> GetAll();
    Task<LicenseDTO> GetById(Guid? id);
    Task Add(LicenseDTO licenseDTO);
    Task Update(LicenseDTO licenseDTO);
    Task Delete(Guid? id);
}
