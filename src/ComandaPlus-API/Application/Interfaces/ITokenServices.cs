using System;
using ComandaPlus_API.Domain.Entities;

namespace ComandaPlus_API.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
