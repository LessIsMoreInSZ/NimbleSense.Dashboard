namespace Dashboard.Core.Models;

public class MonitorAreaQueryModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<MonitorPositionQueryModel> Positions { get; set; }
}

public class MonitorPositionQueryModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool Opened { get; set; }

    public CleannessLevel Cleanness { get; set; }

    public ICollection<MonitorPositionFunctionQueryModel> PositionFunctions { get; set; }
}

public class MonitorPositionFunctionQueryModel
{
    public PositionFunctionEnum Key { get; set; }

    public ICollection<MonitorDeviceFunctionQueryModel> DeviceFunctions { get; set; }
}

public class MonitorDeviceFunctionQueryModel
{
    public string Key { get; set; }

    public int Id { get; set; }

    public double UpdatedValue { get; set; }

    public DeviceStatus DeviceStatus { get; set; }

    public string Unit { get; set; }
}

/// <summary>
/// 设备状态
/// </summary>
public enum DeviceStatus
{
    /// <summary>
    /// 设备未启动
    /// </summary>
    NotStarted,
    /// <summary>
    /// 设备离线
    /// </summary>
    Offline,
    /// <summary>
    /// 设备正常
    /// </summary>
    Normal,
    /// <summary>
    /// 设备预警
    /// </summary>
    Warning,
    /// <summary>
    /// 设备告警
    /// </summary>
    Alarm
}

/// <summary>
/// 洁净等级
/// </summary>
public enum CleannessLevel
{
    /// <summary>
    /// GMP 
    /// </summary>
    GMPA, GMPB, GMPC, GMPD,

    /// <summary>
    /// 洁净室（区）空气洁净等级表
    /// </summary>
    Level10, Level100, Level1000, Level10000, Level100000, Level1000000,

    /// <summary>
    /// ISO14644-1(国际标准)
    /// </summary>
    ISOClass1, ISOClass2, ISOClass3, ISOClass4, ISOClass5, ISOClass6, ISOClass7, ISOClass8, ISOClass9
}

/// <summary>
/// 点位功能类型
/// </summary>
public enum PositionFunctionEnum
{
    /// <summary>
    /// 粒子计数
    /// </summary>
    ParticleCounting,
    /// <summary>
    /// 浮游菌
    /// </summary>
    AirborneMicrobe,
    /// <summary>
    /// 温湿度
    /// </summary>
    Humiture,
    /// <summary>
    /// 环境参数
    /// </summary>
    Environment,
    /// <summary>
    /// 风速
    /// </summary>
    Wind,
    /// <summary>
    /// 压差
    /// </summary>
    Press,
    /// <summary>
    /// 氧气
    /// </summary>
    Oxygen,
    /// <summary>
    /// 露点
    /// </summary>
    DewPoint
}