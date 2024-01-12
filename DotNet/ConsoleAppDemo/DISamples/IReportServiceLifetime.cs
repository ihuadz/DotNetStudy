using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppDemo.DISamples
{
    internal interface IReportServiceLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}
