using Dashboard.Core.Models;

namespace Dashboard.Core.Services.Interfaces;

public interface INimbleClient
{
    /// <summary>
    /// 加载所有的点位
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<MonitorAreaQueryModel>> LoadAllPositionsAsync();
}
