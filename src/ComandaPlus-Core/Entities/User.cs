using ComandaPlus_Core.Entities.Enums;
using ComandaPlus_Core.Validation.Exceptions;
using System.Text.RegularExpressions;

namespace ComandaPlus_Core.Entities;

public sealed class User : Person
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserStatus Status { get; private set; }
    public UserRole Role { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime LastLogin { get; private set; }

    public User(string name, string email, string password, UserStatus status, DateTime createAt, DateTime lastLogin)
    {

    }
    public User(Guid id, string name, string email, string password, UserStatus status, UserRole role, DateTime createdAt, DateTime lastLogin){

    }

    private void Validation(User user){
        DomainValidationException
            .When(string.IsNullOrWhiteSpace(user.Name), "Invalid name. Name is required");

        DomainValidationException
            .When(user.Name.Length < 3, "Invalid name. too short, minimum 3 characters");

        DomainValidationException
            .When(string.IsNullOrWhiteSpace(user.Email), "Invalid e-mail, E-mail is required"); 

        DomainValidationException
            .When(!Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"), "Invalid e-mail");

        DomainValidationException
            .When(string.IsNullOrWhiteSpace(user.Password), "Invalid password. Password is required");
    }
}
