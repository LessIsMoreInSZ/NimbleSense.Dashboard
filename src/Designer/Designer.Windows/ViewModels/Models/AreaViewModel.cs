using Dashboard.Core.Models;
using Designer.Windows.Events;
using Diagram.Common.Display.Position;
using System.Collections.ObjectModel;

namespace Designer.Windows.ViewModels.Models;

public class AreaViewModel : BindableBase
{
    public MonitorAreaQueryModel AreaModel { get; set; }

    public ObservableCollection<PositionViewModel> PositionViewModels { get; } = new ObservableCollection<PositionViewModel>();

    public AreaViewModel(IEventAggregator eventAggregator, MonitorAreaQueryModel areaModel)
    {
        AreaModel = areaModel;

        foreach (var monitorPositionQueryModel in areaModel.Positions)
        {
            PositionViewModels.Add(new PositionViewModel(eventAggregator, monitorPositionQueryModel));
        }
    }

}

public class PositionViewModel: BindableBase
{
    private readonly IEventAggregator _eventAggregator;
    public MonitorPositionQueryModel PositionModel { get; set; }

    public DelegateCommand AddCommand { get; }

    public ObservableCollection<PositionFunctionViewModel> PositionFunctions { get; } = new ObservableCollection<PositionFunctionViewModel>();

    public PositionViewModel(IEventAggregator eventAggregator, MonitorPositionQueryModel positionModel)
    {
        _eventAggregator = eventAggregator;

        PositionModel = positionModel;

        AddCommand = new DelegateCommand(AddPosition);

        foreach(var position in positionModel.PositionFunctions)
        {
            foreach(var device in position.DeviceFunctions)
            {
                PositionFunctions.Add(new PositionFunctionViewModel(device));
            }
        }
    }

    private void AddPosition()
    {
        _eventAggregator.GetEvent<AddPositionItemEvent>().Publish(new PositionItemViewModel());
    }
}

public class PositionFunctionViewModel : BindableBase
{
    private bool _selected;

    public bool Selected 
    { 
        get=>_selected;
        set
        {
            if (_selected != value)
            {
                _selected = value;
                RaisePropertyChanged();
            }
        }
    }

    public string Name {  get; set; }

    public PositionFunctionViewModel(MonitorDeviceFunctionQueryModel deviceFunction)
    {
        Name = deviceFunction.Key;
    }

}
