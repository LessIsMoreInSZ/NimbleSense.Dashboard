using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Diagram.Common.Display;

public class BackgroundViewModel: BindableBase
{
    public BackgroundPropertyModel DisplayModel { get; }

    public BackgroundViewModel()
    {
        DisplayModel = new BackgroundPropertyModel();
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

