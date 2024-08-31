using Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DepedencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(config =>
    {
      config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
    });

    services.AddScoped(
        typeof(IPipelineBehavior<,>),
        typeof(ValidationBehaviors<,>)
    );

    services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

    return services;
  }
}
