using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

namespace Trader.ORMDataModelCode
{
    internal class MySafeDataLayer : ThreadSafeDataLayer
    {
        public MySafeDataLayer(XPDictionary dictionary, IDataStore provider, params Assembly[] persistentObjectsAssemblies) : base(dictionary, provider, persistentObjectsAssemblies)
        {
        }

        public override UpdateSchemaResult UpdateSchema(bool dontCreate, params XPClassInfo[] types)
        {

            return base.UpdateSchema(dontCreate, types);
        }
    }
}
