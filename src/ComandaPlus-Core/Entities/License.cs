namespace ComandaPlus_Core.Entities.Enums;

public class License : BaseEntity 
{
  public DateTime LastRelease {get; private set;}
  //@ToDo: Futuramente implementar sistema com mais de plano de licensa
  public LicensePaymentPlan PaymentPlan {get; private set;}
  public uint UserNumbers {get; private set;}
}

