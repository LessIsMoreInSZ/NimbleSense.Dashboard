using System.ComponentModel;
using System.Windows.Media;

namespace Diagram.Common.Background;

public class BackgroundPropertyModel
{
    [Category("图片源")]
    [DisplayName("背景图")]
    public ImageSource ImageSource { get; set; }

}
