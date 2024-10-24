using Diagram.Core.Model;

namespace Diagram.Core.Interface;

/// <summary>
/// 控件显示接口
/// </summary>
public interface IDiagramItemViewModel
{
    /// <summary>
    /// 是否选中
    /// </summary>
    bool IsSelected { get; set; }

    /// <summary>
    /// 控件设计模型
    /// </summary>
    DiagramItemPropertyModel DesignModel { get; }
}