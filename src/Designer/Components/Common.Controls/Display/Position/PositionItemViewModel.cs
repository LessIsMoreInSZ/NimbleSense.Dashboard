using Diagram.Core.Interface;
using Diagram.Core.Model;

namespace Diagram.Common.Display.Position;

public class PositionItemViewModel : BindableBase, IDiagramItemViewModel
{
    public bool IsSelected { get; set; }

    public DiagramItemPropertyModel DesignModel { get; }

    public PositionItemViewModel()
    {
        DesignModel = new PositionPropertyModel()
        {
            Width = 200,
            Height = 200,
            X = 500,
            Y = 200
        };

    }
}

public class PositionPropertyModel: DiagramItemPropertyModel
{

}
