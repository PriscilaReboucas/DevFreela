using DevFreela.Core.Interfaces.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProvidedServiceRepository, ProvidedServiceRepository>();

            return services;
        }
    }
}
