using JobHub.DAL.DBObjects;
using JobHub.DAL.Session;

namespace JobHub.DAL.DataQueries
{
    public partial class DataQuery
    {
        public static class UsersQuery
        {
            public static bool FindPasswordCredential(DBUsers model)
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    var sql = "SELECT * FROM Users WHERE Email = :email and Password = :password";
                    var query = session.CreateSQLQuery(sql).AddEntity(typeof(DBUsers)).SetString("email", model.Email).SetString("password", model.Password).List();
                    if (query.Count == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }

            public static void WritePasswordCredential(DBUsers model)
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            var sql = $"INSERT INTO Users (Name, Password, Email) VALUES (:name, :password, :email)";
                            var query = session.CreateSQLQuery(sql)
                                .SetString("name", model.Name)
                                .SetString("password", model.Password)
                                .SetString("email", model.Email);

                            query.ExecuteUpdate();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Обработка ошибок, если необходимо
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}
