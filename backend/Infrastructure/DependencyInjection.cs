using Application.Data;
using Domain.Primitives;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddPersistence(configuration);
    return services;
  }

  public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("Database")));

    services.AddScoped<IApplicationDbContext>(sp =>
        sp.GetRequiredService<ApplicationDbContext>());

    services.AddScoped<IUnitOfWork>(sp =>
        sp.GetRequiredService<ApplicationDbContext>());

    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    services.AddScoped<DbContext>(sp =>
        sp.GetRequiredService<ApplicationDbContext>());

    services.AddScoped<IClientRepositoryLinq, ClientLinqRepository>();
    services.AddScoped<IClientRepositoryStore, ClientStoreRepository>();
    return services;
  }
}
