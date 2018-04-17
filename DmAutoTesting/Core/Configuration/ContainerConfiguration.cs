using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            var services = new ServiceCollection();

            containerBuilder
                .RegisterAssemblyTypes(Assembly.GetCallingAssembly(), typeof(ContainerConfiguration).Assembly)
                .Where(t => t.IsClass)
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            services
                .AddOptions()
                .ConfigureOptions<GeneralSettings>(configuration)
                .ConfigureOptions<DriverSettings>(configuration);

            containerBuilder.Populate(services);

            return containerBuilder.Build();
        }

        private static IServiceCollection ConfigureOptions<TOptions>(this IServiceCollection services,
            IConfiguration configuration) where TOptions : class =>
            services.Configure<TOptions>(options => configuration.GetSection(typeof(TOptions).Name).Bind(options));
    }
}