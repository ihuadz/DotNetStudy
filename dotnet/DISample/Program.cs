using DISample.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DISample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //host建造者
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            //依赖注入
            builder.Services.AddTransient<IExampleTransientService, ExampleTransientService>();
            builder.Services.AddScoped<IExampleScopedService, ExampleScopedService>();
            builder.Services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
            builder.Services.AddTransient<ServiceLifetimeReporter>();

            //创建Host
            using IHost host = builder.Build();

            //依赖注入生命周期
            ExemplifyServiceLifetime(host.Services, "Lifetime 1");
            ExemplifyServiceLifetime(host.Services, "Lifetime 2");

            //运行host
            host.Run();
        }

        static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
            logger.ReportServiceLifetimeDetails(
                $"{lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()");

            Console.WriteLine("...");

            logger = provider.GetRequiredService<ServiceLifetimeReporter>();
            logger.ReportServiceLifetimeDetails(
                $"{lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()");

            Console.WriteLine();
        }
    }
}
