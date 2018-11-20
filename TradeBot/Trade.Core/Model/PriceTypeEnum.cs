using System.ComponentModel;
using DevExpress.ExpressApp.DC;

namespace Trader.Model
{
    /// <summary>
    /// Цена для расчета может быть Закрытия, открытия, или средняя
    /// </summary>
   
    public enum PriceTypeEnum
    {
    [XafDisplayName("Цена закрытия")]
        ClosePrice,
        [XafDisplayName("Цена открытия")]
        OpenPrice,
        [XafDisplayName("Цена средняя арифм.")]
        AvgPrice
    }
}