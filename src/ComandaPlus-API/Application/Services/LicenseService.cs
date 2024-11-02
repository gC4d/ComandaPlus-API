using System;
using ComandaPlus_API.Dtos;
using ComandaPlus_API.Interfaces.Services;

namespace ComandaPlus_API.Services;

public class LicenseService : ILicenseService
{
    public Task Add(LicenseDTO licenseDTO)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid? id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LicenseDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<LicenseDTO> GetById(Guid? id)
    {
        throw new NotImplementedException();
    }

    public Task Update(LicenseDTO licenseDTO)
    {
        throw new NotImplementedException();
    }
}
