using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppDemo.DISamples
{
    internal interface IExampleTransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
