using System;

namespace ComandaPlus_Core.Dtos;

public sealed record RegisterDto(string Name, string Email, string Password, string confirmPassword);
