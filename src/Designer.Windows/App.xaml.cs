using Dashboard.Core.Services;
using Dashboard.Core.Services.Interfaces;
using Designer.Windows.Views;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;

namespace Designer.Windows;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainView>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        if (!Directory.Exists(Constants.AppDataPath))
        {
            Directory.CreateDirectory(Constants.AppDataPath);
        }
        var builder = new ConfigurationBuilder()
                .SetBasePath(Constants.AppDataPath)
                .AddIniFile("setting.ini", false, true);

        var configuration = builder.Build();

        containerRegistry.RegisterInstance<IConfiguration>(configuration);

        //register views
        //containerRegistry.RegisterDialog<LoginView>("login");

        containerRegistry.RegisterSingleton<INimbleClient, NimbleClient>();
    }
}

