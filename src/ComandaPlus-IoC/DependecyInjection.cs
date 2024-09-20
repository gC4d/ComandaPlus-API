//using ComandaPlus_Core.;

using ComandaPlus_Core.Mappins;
using ComandaPlus_Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaPlus_IoC;

public static class DependecyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ComandaPlus_Data.Context.DatabaseContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ComandaPlus_Data.Context.DatabaseContext)
                .Assembly.FullName)));
        
        services.AddAutoMapper(typeof(DTOMappingProfile));

        return services;
    }
}
