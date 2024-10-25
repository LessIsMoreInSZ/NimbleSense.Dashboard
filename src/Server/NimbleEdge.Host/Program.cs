

using NimbleEdge.Host;
using NimbleEdge.Infrastructure;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.ConfigureFramework()
        .RegisterModules();

    var app = builder.Build();

    app.UseFramework()
        .UseModules();
    await app.RunAsync();
}
catch (Exception ex)
{

}
finally
{

}