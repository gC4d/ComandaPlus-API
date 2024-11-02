using AutoMapper;
using ComandaPlus_API.Application.Dtos;
using ComandaPlus_API.Domain.Entities;

namespace ComandaPlus_API.Mappins;

public class DTOMappingProfile : Profile
{
  public DTOMappingProfile()
  {
    CreateMap<Account, AccountDTO>().ReverseMap();
    CreateMap<User, UserDTO>().ReverseMap();
  }
}






