namespace ComandaPlus_API.Domain.Entities.Enums;

public enum UserStatus : sbyte
{
    Inactive,
    Active,
    Banned,
    Pending,
    Suspended
}

public enum UserRole : sbyte
{
    Guest,
    Admin,
    User,
    Moderator
}
