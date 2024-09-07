using Designer.Windows.Events;
using Diagram.Common.Display;

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
        }

        public void Test()
        {
            _eventAggregator.GetEvent<ChangeControlSettingEvent>().Publish(BackgroundVM.DisplayModel);
        }
    }
}
