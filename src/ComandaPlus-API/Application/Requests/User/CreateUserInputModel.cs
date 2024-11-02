using System;
using System.ComponentModel.DataAnnotations;
using ComandaPlus_API.Dtos;

namespace ComandaPlus_API.Requests.User;

public readonly record struct CreateUserInputModel
{
    [Required]
    public string Name { get; init;}
    [Required]
    [EmailAddress]
    public string Email { get; init;}
    [Required]
    public string Password { get; init;}

    public static implicit operator UserDTO(CreateUserInputModel request){
        return new UserDTO() { 
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            CreateAt = DateTime.Now,
            Role = Entities.Enums.UserRole.User,
            Status = Entities.Enums.UserStatus.Active,
        };
    }
}
