using JobHub.DAL.Data.DBObjects;
using JobHub.DAL.Session;

namespace JobHub.DAL.DataQueries
{
    public partial class DataQuery
    {
        public static class VacancyQuery
        {
            public static IEnumerable<DBVacancy> GetList()
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    var sql = "SELECT * FROM Vacancy where IsPublished = 1";
                    var query = session.CreateSQLQuery(sql).AddEntity(typeof(DBVacancy));
                    return query.List<DBVacancy>();
                }
            }

            public static DBVacancy GetItem(int id)
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    var query = session.Query<DBVacancy>()
                        .Where(u => u.ID == id)
                        .ToList();
                    if (query.Count == 1)
                        return query[0];
                    return null;
                }
            }
        }
    }
}
