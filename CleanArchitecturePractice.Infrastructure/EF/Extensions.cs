using CleanArchitecturePractice.Application.Services;
using CleanArchitecturePractice.Domain.Repositories;
using CleanArchitecturePractice.Infrastructure.EF.Contexts;
using CleanArchitecturePractice.Infrastructure.EF.Options;
using CleanArchitecturePractice.Infrastructure.EF.Repositories;
using CleanArchitecturePractice.Infrastructure.EF.Services;
using CleanArchitecturePractice.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecturePractice.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            services.AddDbContext<ReadDbContext>(ctx => 
                ctx.UseNpgsql(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseNpgsql(options.ConnectionString));

            return services;
        }
    }
}
