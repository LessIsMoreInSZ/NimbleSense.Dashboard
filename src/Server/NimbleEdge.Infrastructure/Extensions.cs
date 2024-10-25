using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace NimbleEdge.Infrastructure;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureFramework(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder;
    }

    public static WebApplication UseFramework(this WebApplication app)
    {
        app.UseRouting();
        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "assets")),
            RequestPath = new Microsoft.AspNetCore.Http.PathString("/assets")
        });

        app.UseAuthentication();
        app.UseAuthorization();
        
        //var versions = app.U

        return app;
    }
}
