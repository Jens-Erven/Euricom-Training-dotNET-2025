using GymManagment.Application.Common.Interfaces;
using GymManagment.Infrastructure.Common.Persistence;
using GymManagment.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<GymManagementDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<GymManagementDbContext>());
        return services;

    }
}
