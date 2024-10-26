using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ComandaPlus_API.Entities.Enums;

namespace ComandaPlus_API.Dtos;

public class UserDTO 
{
    public Guid Id { get; set;}

    [Required(ErrorMessage = "Title is required!")]
    [MinLength(3)]
    [MaxLength(50)]
    [DisplayName("Name")]
    public string Name { get; set;}
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserStatus Status { get; private set; }
    public UserRole Role { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime LastLogin { get; private set; }
}