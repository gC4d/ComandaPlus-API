using AutoMapper;
using ComandaPlus_API.Application.Cache;
using ComandaPlus_API.Application.Dtos;
using ComandaPlus_API.Domain.Entities;
using ComandaPlus_API.Interfaces.Repositories;
using EmailService;
using Microsoft.Extensions.Caching.Memory;

namespace ComandaPlus_API.Services;

public class UserService(
    IUserRepository userRepository, 
    IMapper mapper, 
    IEmailSender emailSender,
    IMemoryCache cache)
{  
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEmailSender _emailSender = emailSender;
    private readonly IMapper _mapper = mapper;
    private readonly IMemoryCache _cache = cache;


    public async Task<UserDTO> Create(UserDTO request)
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



    public void AddToCache<T>(T userCache) where T : UserCache
    {
        if (userCache == null)
            throw new ArgumentNullException(nameof(userCache), "User cache cannot be null.");
        
        _cache.Set(
            $"pending_user:{userCache.user.Email}", 
            userCache, 
            TimeSpan.FromMinutes(15)
        );
    }

    public VerifyUserCache GetPendingVerifyUser(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email), "Email cannot be null when tries to get pending user");

        _cache.TryGetValue($"pending_user:{email}", out VerifyUserCache pendingUser);

        return pendingUser;
    }
    
    private async Task VerifyEmail(EmailUser emailUser, string subject, string content)
    {
        var message = new Message(
            new List<EmailUser>(){ emailUser },
            subject,
            content,
            MimeKit.Text.TextFormat.Html
        );
        await _emailSender.SendMailAsync(message);
    }
}
