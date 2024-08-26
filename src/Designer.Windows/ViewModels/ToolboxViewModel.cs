using Dashboard.Core.Models;
using Dashboard.Core.Services.Interfaces;
using Designer.Windows.ViewModels.Models;
using Diagram.Common.Background;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace Designer.Windows.ViewModels;

public class ToolboxViewModel :BindableBase
{
    private readonly INimbleClient _nimbleClient;

    public PositionsViewModel PositionsVM { get; } = new PositionsViewModel();
    public SupportedControlsViewModel SupportedControlsVM { get; } = new SupportedControlsViewModel();
    public SettingsViewModel SettingsVM { get; } = new SettingsViewModel();

    public DelegateCommand LoadedCommand { get; }


    public ToolboxViewModel(INimbleClient nimbleClient, IEventAggregator eventAggregator)
    {
        _nimbleClient = nimbleClient;

        LoadedCommand = new DelegateCommand(OnLoad);
    }

    private async void OnLoad()
    {
        await LoadPositionsAsync();
    }

    private async Task LoadPositionsAsync()
    {
        var positions = await _nimbleClient.LoadAllPositionsAsync();
        Dispatcher.CurrentDispatcher.Invoke(() =>
        {
            PositionsVM.AddPositions(positions);   
        });
    }
}

/// <summary>
/// 所有点位功能列表
/// </summary>
public class PositionsViewModel : BindableBase
{
    public ObservableCollection<AreaViewModel> AreaViewModels { get; } = new ObservableCollection<AreaViewModel>();

    public PositionsViewModel() 
    {
    
    }

    public void AddPositions(IReadOnlyCollection<MonitorAreaQueryModel> positions)
    {
        foreach (var monitorAreaQueryModel in positions)
        {
            AreaViewModels.Add(new AreaViewModel(null, monitorAreaQueryModel));
        }
    }
}

/// <summary>
/// 支持的空间列表
/// </summary>
public class SupportedControlsViewModel : BindableBase
{

}

/// <summary>
/// 设置功能模版
/// </summary>
public class SettingsViewModel: BindableBase
{
    public BackgroundPropertyModel Model { get; }

    public SettingsViewModel()
    {
        Model = new BackgroundPropertyModel();
    }
}


