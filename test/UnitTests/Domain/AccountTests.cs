using ComandaPlus_API.Domain.Entities;
using ComandaPlus_API.Domain.Exceptions;
using FluentAssertions;

namespace UnitTests.Domain;

public class AccountTests
{
    [Fact(DisplayName = "Create a new instace of account using the valid parameters")]
    public void CreateAccount_WithValidParameters_ResultValidObject()
    {
        Action action = () => new Account(Guid.NewGuid(), "ComandaPlus_Market", "this is my logo", "123654789-00");
        action.Should()
            .NotThrow<DomainValidationException>();
    }

    [Fact(DisplayName = "Create a account with a invalid id value")]
    public void CreateAccount_WithInvalidIdValue_ResultInDomainException()
    {
        Action action = () => new Account(Guid.Empty, "ComandaPlus_Market", "this is my logo", "123654789-00");
        action.Should()
        .Throw<DomainValidationException>()
        .WithMessage("Id is required");
    }

    [Fact(DisplayName = "Create a account without title")]
    public void CreateAccount_WithoutTitleValue_ResultInDomainException()
    {
        Action action = () => new Account(Guid.NewGuid(), string.Empty, "this is my logo", "123654789-00");
        action.Should()
            .Throw<DomainValidationException>()
            .WithMessage("Invalid title! Title is required");
    }

    [Fact(DisplayName = "Create a account with a short title value")]
    public void CreateAccount_WithShortTitleValue_ResultInDomianException()
    {
        Action action = () => new Account(Guid.NewGuid(), "titl", "this is my logo", "123654789-00");
        action.Should()
            .Throw<DomainValidationException>()
            .WithMessage("Title is too short! minimum of 5 characters");
    }

    [Fact(DisplayName = "Create a account witha large title value")]
    public void CreateAccount_WithLargeTitleValue_ResultInDomianException()
    {
        Action action = () => new Account(Guid.NewGuid(), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor.", "this is my logo", "123654789-00");
        action.Should()
            .Throw<DomainValidationException>()
            .WithMessage("Title is too large! maximum of 50 characters");
    }

    [Fact(DisplayName = "Create a account without identifier")]
    public void CreateAccount_WithoutIdentifierValue_ResultInDomainException()
    {
        Action action = () => new Account(Guid.NewGuid(), "ComandaPlus_Market", "this is my logo", string.Empty);
        action.Should()
            .Throw<DomainValidationException>()
            .WithMessage("Invalid identifier! Identifier is required");
    }

    [Fact(DisplayName = "Create a account with a short title value")]
    public void CreateAccount_WithShortIdentifierValue_ResultInDomianException()
    {
        Action action = () => new Account(Guid.NewGuid(), "ComandaPlus_Market", "this is my logo", "123654");
        action.Should()
            .Throw<DomainValidationException>()
            .WithMessage("identifier is too short! minimum of 11 characters");
    }

    [Fact(DisplayName = "Create a account with a large indentifier value")]
    public void CreateAccount_WithLargeIdentifierValue_ResultInDomianException()
    {
        Action action = () => new Account(Guid.NewGuid(), "ComandaPlus_Market", "this is my logo", "123654789321456987000");
        action.Should()
            .Throw<DomainValidationException>()
            .WithMessage("identifier is too large! maximum of 20 characters");
    }

    [Fact(DisplayName = "Create a account without logo")]
    public void CreateAccount_WithoutLogoValue_ResultInValidObject()
    {
        Action action = () => new Account(Guid.NewGuid(), "ComandaPlus_Market", null, "123654789-00");
        action.Should()
            .NotThrow<DomainValidationException>();
    }

    [Fact(DisplayName = "Create a account without logo")]
    public void CreateAccount_WithLargeLogoValue_ResultInDomianException()
    {
        Action action = () => new Account(Guid.NewGuid(), "ComandaPlus_Market", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor.", "123654789-00");
        action.Should()
            .Throw<DomainValidationException>()
            .WithMessage("Logo image is too large! maximum of 250 characters");
    }
}
