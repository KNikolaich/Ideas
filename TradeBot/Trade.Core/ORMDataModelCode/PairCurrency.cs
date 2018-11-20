using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using Trader.Ancillary;
using Trader.Model;
using Trader.ORMDataModelCode;

namespace Trader
{
    [DefaultClassOptions, ImageName("ModelEditor_Group")]
    [NavigationItem("Bro bot"), XafDisplayName("Валюты")]
    public partial class Nsi_PairCurrency : IPersistentObject
    {
        public Nsi_PairCurrency(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }


        public override string ToString()
        {
            return $"Валютная пара {Name} на бирже {Exchange}";
        }


        /// <summary>
        /// Валютные пары ищим на бирже, забиваем в БД, 
        /// </summary>
        /// <param name="symbolArr"> высота символа не имеет значения
        /// должен содержать все варианты пар на всех биржах (например btc/usd btcusdt btc/usdt)</param>
        /// <returns></returns>
        public static Nsi_PairCurrency FindCurrencyOrCreate(params string[] symbolArr)
        {
            try
            {
                var session = OrmDataHelper.Session;
                var currentExchange = Burse.CurrentExchange;
                var collection = currentExchange.Nsi_PairCurrencys; //OrmDataHelper.GetCollection<Nsi_PairCurrency>(criteriaOperatorCollection);
                if (currentExchange.Nsi_PairCurrencys.Count == 0)
                {
                    var defaultValues = Burse.FindCurrencyPairList();
                    foreach (var defaultValue in defaultValues)
                    {
                        var nsiPairCurrency = new Nsi_PairCurrency(session)
                        {
                            Active = true,
                            Name = defaultValue,
                            Exchange = currentExchange
                        };
                        collection.Add(nsiPairCurrency);
                        nsiPairCurrency.Save();
                    }
                }
                IEnumerable<string> lowerSymbol = null;
                if (symbolArr.Length > 0)
                {
                   lowerSymbol = symbolArr.Select(item => item.ToLower());
                }
                return collection.FirstOrDefault(pc => pc.Active && (lowerSymbol == null || lowerSymbol.Contains(pc.Name.ToLower())));
            }
            catch (Exception e)
            {
                LogHolder.ErrorLogInfo(e);
                throw;
            }
        }

        public bool Saving()
        {
            return base.IsSaving;
        }
    }

}
