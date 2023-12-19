using JobHub.DAL.DBObjects;
using JobHub.DAL.Session;

namespace JobHub.DAL.DataQueries
{
    public partial class DataQuery
    {
        public static class ProductQuery
        {
            public static IEnumerable<DBProduct> GetProductsByName(string productName)
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    var sql = "SELECT * FROM Product WHERE Name = :productName";
                    var query = session.CreateSQLQuery(sql).AddEntity(typeof(DBProduct)).SetString("productName", productName);
                    return query.List<DBProduct>();
                }
            }
        }
    }
}
