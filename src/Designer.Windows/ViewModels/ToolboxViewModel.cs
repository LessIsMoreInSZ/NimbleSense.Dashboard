using Diagram.Common.Background;

namespace Designer.Windows.ViewModels;

public class ToolboxViewModel :BindableBase
{

    public SettingsViewModel SettingsVM { get; } = new SettingsViewModel();

    public ToolboxViewModel()
    {

    }
}

public class SettingsViewModel: BindableBase
{
    public BackgroundPropertyModel Model { get; }

    public SettingsViewModel()
    {
        Model = new BackgroundPropertyModel();
    }
}
