using JobHub.DAL.Data.DBObjects;
using JobHub.DAL.Session;
using JobHub.Web.Helpers;

namespace JobHub.DAL.DataQueries
{
    public partial class DataQuery
    {
        public static class UsersQuery
        {
            public static DBUsers FindPasswordCredential(DBUsers model)
            {
                using (var session = NHibernateSessionManager.Instance.GetSession())
                {
                    try
                    {
                        var query = session.Query<DBUsers>()
                            .Where(u => u.Email == model.Email)
                            .ToList();

                        if (query.Count == 1)
                        {
                            string hashedPassword = HashPasswordHelper.HashPassword(model.Password, query[0].Salt);

                            if (hashedPassword == query[0].Password)
                            {
                                return query[0];
                            }
                        }

                        return null;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
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
                            string salt = HashPasswordHelper.GenerateSalt();
                            string hashedPassword = HashPasswordHelper.HashPassword(model.Password, salt);

                            var sql = $"INSERT INTO Users (Name, Password, Salt, Email) VALUES (:name, :password, :salt, :email)";
                            var query = session.CreateSQLQuery(sql)
                                .SetString("name", model.Name)
                                .SetString("password", hashedPassword)
                                .SetString("salt", salt)
                                .SetString("email", model.Email);

                            query.ExecuteUpdate();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}
