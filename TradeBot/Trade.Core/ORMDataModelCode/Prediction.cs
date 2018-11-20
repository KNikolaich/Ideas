using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Trader.ORMDataModelCode;

namespace Trader
{
    [NavigationItem("Bro bot"), XafDisplayName("Предсказание"), DefaultClassOptions, ImageName("Action_Translate")]
    public partial class Prediction : IPersistentObject
    {
        public Prediction() { }

        public Prediction(Session session) : base(session) { }

        public override string ToString()
        {
            return $"{Candle.EndDate.ToString("G")}: {Conclusion}. Цена закрытия:{Candle.ClosePrice.ToString("G")}";
        }

        [NonPersistent, XafDisplayName("Обработано")]
        public bool Overworking { get; set; }

        //public DateTime? Time => Candle.EndDate;

        public bool Saving()
        {
            return IsSaving;
        }
    }

}
