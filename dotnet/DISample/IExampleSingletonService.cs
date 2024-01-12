using Microsoft.Extensions.DependencyInjection;

namespace DISample
{
    internal interface IExampleSingletonService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}
