using System;
using ComandaPlus_API.Entities;

namespace ComandaPlus_API.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
