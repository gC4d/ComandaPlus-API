using ComandaPlus_API.Domain.Entities;
using ComandaPlus_API.Domain.Entities.Enums;
using ComandaPlus_API.Domain.Exceptions;
using FluentAssertions;

namespace UnitTests.Domain
{
    public class UserTests
    {
        [Fact(DisplayName = "Create a new User instance with valid parameters")]
        public void CreateUser_WithValidParameters_ResultValidObject()
        {
            Action action = () => new User("John Doe", "john.doe@example.com", "SecurePassword123", UserStatus.Active, UserRole.Admin, DateTime.Now, DateTime.Now);
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact(DisplayName = "Create a User with an invalid name")]
        public void CreateUser_WithInvalidName_ThrowsException()
        {
            Action action = () => new User(string.Empty, "john.doe@example.com", "SecurePassword123", UserStatus.Active, UserRole.Admin, DateTime.Now, null);
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create a User with an invalid email")]
        public void CreateUser_WithInvalidEmail_ThrowsException()
        {
            Action action = () => new User("John Doe", "invalid-email", "SecurePassword123", UserStatus.Active, UserRole.Admin, DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid e-mail");
        }

        [Fact(DisplayName = "Create a User with a short password")]
        public void CreateUser_WithShortPassword_ThrowsException()
        {
            Action action = () => new User("John Doe", "john.doe@example.com", "short", UserStatus.Active, UserRole.Admin, DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainValidationException>().WithMessage("Passoword is too short! Invalid password");
        }

        [Fact(DisplayName = "Create a User without status defaults to Inactive")]
        public void CreateUser_WithoutStatus_ShouldDefaultToInactive()
        {
            var user = new User("John Doe", "john.doe@example.com", "SecurePassword123", default, UserRole.Admin, DateTime.Now, DateTime.Now);
            user.Status.Should().Be(UserStatus.Inactive);
        }
    }
}