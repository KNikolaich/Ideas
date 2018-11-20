using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace Trader.Xaf
{
    /// <summary>
    /// для xaf отображения и настроек
    /// </summary>
    /// <see cref="https://community.devexpress.com/blogs/eaf/archive/2012/10/30/xaf-application-from-scratch.aspx"/>
    public class OrmTradeModule : ModuleBase
    {
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return new ModuleUpdater[] { new MyModuleUpdater(objectSpace, versionFromDB) };
        }
    }
}
