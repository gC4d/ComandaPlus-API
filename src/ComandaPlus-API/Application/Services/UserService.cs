using AutoMapper;
using ComandaPlus_API.Application.Dtos;
using ComandaPlus_API.Application.Interfaces;
using ComandaPlus_API.Domain.Entities;
using ComandaPlus_API.Interfaces.Repositories;
using EmailService;

namespace ComandaPlus_API.Services;

public class UserService(
    IUserRepository userRepository, 
    IMapper mapper, 
    IEmailSender emailSender,
    ICacheService cache) 
{  
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEmailSender _emailSender = emailSender;
    private readonly IMapper _mapper = mapper;
    private readonly ICacheService _cache = cache;


    public async Task<UserDTO> CreateAsync(UserDTO request)
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

    private string GenerateVerificationCode()
    {
        return new Random().Next(100000, 999999).ToString();
    }

    public async Task CacheUserDataAsync(UserDTO userDTO) 
    {
        if (userDTO == null)
            throw new ArgumentNullException(nameof(userDTO));
        
        await _cache.SetAsync(
            $"pending_user:{userDTO.Email}", 
            userDTO, 
            TimeSpan.FromMinutes(15)
        );
    }

    public async Task SendVerificationCodeAsync(string email)
    {
        if (email == null)
            throw new ArgumentNullException(nameof(email), "Email cannot be null");

        var verificationCode = GenerateVerificationCode();

        await _cache.SetAsync($"verification:{email}", verificationCode, TimeSpan.FromMinutes(15));
    }

    
    
    private async Task VerifyEmail(EmailUser emailUser, string verificationCode)
    {

        var templatePath = Path.Combine(
            "../../", "resources", "VerificationEmailTemplate.html");
        var content = await File.ReadAllTextAsync(templatePath);

        content = content.Replace("{{UserName}}", emailUser.UserName)
                             .Replace("{{VerificationCode}}", verificationCode);


        var message = new Message(
            new List<EmailUser>(){ emailUser },
            "Email Verification",
            content,
            MimeKit.Text.TextFormat.Html
        );
        await _emailSender.SendMailAsync(message);
    }

    public Task<IEnumerable<UserDTO>> GetAllsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDTO>> GetUsersByAcount(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> UpdateAsync(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }

    public Task RemoveByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
