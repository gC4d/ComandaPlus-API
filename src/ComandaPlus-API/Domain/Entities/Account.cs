using System.Data;
using ComandaPlus_API.Domain.Entities.Enums;
using ComandaPlus_API.Domain.Exceptions;

namespace ComandaPlus_API.Domain.Entities;

public sealed class Account : BaseEntity
{
  public string Title { get; private set; }
  public string? Logo { get; private set; }
  public string Identifier { get; private set; }
  // @ToDo: I will need define some way to identify where are the account from 
  
  public Guid OwnerId { get;  set; } 
  public User Owner { get;  set; }
  public Guid LicenseId { get;  set; }
  public License License { get;  set; }

  public Account(string title, string logo, string identifier)
  {
    Validate(title, logo, identifier);
    Title = title;
    Logo = logo;
    Identifier = identifier;
  }

  public Account(Guid id, string title, string logo, string identifier)
  {
    DomainValidationException.When(id.Equals(Guid.Empty), "Id is required");
    Validate(title, logo, identifier);
    Id = id;
    Title = title;
    Logo = logo;
    Identifier = identifier;
  }

  public void Update(string title, string logo, string identifier, Guid ownerId, Guid licenseId)
  {
    Validate(title,logo,identifier);
    OwnerId = ownerId;
    LicenseId = licenseId;
  }

  private void Validate(string title, string? logo, string identifier)
  {
    DomainValidationException.When(string.IsNullOrWhiteSpace(title), "Invalid title! Title is required");
    DomainValidationException.When(title.Length < 5, "Title is too short! minimum of 5 characters");
    DomainValidationException.When(title.Length > 50, "Title is too large! maximum of 50 characters");

    DomainValidationException.When(logo?.Length > 250, "Logo image is too large! maximum of 250 characters");

    DomainValidationException.When(string.IsNullOrWhiteSpace(identifier), "Invalid identifier! Identifier is required");
    DomainValidationException.When(identifier.Length < 11, "identifier is too short! minimum of 11 characters");
    DomainValidationException.When(identifier.Length > 20, "identifier is too large! maximum of 20 characters");
  }

}
