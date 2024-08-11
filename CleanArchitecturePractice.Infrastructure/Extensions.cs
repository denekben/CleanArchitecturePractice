using CleanArchitecturePractice.Application.Services;
using CleanArchitecturePractice.Infrastructure.EF;
using CleanArchitecturePractice.Infrastructure.EF.Services;
using CleanArchitecturePractice.Infrastructure.Logging;
using CleanArchitecturePractice.Shared.Abstractions.Commands;
using CleanArchitecturePractice.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecturePractice.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgres(configuration);
            services.AddQueries();
            services.AddSingleton<IWeatherService, DumbWeatherService>();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            return services;
        }
    }
}
