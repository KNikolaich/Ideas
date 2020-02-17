using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnector
{
    public class ClassTest
    {

        public IEnumerable<string> GetEntryGenerator(string code = "17")
        {
            using (var db = new DbConnector.ROSCHINO_1607Entities())
            {

                Int32.TryParse(code, out var intCode);
                var dbBusinessAgent = db.BusinessAgent_Enterprise.Where(bae=>bae.CodeForNetrika == intCode);
                var allAgentEnterprise =  db.BusinessAgent_Enterprise.Where(bae=> bae.EnterpriseID != null);
                foreach (BusinessAgent_Enterprise bae in allAgentEnterprise)
                {
                    yield return bae.Enterprise.FullName;
                }
                if (dbBusinessAgent.Count() > 1)
                    throw new Exception("В БД обнаружено несколько BusinessAgent_Enterprise с кодом для N3 = \"" + code + "\"");
                yield return "-----------------------------------------";
                foreach (BusinessAgent_Enterprise bae in dbBusinessAgent)
                {
                    if (db.OurEnterprise.Any(oe => oe.EnterpriseID == bae.EnterpriseID))
                    {
                        yield return bae.Enterprise.FullName;

                    }
                }
            }
        } 

        ///// <summary>
        ///// Удостоверяемся, что запрос предназначался нашему ЛПУ
        ///// </summary>
        //public static bool CheckForOurLPUExist(int idLpu)
        //{
        //    if (idLpu == 0)
        //        throw new Exception("Неверный идентификатор ЛПУ: \"" + idLpu + "\"");

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
