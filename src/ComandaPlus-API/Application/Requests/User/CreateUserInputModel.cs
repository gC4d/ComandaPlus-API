using System;
using System.ComponentModel.DataAnnotations;
using ComandaPlus_API.Application.Dtos;
using ComandaPlus_API.Domain.Entities.Enums;

namespace ComandaPlus_API.Requests.User;

public readonly record struct CreateUserInputModel
{
    [Required]
    public string Name { get; init;}
    [Required]
    [EmailAddress]
    public string Email { get; init;}

    public static implicit operator UserDTO(CreateUserInputModel request){
        return new UserDTO() { 
            Name = request.Name,
            Email = request.Email,
            CreateAt = DateTime.Now,
            Role = UserRole.User,
            Status = UserStatus.Active,
        };
    }
}
