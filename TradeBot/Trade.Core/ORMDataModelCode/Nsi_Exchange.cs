using System.Collections.Specialized;
using System.Configuration;
using DevExpress.Xpo;
using System.Linq;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using Trader.Ancillary;
using Trader.ORMDataModelCode;

namespace Trader
{
    /// <summary>
    /// Справочник Биржа. содержит ссылку на подключение к бирже и ключи
    /// </summary>
    [DefaultClassOptions, ImageName("BO_Opportunity")]
    [NavigationItem("Bro bot"), XafDisplayName("Биржи")]
    public partial class Nsi_Exchange : IPersistentObject
    {
        public Nsi_Exchange() : base(Session.DefaultSession) { }

        public Nsi_Exchange(Session session) : base(session) { }


        /// <summary>
        /// Берем запись текущей биржи
        /// </summary>
        /// <returns></returns>
        public static Nsi_Exchange GetCurrentExchange()
        {
            var exchanges = OrmDataHelper.GetCollection<Nsi_Exchange>();
            var exchangeCurrent = exchanges.FirstOrDefault(excha => excha.Name == Burse.CurrentName);
            return exchangeCurrent;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public bool Saving()
        {
            return IsSaving;
        }

        public void InitBinanceCoin()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            Name = "BinanceCoin";
            ApiAddress = "wss://stream.binance.com:9443/ws/";
            ApiKey = appSettings["YourApiKey"];
            SecretKey = appSettings["YourApiSecret"];
        }
    }

}
