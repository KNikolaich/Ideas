using System;

namespace DbClient
{
    public class Class1
    {

        /// <summary>
        /// Удостоверяемся, что запрос предназначался нашему ЛПУ
        /// </summary>
        internal static bool CheckForOurLPUExist(string idLpuStr)
        {
            //if (DBWorker.GetAvicenna() == null)
            //    throw new Exception("Ошибка инициализации!");
            //if (int.TryParse(idLpuStr, out var idLpu))
            //    return Kosta.Business.Enterprise.ResourceSales.Helpers.NetrikaHelper.CheckForOurLPUExist(idLpu);
            return false;
        }

        /// <summary>
        /// Удостоверяемся, что запрос предназначался нашему ЛПУ
        /// </summary>
        public static bool CheckForOurLPUExist(int idLpu)
        {
            if (idLpu == 0)
                throw new Exception("Неверный идентификатор ЛПУ: \"" + idLpu + "\"");

        //    var odvBAEs = new ObjectDataView(typeof(BusinessAgent_Enterprise), true);
        //    odvBAEs.Query.AddCondition(Sql.Equal(Sql.Field("CodeForNetrika"), Sql.Param("meCode", idLpu)));
        //    odvBAEs.Query.AddCondition(Sql.NotIsNull(Sql.Field("Enterprise")));
        //    odvBAEs.Query.AddField("Enterprise");
        //    odvBAEs.Load();

        //    if (odvBAEs.Count > 1)
        //        throw new Exception("В БД обнаружено несколько BusinessAgent_Enterprise с кодом для N3 = \"" + idLpu +
        //                            "\"");
        //    if (odvBAEs.Count == 0)
        //        return false;
        //    var ent = odvBAEs.Cast<DataRowView>().Select(r => (Guid)r["EnterpriseID"]).First();
        //    var tqOurEnt = new ObjectDataView(typeof(OurEnterprise), true);
        //    tqOurEnt.Query.Top = 1;
        //    tqOurEnt.Query.AddCondition(Sql.Equal(Sql.Field("Enterprise"), Sql.Param("myEnt", ent)));
        //    tqOurEnt.Load();
        //    return tqOurEnt.Count > 0;
        //}
    }
}
