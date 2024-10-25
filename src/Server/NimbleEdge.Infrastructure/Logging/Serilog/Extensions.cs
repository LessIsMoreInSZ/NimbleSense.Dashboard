
using Microsoft.AspNetCore.Builder;

namespace NimbleEdge.Infrastructure.Logging.Serilog;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureSerilog(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        //builder.Host.UseS

        return builder;
    }
}
