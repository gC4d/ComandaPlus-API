using ComandaPlus_Core.Entities.Enums;

namespace ComandaPlus_Core.Entities;

public class Account : BaseEntity 
{
  public string Title {get; private set; }

  public Guid OwnerId {get; private set;}
  public User Owner {get; private set;}
  public Guid LicenseId {get; private set;}
  public License License { get; private set; }

  public Account(string title)
  {
    Title = title;
  }
}
