using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppDemo.DISamples
{
    internal interface IExampleSingletonService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}
