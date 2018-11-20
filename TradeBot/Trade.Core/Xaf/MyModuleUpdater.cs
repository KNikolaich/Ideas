using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace Trader.Xaf
{
    /// <summary>
    /// это оставил для примера
    /// </summary>
    public class MyModuleUpdater : ModuleUpdater
    {
        public MyModuleUpdater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        { }


        protected override void OnStatusUpdating(string context, string title, string message, params object[] additionalParams)
        {
            base.OnStatusUpdating(context, title, message, additionalParams);
        }

        /// <summary>
        /// Тут можно жарить скрипты, которые будут по дефолту внедряться на БД при обновлении схемы
        /// </summary>
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            Balance balanceUsdt = ObjectSpace.FindObject<Balance>(
                new BinaryOperator("CurrencyName", "USDT"));
            if (balanceUsdt == null)
            {
                balanceUsdt = ObjectSpace.CreateObject<Balance>();
                //balanceUsdt.Name = "Jane Smith";
                //balanceUsdt.Email = "jane.smith@example.com";
            }
            ObjectSpace.CommitChanges();
            //Contact contactJane = ObjectSpace.FindObject<Contact>(
            //    new BinaryOperator("Name", "Jane Smith"));
            //if (contactJane == null)
            //{
            //    contactJane = ObjectSpace.CreateObject<Contact>();
            //    contactJane.Name = "Jane Smith";
            //    contactJane.Email = "jane.smith@example.com";
            //}
            //Contact contactJohn = ObjectSpace.FindObject<Contact>(
            //    new BinaryOperator("Name", "John Smith"));
            //if (contactJohn == null)
            //{
            //    contactJohn = ObjectSpace.CreateObject<Contact>();
            //    contactJohn.Name = "John Smith";
            //    contactJohn.Email = "john.smith@example.com";
            //}
        }
    }
}
