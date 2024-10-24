using System.Windows;
using System.Windows.Controls;

namespace Diagram.Common.Display;
/// <summary>
/// Interaction logic for Background.xaml
/// </summary>
public partial class Background : UserControl
{
    //public static readonly DependencyProperty DemoModelProperty = DependencyProperty.Register(
    //nameof(DemoModel), typeof(BackgroundPropertyModel), typeof(Background), new PropertyMetadata(default(Background)));

    //public BackgroundPropertyModel DemoModel
    //{
    //    get => (BackgroundPropertyModel)GetValue(DemoModelProperty);
    //    set => SetValue(DemoModelProperty, value);
    //}

    public Background()
    {
        InitializeComponent();
    }
}
