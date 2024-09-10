
using System.Windows.Controls;
using System.Windows.Input;

namespace Diagram.Common;

public class DiagramCanvas : Canvas
{

    public DiagramCanvas() 
    { 
         AllowDrop = true;
    }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseButtonEventArgs e)
    {
        base.OnMouseUp(e);
    }
}

