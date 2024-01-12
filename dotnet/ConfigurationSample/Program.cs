using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigurationSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //host建造者
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Configuration.AddJsonFile($"test.json", true, true);

            //创建Host
            using IHost host = builder.Build();
            //配置
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

            var env = builder.Environment;

            Console.WriteLine($"Current Environment is {env.EnvironmentName}");

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
    }
}
