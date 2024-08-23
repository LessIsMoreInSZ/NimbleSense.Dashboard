using System.Windows;

namespace Designer.Windows.Views;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var toolbox = ((PrismApplication)Application.Current).Container.Resolve<ToolboxView>();
        toolbox.Show();
    }
}