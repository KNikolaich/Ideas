using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System.Configuration;
using System.Reflection;
using DevExpress.Data.Filtering;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using Trader.Ancillary;

namespace Trader.ORMDataModelCode
{
    public class OrmDataHelper
    {
        #region Инициализация

        private static Session GetNewSession()
        {
            return new Session(DataLayer);
        }

        public static UnitOfWork GetNewUnitOfWork()
        {
            return new UnitOfWork(DataLayer);
        }

        private static readonly object LockObject = new object();

        static volatile IDataLayer _fDataLayer;

        static IDataLayer DataLayer
        {
            get
            {
                if (_fDataLayer == null)
                {
                    lock (LockObject)
                    {
                        if (_fDataLayer == null)
                        {
                            _fDataLayer = GetDataLayer();
                        }
                    }
                }
                return _fDataLayer;
            }
        }

        private static IDataLayer GetDataLayer()
        {
            //XpoDefault.Session = null;

            var conn = GetConnectionString();
            conn = XpoDefault.GetConnectionPoolString(conn);

            XPDictionary dict = new ReflectionDictionary();
            IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.DatabaseAndSchema);
            dict.GetDataStoreSchema(Assembly.GetExecutingAssembly());


            IDataLayer dl = new MySafeDataLayer(dict, store);
            return dl;
        }

        public static Session Session
        {
            get
            {
                var session = (Session.DefaultSession ?? XpoDefault.Session) ?? GetNewSession();
                if (string.IsNullOrEmpty(session.ConnectionString))
                {
                    session.Disconnect();
                    session.ConnectionString = GetConnectionString();
                    session.Connect();
                    InitDbShema(session);
                }
                return session;
            }
        }
        
        private static string GetConnectionString()
        {
            var connStrs = ConfigurationManager.ConnectionStrings;
            var connectionStringSettings = connStrs["Trade"];
            if (connectionStringSettings != null)
            {
                return connectionStringSettings.ConnectionString;
            }

            return ConnectionHelper.ConnectionString;
        }

        /// <summary>
        /// Инициализация базовых значений справочной инфы
        /// </summary>
        /// <param name="session"></param>
        private static void InitDbShema(Session session)
        {
            Nsi_Exchange exchange = session.FindObject<Nsi_Exchange>(new BinaryOperator("Name", "BinanceCoin"));
            if (exchange == null)
            {
                exchange = new Nsi_Exchange(session);
                exchange.InitBinanceCoin();
                exchange.Save();
            }
            
            Nsi_MovingAverage movingAverage = session.FindObject<Nsi_MovingAverage>(CriteriaOperator.Parse("Depth > 49"));
            if (movingAverage == null)
            {
                movingAverage = new Nsi_MovingAverage(session);
                movingAverage.InitNewTrendLine();
                movingAverage.Save();
            }
            Nsi_MacD macD = session.FindObject<Nsi_MacD>(null);
            if (macD == null)
            {
                macD = new Nsi_MacD(session);

                macD.InitNewInstance();
                macD.Save();
            }

            Nsi_Rsi rsi = session.FindObject<Nsi_Rsi>(null);
            if (rsi == null)
            {
                rsi = new Nsi_Rsi(session);

                rsi.InitNewInstance();
                rsi.Save();
            }

            Nsi_StochRsi rsiStoch = session.FindObject<Nsi_StochRsi>(null);
            if (rsiStoch == null)
            {
                rsiStoch = new Nsi_StochRsi(session);

                rsiStoch.InitNewInstance();
                rsiStoch.Save();
            }
        }

        #endregion


        /// <summary>
        /// генерируем коллекцию сортировок
        /// </summary>
        /// <param name="sortedFields"></param>
        /// <returns></returns>
        private static SortingCollection CreateSortingCollection(string[] sortedFields)
        {
            SortingCollection sorted = null;
            List<SortProperty> sortProperties = new List<SortProperty>();
            foreach (var field in sortedFields)
            {
                sortProperties.Add(new SortProperty(field, SortingDirection.Ascending));
            }
            if (sortedFields.Length > 0)
            {
                sorted = new SortingCollection(sortProperties);
            }
            return sorted;
        }


        #region Method to base


        /// <summary> Обновление объекта в БД </summary>
        public static void Update<TXpObj>(TXpObj item) where TXpObj : XPBaseObject, IPersistentObject
        {
            try
            {
                //var ipo = item as IPersistentObject;

                var objFromDb = item.Session.GetObjectByKey(item.GetType(), item.ID) as TXpObj;

                if (objFromDb != null)
                {
                    MapperObject(objFromDb, item);
                    if (!objFromDb.Saving())
                    {
                        objFromDb.Save();
                    }
                }
                else
                {
                    item.Save();
                }

            }
            catch (Exception e)
            {
                LogHolder.ErrorLogInfo(e);
                throw;
            }

        }

        /// <summary> Вставка объекта в БД (если такой id уже есть, он будет изменен) </summary>
        public static void Save<TXpObj>(TXpObj savingObject) where TXpObj : XPBaseObject
        {
            try
            {
                Session.Save(savingObject);
            }
            catch (Exception e)
            {
                LogHolder.ErrorLogInfo(e);
                throw;
            }
        }

        /// <summary> Вставка объекта в БД (если такой id уже есть, он будет изменен) </summary>
        public static void Save<TXpObj>(List<TXpObj> savingCollection) where TXpObj : XPBaseObject
        {
            try
            {
                Session.Save(savingCollection);
            }
            catch (Exception e)
            {
                LogHolder.ErrorLogInfo(e);
                throw;
            }
        }


        public static void Delete<TXpObj>(long id) where TXpObj : XPBaseObject
        {
            try
            {
                var findingObj = FindPobj<TXpObj>(id);
                findingObj.Delete();
            }
            catch (Exception e)
            {
                LogHolder.ErrorLogInfo(e);
                throw;
            }
        }

        #endregion


        /// <summary> По большому счету , это клонирование объекта одного и того же типа </summary>
        /// <param name="objRecipient">объект получатель. В него мы загоняем данные из this</param>
        private static void MapperObject(XPBaseObject objRecipient, XPBaseObject objDonor)
        {
            var propertyInfos = objRecipient.GetType().GetProperties().ToList();
            foreach (XPMemberInfo property in objRecipient.ClassInfo.PersistentProperties)
            {
                string pName = property.Name;
                var piItem = propertyInfos.FirstOrDefault(pi => pi.Name == pName);
                if (piItem != null && piItem.CanRead && piItem.CanWrite)
                {
                    var newValue = piItem.GetValue(objDonor);
                    var oldValue = piItem.GetValue(objRecipient);
                    if (!Equals(oldValue, newValue))
                    {
                        piItem.SetValue(objRecipient, newValue);
                    }
                    //objRecipient.SetPropertyValue(pName, );
                }
            }
        }


        /// <summary> Взять полный справочник </summary>
        /// <returns></returns>
        public static List<TPersObj> GetDirectory<TPersObj>() where TPersObj : XPBaseObject
        {
            return OrmDataHelper.GetCollection<TPersObj>();
        }

        /// <summary> Взять полный справочник </summary>
        /// <returns></returns>
        public List<TPersObj> GetPossibleElement<TPersObj>(XPMemberInfo mInfo) where TPersObj : XPBaseObject
        {
            //mInfo.MemberType.
            return OrmDataHelper.GetCollection<TPersObj>();
        }



        #region Method from base
        
        public static List<TXpObj> GetCollection<TXpObj>(string strCondition, int top = 1000, params string[] sortedFields) where TXpObj : IXPObject
        {
            return GetCollection<TXpObj>(CriteriaOperator.Parse(strCondition), top, sortedFields);
        }

        public static List<TXpObj> GetCollection<TXpObj>(CriteriaOperator criteria = null, int top = 1000, params string[] sortedFields)
            where TXpObj : IXPObject
        {
            List<TXpObj> objects;
            try
            {
                var classInfoTxpObj = Session.GetClassInfo(typeof(TXpObj));
                objects = Session.GetObjects(classInfoTxpObj, criteria, null, top, false, false).Cast<TXpObj>().ToList();
            }
            catch (Exception e)
            {
                LogHolder.ErrorLogInfo(e);
                throw;
            }
            return objects;
        }

        /// <summary> инфо о классе </summary>
        /// <typeparam name="TXpObj">типа класс</typeparam>
        /// <returns>типа инфо</returns>
        public static XPClassInfo GetClassInfo<TXpObj>() where TXpObj : IXPObject
        {
            return Session.GetClassInfo(typeof(TXpObj));
        }

        /// <summary> инфо о классе </summary>
        /// <returns>типа инфо</returns>
        public static XPClassInfo GetClassInfo(string typeOfObject)
        {
            return Session.GetClassInfo(Type.GetType(typeOfObject));
        }

        public static TXpObj FindPobj<TXpObj>(long id) where TXpObj : IXPObject
        {
            return Session.FindObject<TXpObj>(CriteriaOperator.Parse($"ID = {id}"));
        }

        #endregion
        
        public static int DeleteAllBalances()
        {

            try
            {
                //Session.BeginTransaction();
                var count = Session.ExecuteNonQuery("Delete FROM Balance");

                return count;
            }
#pragma warning disable CS0168 // The variable 'exception' is declared but never used
            catch (Exception exception)
#pragma warning restore CS0168 // The variable 'exception' is declared but never used
            {
                throw;
            }
            finally
            {
                //Session.CommitTransaction();
            }
            //// Create a data source with the required connection parameters.    
            //SqlDataSource ds = new SqlDataSource(GetConnectionString());

            //// Create an SQL query to access the Products table. 
            //CustomSqlQuery query = new CustomSqlQuery();
            //query.Name = "customQuery1";
            //query.Sql = "Delete * FROM Balance";

            //ds.Queries.Add(query);
            //return ds;
        }
    }
}
