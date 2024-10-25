using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace NimbleEdge.Infrastructure.Identity;

internal static class Extensions
{
    internal static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        return services;
    }

    public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder app)
    {

        return app;
    }
}
