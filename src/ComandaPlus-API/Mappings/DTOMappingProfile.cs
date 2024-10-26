using AutoMapper;
using ComandaPlus_API.Dtos;
using ComandaPlus_API.Entities;

namespace ComandaPlus_API.Mappins;

public class DTOMappingProfile : Profile
{
  public DTOMappingProfile()
  {
    CreateMap<Account, AccountDTO>().ReverseMap();
  }
}






