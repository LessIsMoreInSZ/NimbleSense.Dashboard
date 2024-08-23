using System.IO;

namespace Designer.Windows;

public static class Constants
{
    /// <summary>
    /// 数据目录
    /// </summary>
    public static string AppDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings");
}
