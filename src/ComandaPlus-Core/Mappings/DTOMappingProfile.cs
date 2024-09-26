using AutoMapper;
using ComandaPlus_Core.Dtos;
using ComandaPlus_Core.Entities;

namespace ComandaPlus_Core.Mappins;

public class DTOMappingProfile : Profile
{
  public DTOMappingProfile()
  {
    CreateMap<Account, AccountDTO>().ReverseMap();
  }
}






