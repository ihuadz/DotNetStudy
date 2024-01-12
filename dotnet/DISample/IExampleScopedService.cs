using Microsoft.Extensions.DependencyInjection;

namespace DISample
{
    internal interface IExampleScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}
