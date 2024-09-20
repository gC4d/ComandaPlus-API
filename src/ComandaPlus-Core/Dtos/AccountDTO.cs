namespace ComandaPlus_Core.Dtos;

public class AccountDTO 
{
  string Title {get; set;}
  UserDto Owner {get; set;}
  LicenseDTO License { get; set; }

}
