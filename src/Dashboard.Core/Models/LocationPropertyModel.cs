using System.ComponentModel;

namespace Dashboard.Core.Models;

/// <summary>
/// 包含控件的位置和长宽
/// </summary>
public class LocationPropertyModel
{
    [Category("位置")]
    [DisplayName("长度")]
    public int Height { get; set; }

    [Category("位置")]
    [DisplayName("宽度")]
    public int Width { get; set; }

    [Category("位置")]
    [DisplayName("X轴")]
    public int X { get; set; }

    [Category("位置")]
    [DisplayName("Y轴")]
    public int Y { get; set; }
}
