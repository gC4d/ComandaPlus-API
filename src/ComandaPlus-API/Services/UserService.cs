using System;
using AutoMapper;
using ComandaPlus_API.Dtos;
using ComandaPlus_API.Entities;
using ComandaPlus_API.Interfaces.Repositories;
using ComandaPlus_API.Interfaces.Services;
using ComandaPlus_API.Requests.User;

namespace ComandaPlus_API.Services;

public class UserService(IUserRepository userRepository, IMapper mapper)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<UserDTO> Create(CreateUserRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        try
        {
            User userEntity = _mapper.Map<User>(request);
            
            var userCreated = await _userRepository.CreateAsync(userEntity);

            var user = _mapper.Map<UserDTO>(userCreated);

            return user;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occoured while creating a new user", ex);
        }
    }
}
