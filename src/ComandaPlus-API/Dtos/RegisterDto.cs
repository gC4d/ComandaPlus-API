using System;

namespace ComandaPlus_API.Dtos;

public sealed record RegisterDto(string Name, string Email, string Password, string confirmPassword);
