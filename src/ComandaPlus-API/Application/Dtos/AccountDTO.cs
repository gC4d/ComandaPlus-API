using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ComandaPlus_API.Entities;

namespace ComandaPlus_API.Dtos;

public class AccountDTO 
{
  public Guid Id { get; set; }

  [Required(ErrorMessage = "Title is required!")]
  [MinLength(5)]
  [MaxLength(50)]
  [DisplayName("Title")]
  public string Title {get; set;}

  [MaxLength(250)]
  [DisplayName("Logo")]
  public string Logo {get; set;}

  [Required(ErrorMessage = "Identifier is required!")]
  [MinLength(11)]
  [MaxLength(20)]
  [DisplayName("Identifier")]
  public string Identifier {get; set;}
  
  [DisplayName("Owner")]
  public Guid OwnerId {get; set;}

  [JsonIgnore]
  public User Owner {get; set;} 

  [DisplayName("License")]
  public Guid LicenseId { get; set; }

  [JsonIgnore]
  public License License { get; set; }

}
