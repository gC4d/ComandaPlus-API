using System;
using ComandaPlus_Core.Entities;

namespace ComandaPlus_Core.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
