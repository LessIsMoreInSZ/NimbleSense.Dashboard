namespace Dashboard.Core.Models;

/// <summary>
/// 大屏展示布局
/// </summary>
public class DisplayLayout
{
    /// <summary>
    /// 大屏控件
    /// </summary>
    public List<ControlLayout> Controls { get; set; } = new List<ControlLayout>();
}

/// <summary>
/// 控件布局
/// </summary>
public class ControlLayout
{
    /// <summary>
    /// 控件名称
    /// </summary>
    public string Name { get; set; } 
    /// <summary>
    /// 控件宽度
    /// </summary>
    public int Width {  get; set; }

    /// <summary>
    /// 控件高度
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// X轴距离
    /// </summary>
    public int Left { get; set; }

    /// <summary>
    /// Y轴距离
    /// </summary>
    public int Top { get; set; }
}
