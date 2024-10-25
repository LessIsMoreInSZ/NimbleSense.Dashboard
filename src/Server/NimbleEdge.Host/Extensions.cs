using Carter;
using DeviceCenter.Infrastructure;
using System.Reflection;

namespace NimbleEdge.Host;

public static class Extensions
{
    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var assemblies = new Assembly[]
        {
            typeof(DeviceCenterModule).Assembly
        };

        builder.RegisterDeviceCenterServices();

        builder.Services.AddCarter(configurator: config =>
        {
           config.WithModule<DeviceCenterModule.Endpoints>();
        });

        return builder;
    }

    public static WebApplication UseModules(this WebApplication app) 
    {
        ArgumentNullException.ThrowIfNull(app);

        app.UseDeviceCenterModule();

        return app;
    }
}
