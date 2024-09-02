using System.ComponentModel.DataAnnotations;
using ComandaPlus_Core.Entities.Enums;

namespace ComandaPlus_Core.Entities;

public class User : Person
{
    [Required]
    [StringLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; private set; }
    [Required]
    [StringLength(50)]
    [DataType(DataType.Password)]
    public string Password { get; private set; }
    public UserStatus Status { get; private set; }
    public UserRole Role { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime LastLogin { get; private set; }
}
