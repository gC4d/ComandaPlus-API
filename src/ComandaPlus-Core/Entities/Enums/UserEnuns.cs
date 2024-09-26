namespace ComandaPlus_Core.Entities.Enums;

public enum UserStatus : sbyte
{
    Active,
    Inactive,
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
