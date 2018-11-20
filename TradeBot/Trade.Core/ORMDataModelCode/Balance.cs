using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace Trader
{

    [NavigationItem("Bro bot"), XafDisplayName("Баланс"), DefaultClassOptions, ImageName("TemplatesV2Images.BO_Invoice")]
    public partial class Balance
    {
        public Balance(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        
    }

}
