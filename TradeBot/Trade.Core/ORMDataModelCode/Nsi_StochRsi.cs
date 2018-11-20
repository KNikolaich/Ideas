using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace Trader
{

    [DefaultClassOptions, ImageName("BO_Opportunity")]
    [NavigationItem("Bro bot"), XafDisplayName("Стахастик RSI")]
    public partial class Nsi_StochRsi
    {
        public Nsi_StochRsi(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }


        public void InitNewInstance()
        {
            Active = true;
            RsiDepth = 14;
            StochDepth = 9;
            MaPrima = 3;
            MaSecond = 3;
            ModelName = $"Stochastic RSI ({RsiDepth},{StochDepth},{MaPrima},{MaSecond})";
            Premise = @"Характеристики индикатора Stochastic RSI
Зона перекупленности (от 80 до 100);
Нейтральная зона (от 20 до 80);
Зона перепроданности (от 0 до 20).";
            Probability = 80;
            Explanation =
                @"     Стохастик представляет собой две линии, которые ограничены в промежутке от 0 до 100.
Эти линии Стохастика называются: быстрая - %К и медленная - %D. Линии движутся по простому математическому закону.";
        }
    }

}
