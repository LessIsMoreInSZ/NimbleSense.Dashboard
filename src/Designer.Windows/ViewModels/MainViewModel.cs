using Designer.Windows.Controls;
using Designer.Windows.Events;
using Diagram.Common.Display;
using Diagram.Core.Interface;

namespace Designer.Windows.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public BackgroundViewModel BackgroundVM { get; }

        public MainViewModel(IEventAggregator eventAggregator)
        {
            BackgroundVM = new BackgroundViewModel();
            _eventAggregator = eventAggregator;

            eventAggregator.GetEvent<AddPositionItemEvent>().Subscribe(AddPositionItemReceived);
        }

        public void Test()
        {
            _eventAggregator.GetEvent<ChangeControlSettingEvent>().Publish(BackgroundVM.DisplayModel);
        }

        private void AddPositionItemReceived(IDiagramItemViewModel diagramItemVM)
        {
            BackgroundVM.DiagramCanvasVM.DiagramItems.Add(diagramItemVM);
        }
    }
}
