using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using XUnit.Api.Interfaces.Repository;
using XUnit.Api.Interfaces.Services;
using XUnit.Api.Repository;
using XUnit.Api.Services;

namespace XUnit.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, Container container)
        {
            container.Register<IGameRepository, GameRepository>();
            container.Register<IGameService, GameService>();

            return services;
        }
    }
}
