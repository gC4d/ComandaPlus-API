using ComandaPlus_API.Interfaces.Repositories;
using ComandaPlus_API.Mappins;
using ComandaPlus_API.Context;
using ComandaPlus_API.Repositories;
using Microsoft.EntityFrameworkCore;
using ComandaPlus_API.Interfaces.Services;
using ComandaPlus_API.Services;
using EmailService;
using ComandaPlus_API.Application.Interfaces;
using ComandaPlus_API.Application.Services;

namespace ComandaPlus_IoC;

public static class DependecyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)
            )
        );

        services.AddAutoMapper(typeof(DTOMappingProfile));
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILicenseService, LicenseService>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<IUserService,UserService>();
        

        return services;
    }
}
