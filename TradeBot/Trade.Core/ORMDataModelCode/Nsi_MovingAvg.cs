using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace Trader
{
    /// <summary>
    /// скользящая средняя (справочная)
    /// </summary>
    [DefaultClassOptions, ImageName("BO_Transition"),
    NavigationItem("Bro bot"), XafDisplayName("Справочник Moving Avegares")]
    public partial class Nsi_MovingAverage
    {
        public Nsi_MovingAverage(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        /// <summary> Новый трендовый лайн </summary>
        public void InitNewTrendLine()
        {
            Active = true;
            ModelName = "Трендовая SMA (200)";
            Premise = "Это трендовая линия позволяет посмотреть на перекупленность или перепроданность рынка";
            Explanation = "Считается SMA(200)";
            Depth = 200;
        }
    }

}
