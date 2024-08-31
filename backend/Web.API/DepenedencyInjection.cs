using System.Text.Json.Serialization;
using Web.API.Middlewares;

namespace Web.API;

public static class DepedencyInjection
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddControllers()
    .AddJsonOptions(options =>
      {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
      });
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddTransient<GlobalExceptionHandlingMiddleware>();

    return services;
  }
}
