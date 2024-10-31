using ComandaPlus_API.Interfaces.Repositories;
using ComandaPlus_API.Mappins;
using ComandaPlus_API.Context;
using ComandaPlus_API.Repositories;
using Microsoft.EntityFrameworkCore;
using ComandaPlus_API.Interfaces.Services;
using ComandaPlus_API.Services;

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
        services.AddScoped<UserService>();
        

        return services;
    }
}
