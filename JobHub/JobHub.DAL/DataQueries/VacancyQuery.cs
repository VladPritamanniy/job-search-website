using JobHub.DAL.Data.DBObjects;
using JobHub.DAL.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.DAL.DataQueries
{
    public partial class DataQuery
    {
        public static class VacancyQuery
        {
            public static IEnumerable<DBVacancy> GetVacancy()
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    var sql = "SELECT * FROM Vacancy";
                    var query = session.CreateSQLQuery(sql).AddEntity(typeof(DBVacancy));
                    return query.List<DBVacancy>();
                }
            }
        }
    }
}
