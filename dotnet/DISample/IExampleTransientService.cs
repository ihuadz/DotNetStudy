using Microsoft.Extensions.DependencyInjection;

namespace DISample
{
    internal interface IExampleTransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
