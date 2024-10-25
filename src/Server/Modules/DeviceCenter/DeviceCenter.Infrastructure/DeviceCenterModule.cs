using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DeviceCenter.Infrastructure;

public static class DeviceCenterModule
{
    public class Endpoints: CarterModule
    {
        public Endpoints(): base("devicecenter")
        { 
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("channel").WithTags("channel");
        }
    }

    public static WebApplicationBuilder RegisterDeviceCenterServices(this WebApplicationBuilder builder)
    {

        return builder;
    }

    public static WebApplication UseDeviceCenterModule(this WebApplication app)
    {
        return app;
    }
}
