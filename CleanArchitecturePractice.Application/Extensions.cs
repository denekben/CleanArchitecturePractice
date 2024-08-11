using Microsoft.Extensions.DependencyInjection;
using CleanArchitecturePractice.Domain.Factories;
using CleanArchitecturePractice.Domain.Policies;
using CleanArchitecturePractice.Shared.Command;

namespace CleanArchitecturePractice.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.Scan(b=>b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
                .AddClasses(c=>c.AssignableTo<IPackingItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
