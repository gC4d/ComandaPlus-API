using ComandaPlus_API.Domain.Entities.Enums;
using ComandaPlus_API.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace ComandaPlus_API.Domain.Entities;

public sealed class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public UserStatus Status { get; private set; }
    public UserRole Role { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime? LastLogin { get; private set; }
    

    public ICollection<Account> Accounts { get; set; }

    public User() {}
    public User(string name, string email, UserStatus status, UserRole role, DateTime createdAt, DateTime? lastLogin)
    {
        Validation(name, email); 
        this.Name = name;
        this.Email = email;
        this.Status = status;
        this.Role = role;
        this.CreateAt = createdAt;
        this.LastLogin = lastLogin;
    }
    public User(Guid id, string name, string email, UserStatus status, UserRole role, DateTime createdAt, DateTime? lastLogin)
    {
        DomainValidationException.When(id.Equals(Guid.Empty), "Invalid id!");
        Validation(name, email); 
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.Status = status;
        this.Role = role;
        this.CreateAt = createdAt;
        this.LastLogin = lastLogin;
    }

    private void Validation(string name, string email)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(name), "Invalid name. Name is required");
        DomainValidationException.When(name.Length < 3, "Name is too short! Minimum of 3 characters");
        DomainValidationException.When(name.Length > 50, "Name is too large! Maximum of 50 characters");

        DomainValidationException.When(string.IsNullOrWhiteSpace(email), "Invalid e-mail, E-mail is required"); 
        DomainValidationException.When(!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"), "Invalid e-mail");

    }
}
