using AnalyticalCenter.Helpers;

namespace AnalyticalCenter.Indicators
{
    public interface IIndicator
    {
        /// <summary>
        /// Значение
        /// </summary>
        decimal Value { get; }

        /// <summary>
        /// глубина проработки
        /// </summary>
        int Depth { get; }

        /// <summary>
        /// предыдущий индикатор
        /// </summary>
        IIndicator PreviewIndicator { get; }

        /// <summary>
        /// расчет данного индикатора
        /// </summary>
        /// <param name="price"></param>
        /// <param name="preview"></param>
        decimal CalcThis(decimal price, IIndicator preview);
        EnumOrderDirect Validate();
    }
}