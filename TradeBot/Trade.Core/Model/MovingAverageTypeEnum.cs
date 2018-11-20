using System.ComponentModel;

namespace Trader.Model
{
    /// <summary>
    /// Типы средних скользящих
    /// </summary>
    public enum MovingAverageTypeEnum
    {
        [Description("Простая")]
        Simple = 0,
        [Description("Экспоненциальная")]
        Exponential = 1,

    }
}