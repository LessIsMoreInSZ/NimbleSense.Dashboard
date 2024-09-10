using System.Collections.ObjectModel;

namespace Diagram.Core.Interface;

public interface IDiagramCanvasViewModel
{
    ObservableCollection<IDiagramItemViewModel> DiagramItems { get; }
}
