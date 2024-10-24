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
    public PositionsViewModel PositionsVM { get; } 
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

        PositionsVM = new PositionsViewModel(_eventAggregator);
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
    private readonly IEventAggregator _eventAggregator;

    public ObservableCollection<AreaViewModel> AreaViewModels { get; } = new ObservableCollection<AreaViewModel>();

    public PositionsViewModel(IEventAggregator eventAggregator) 
    {
        _eventAggregator = eventAggregator;
    }

    public void AddPositions(IReadOnlyCollection<MonitorAreaQueryModel> positions)
    {
        foreach (var monitorAreaQueryModel in positions)
        {
            AreaViewModels.Add(new AreaViewModel(_eventAggregator, monitorAreaQueryModel));
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
        aa.Controls.Add(new ControlViewModel("时间", "text_static.png"));
        aa.Controls.Add(new ControlViewModel("文字", "text_static.png"));
        aa.Controls.Add(new ControlViewModel("图片", "text_static.png"));
        aa.Controls.Add(new ControlViewModel("图片2", "text_static.png"));
        aa.Controls.Add(new ControlViewModel("图片3", "text_static.png"));

        var bb = new GroupedControlViewModel("告警控件");
        bb.Controls.Add(new ControlViewModel("告警记录", "text_static.png"));
        bb.Controls.Add(new ControlViewModel("告警曲线", "text_static.png"));

        GroupedControls.Add(aa);
        GroupedControls.Add(bb);
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


