using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using Trader.ORMDataModelCode;

namespace Trader
{
    /// <summary>
    /// Справочник советов.
    /// </summary>

    [DefaultClassOptions, ImageName("Action_AboutInfo"),
     NavigationItem("Bro bot"), XafDisplayName("Справочный совет (базовый)"),]
    public partial class Nsi_Advice : IPersistentObject
    {
        public Nsi_Advice()
        {
        }

        public Nsi_Advice(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public bool Saving()
        {
            return IsSaving;
        }

        public override string ToString()
        {
            return ModelName;
        }
    }

}
