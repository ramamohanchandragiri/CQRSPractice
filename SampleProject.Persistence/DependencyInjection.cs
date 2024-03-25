using Microsoft.Extensions.DependencyInjection;
using SampleProject.Domain.Interfaces;

namespace SampleProject.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ISampleDatabase, SampleDatabase>();
            return services;
        }
    };
}
