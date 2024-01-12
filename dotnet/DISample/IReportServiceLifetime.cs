using Microsoft.Extensions.DependencyInjection;

namespace DISample
{
    internal interface IReportServiceLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}
