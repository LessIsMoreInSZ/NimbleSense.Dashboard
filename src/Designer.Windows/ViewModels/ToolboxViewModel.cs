using Dashboard.Core.Models;
using Dashboard.Core.Services.Interfaces;
using Designer.Windows.Events;
using Designer.Windows.ViewModels.Models;
using Diagram.Common.Display;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace Designer.Windows.ViewModels;

public class ToolboxViewModel :BindableBase
{
    private readonly INimbleClient _nimbleClient;
    private readonly IEventAggregator _eventAggregator;

    public MenuButtonsViewModel MenusVM { get; } = new MenuButtonsViewModel();
    public PositionsViewModel PositionsVM { get; } = new PositionsViewModel();
    public SupportedControlsViewModel SupportedControlsVM { get; } = new SupportedControlsViewModel();
    public SettingsViewModel SettingsVM { get; } = new SettingsViewModel();

    public DelegateCommand LoadedCommand { get; }

    public ToolboxViewModel(INimbleClient nimbleClient, 
        IEventAggregator eventAggregator)
    {
        _nimbleClient = nimbleClient;
        _eventAggregator = eventAggregator;

        LoadedCommand = new DelegateCommand(OnLoad);

        _eventAggregator.GetEvent<ChangeControlSettingEvent>().Subscribe(ChangeControlSettingReceived);
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

    private async Task LoadSupportedControlsAsync()
    {
        
    }

    private void ChangeControlSettingReceived(object displayModel)
    {
        SettingsVM.DisplayModel = displayModel;
    }
}

public class MenuButtonsViewModel: BindableBase
{
    /// <summary>
    /// 导入大屏模版
    /// </summary>
    public DelegateCommand ImportCommand { get; }

    /// <summary>
    /// 导出设计完的大屏
    /// </summary>
    public DelegateCommand ExportCommand { get; }

    /// <summary>
    /// 退出程序
    /// </summary>
    public DelegateCommand ExitCommand { get; }

    public MenuButtonsViewModel()
    {
        ImportCommand = new DelegateCommand(Import);
        ExportCommand = new DelegateCommand(Export);
        ExitCommand = new DelegateCommand(Exit);
    }

    private void Import()
    {

    }

    private void Export()
    {
    }

    private void Exit()
    {
        Environment.Exit(0);
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
/// 支持的控件列表
/// </summary>
public class SupportedControlsViewModel : BindableBase
{
    public ObservableCollection<GroupedControlViewModel> GroupedControls { get; } = new ObservableCollection<GroupedControlViewModel>();

    public SupportedControlsViewModel() 
    {
        var aa = new GroupedControlViewModel("基础控件");
        aa.Controls.Add(new ControlViewModel("Time", ""));
        GroupedControls.Add(aa);
    }
}

/// <summary>
/// 设置功能模版
/// </summary>
public class SettingsViewModel: BindableBase
{
    private object _displayModel;

    public object DisplayModel 
    { 
        get => _displayModel; 
        set 
        { 
            _displayModel = value;
            RaisePropertyChanged();
        } 
    }

    public SettingsViewModel()
    {
        //Model = new BackgroundPropertyModel();
    }

}


