using System.ComponentModel;

namespace Trader.Ancillary
{
    /// <summary>
    /// значения выполнения цели
    /// </summary>
    public enum TargetEnum
    {
        [Description("Неопределена")]
        Undefine = 0,
        [Description("Не была достигнута")]
        WasNotMet = 1,
        [Description("Была достигнута")]
        WasMet = 2,
        [Description("Недостижима")]
        Unreachable = 3,

    }
}