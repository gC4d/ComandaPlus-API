using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ComandaPlus_API.Domain.Entities.Enums;

namespace ComandaPlus_API.Application.Dtos;

public class UserDTO 
{
    public Guid Id { get; set;}

    [Required(ErrorMessage = "Title is required!")]
    [MinLength(3)]
    [MaxLength(50)]
    [DisplayName("Name")]
    public string Name { get; set;}
    public string Email { get;  set; }
    public UserStatus Status { get;  set; }
    public UserRole Role { get;  set; }
    public DateTime CreateAt { get;  set; }
    public DateTime LastLogin { get;  set; }
}