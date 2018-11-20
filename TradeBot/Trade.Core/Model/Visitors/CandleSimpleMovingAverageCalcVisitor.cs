using System.Linq;
using DevExpress.Data.Filtering;
using Trader.ORMDataModelCode;
using Trader.Visitor;

namespace Trader.Model.Visitors
{
    /// <summary>
    /// визитер для свечей
    /// вычисляет простые скользящие средние для свечи
    /// </summary>
    internal class CandleSimpleMovingAverageCalcVisitor : VisitorBase<Candle>
    {
        public CandleSimpleMovingAverageCalcVisitor()
        {
            NeedAccept = false;
        }

        internal override void Accept(Candle candle)
        {
            var conditionStr = $"MovAvgType = '{MovingAverageTypeEnum.Simple}' AND Active = 1";
            var allSmo = OrmDataHelper.GetCollection<Nsi_MovingAverage>(conditionStr);

            if (allSmo != null)
            {
                
                // аккумулируем значения средних в словарик
                byte iter = 0; // итерация

                foreach (var movingAverage in allSmo.OrderBy(d=>d.Depth))
                {
                    iter++;
                    if (movingAverage.MovAvgType == MovingAverageTypeEnum.Simple)
                    {
                        candle.Sma(movingAverage.Depth);
                    }
                }
                string message = candle.GetMessageBySMA(true);
            
                if (!string.IsNullOrEmpty(message))
                    AddMessage(message);

                NeedAccept = false;
            }

        }

    }
}
