using Diagram.Common.Display.Position;
using System.Windows;
using System.Windows.Controls;

namespace Diagram.Common.Selector;

public class DiagramItemTemplateSelector : DataTemplateSelector
{
    public DiagramItemTemplateSelector() 
    {
    }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var element = container as FrameworkElement;

        if (item.GetType() == typeof(PositionItemViewModel))
        {
            return element.FindResource("PositionItemTemplate") as DataTemplate;
        }

        return base.SelectTemplate(item, container);
    }
}
