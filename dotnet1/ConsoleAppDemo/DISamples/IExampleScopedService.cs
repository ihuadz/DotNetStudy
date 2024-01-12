using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppDemo.DISamples
{
    internal interface IExampleScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}
