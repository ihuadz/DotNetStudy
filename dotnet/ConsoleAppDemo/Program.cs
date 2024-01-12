using ConsoleAppDemo.DISamples;
using ConsoleAppDemo.DISamples.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appName = AppDomain.CurrentDomain.FriendlyName;

            //host建造者
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            //依赖注入
            builder.Services.AddTransient<IExampleTransientService, ExampleTransientService>();
            builder.Services.AddScoped<IExampleScopedService, ExampleScopedService>();
            builder.Services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
            builder.Services.AddTransient<ServiceLifetimeReporter>();

            IHostEnvironment env = builder.Environment;
            builder.Configuration.AddJsonFile($"test.json", true, true);

            //创建Host
            using IHost host = builder.Build();

            //依赖注入生命周期
            ExemplifyServiceLifetime(host.Services, "Lifetime 1");
            ExemplifyServiceLifetime(host.Services, "Lifetime 2");

            //配置
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
            // Get values from the config given their key and their target type.
            int keyOneValue = config.GetValue<int>("KeyOne");
            bool keyTwoValue = config.GetValue<bool>("KeyTwo");
            string? keyThreeNestedValue = config.GetValue<string>("KeyThree:Message");
            // Write the values to the console.
            Console.WriteLine($"KeyOne = {keyOneValue}");
            Console.WriteLine($"KeyTwo = {keyTwoValue}");
            Console.WriteLine($"KeyThree:Message = {keyThreeNestedValue}");

            // Get values from the config given their key and their target type.
            string? ipOne = config["IPAddressRange:0"];
            string? ipTwo = config["IPAddressRange:1"];
            string? ipThree = config["IPAddressRange:2"];
            string? versionOne = config["SupportedVersions:v1"];
            string? versionThree = config["SupportedVersions:v3"];

            // Write the values to the console.
            Console.WriteLine($"IPAddressRange:0 = {ipOne}");
            Console.WriteLine($"IPAddressRange:1 = {ipTwo}");
            Console.WriteLine($"IPAddressRange:2 = {ipThree}");
            Console.WriteLine($"SupportedVersions:v1 = {versionOne}");
            Console.WriteLine($"SupportedVersions:v3 = {versionThree}");

            string? mySetting = config["MySetting"];
            Console.WriteLine($"MySetting = {mySetting}");
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
