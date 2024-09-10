using Diagram.Common.Display.Position;
using Diagram.Core.Interface;
using System.Collections.ObjectModel;

namespace Diagram.Common;

/// <summary>
/// 画布VM
/// </summary>
public  class DiagramCanvasViewModel: BindableBase, IDiagramCanvasViewModel
{
    public ObservableCollection<IDiagramItemViewModel> DiagramItems { get; } = new ObservableCollection<IDiagramItemViewModel>();

    public DiagramCanvasViewModel()
    {
    }
}
