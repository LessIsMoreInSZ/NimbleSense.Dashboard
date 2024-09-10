using System.ComponentModel;
using System.Windows.Media;
using System.Windows;
using Diagram.Core.Interface;

namespace Diagram.Common.Display;

public class BackgroundViewModel: BindableBase
{
    public BackgroundPropertyModel DisplayModel { get; } = new BackgroundPropertyModel();

    public IDiagramCanvasViewModel DiagramCanvasVM { get; } = new DiagramCanvasViewModel();

    public BackgroundViewModel()
    {
    }
}

public class BackgroundPropertyModel
{
    [Category("背景")]
    [DisplayName("图片")]
    public ImageSource ImageSource { get; set; }

    [Category("背景")]
    [DisplayName("位置")]
    public Stretch Stretch { get; set; }

    public HorizontalAlignment HorizontalAlignment { get; set; }
}

